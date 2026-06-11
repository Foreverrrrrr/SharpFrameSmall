using Newtonsoft.Json;
using SharpFrameSmall.log4Net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharpFrameSmall.Common.Commumication
{
    public static class PostHelper
    {
        public static bool CacheTaskLock = false;

        public static bool IsSuccess = false;
        /// <summary>
        /// 缓存发送事件
        /// </summary>
        public static event Action<string, FailedRequest> RetryRequests;

        /// <summary>
        /// 发送JSON 格式的HTTP POST请求
        /// </summary>
        /// <param name="url">目标请求地址</param>
        /// <param name="jsonBody">请求体中的 JSON 字符串</param>
        /// <param name="headers">可选的 HTTP 请求头</param>
        /// <param name="timeout">可选的超时时间（默认 30 秒）</param>
        /// <returns>PostResult结构</returns>
        public static async Task<PostResult> PostJsonAsync(string url, string jsonBody, Dictionary<string, string> headers = null, TimeSpan? timeout = null)
        {
            var result = new PostResult();
            try
            {
                var client = new HttpClient { Timeout = timeout ?? TimeSpan.FromSeconds(5) };
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = content };
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        if (!header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                        {
                            request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                        }
                    }
                }
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                responseContent = responseContent.Replace("\r", string.Empty).Replace("\n", string.Empty);
                if (response.IsSuccessStatusCode)
                {
                    result.IsSuccess = true;
                    result.Content = responseContent;
                }
                else
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = $"HTTP {(int)response.StatusCode}: {response.ReasonPhrase}";
                    result.Content = responseContent;
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 发送JSON 格式的HTTP POST请求
        /// </summary>
        /// <param name="url">目标请求地址</param>
        /// <param name="jsonBody">请求体中的 JSON 字符串</param>
        /// <returns>PostResult结构</returns>
        public static async Task<PostResult> PostJsonAsync(string url, string jsonBody, double Outtime = 30)
        {
            var result = new PostResult();
            try
            {
                Log.Info($"HTTP POST发送\r\nurl:{url}\r\n{jsonBody}");
                var headers = new Dictionary<string, string>
                {
                    { "Accept", "application/json" }
                };
                using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(Outtime) })
                using (var content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
                using (var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = content })
                {
                    foreach (var header in headers)
                    {
                        if (!header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                        {
                            request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                        }
                    }
                    var response = await client.SendAsync(request);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseContent = responseContent.Replace("\r", string.Empty).Replace("\n", string.Empty);
                    if (response.IsSuccessStatusCode)
                    {
                        IsSuccess = true;
                        result.IsSuccess = true;
                        result.Content = responseContent;
                    }
                    else
                    {
                        IsSuccess = false;
                        result.IsSuccess = false;
                        result.ErrorMessage = $"HTTP {(int)response.StatusCode}: {response.ReasonPhrase}";
                        result.Content = responseContent;
                        RequestCache.CacheFailedRequest(url, jsonBody);
                    }
                }
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                result.IsSuccess = false;
                result.ErrorMessage = $"{url}";
                RequestCache.CacheFailedRequest(url, jsonBody);
            }
            return result;
        }

        public static async Task<string> PostFormAsync(string url, Dictionary<string, string> formData, TimeSpan? timeout = null)
        {
            var client = new HttpClient
            {
                Timeout = timeout ?? TimeSpan.FromSeconds(30)
            };
            var content = new FormUrlEncodedContent(formData);
            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 缓存线程
        /// </summary>
        /// <returns></returns>
        public static async Task RetryFailedRequestsAsync()
        {
            while (true)
            {
                try
                {
                    await Task.Delay(1000);
                    if (IsSuccess && CacheTaskLock)
                    {
                        var failedRequests = RequestCache.LoadFailedRequests();
                        if (failedRequests.Count > 0)
                        {
                            foreach (var item in failedRequests)
                            {
                                RequestCache.RemoveFailedRequest(item);
                                PostResult retryResult = await PostJsonAsync(item.Url, item.JsonBody,30);
                                if (retryResult.IsSuccess)
                                {
                                    RetryRequests?.Invoke($"緩存重試成功 , 剩余：{failedRequests.Count}缓存数 ", item);
                                }
                                else
                                {
                                    RetryRequests?.Invoke($"緩存重試失敗 , 剩余：{failedRequests.Count}缓存数 ", item);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }

    public class PostResult
    {
        public bool IsSuccess { get; set; }
        public string Content { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class RequestCache
    {
        /// <summary>
        /// 缓存发送事件
        /// </summary>
        public static event Action<string> RetryRequests;

        private static readonly string FailedRequestsFile = "failed_requests.json";

        private static readonly BlockingCollection<FailedRequest> _failedqueue = new BlockingCollection<FailedRequest>();

        static RequestCache()
        {
            var threadQueue = new Thread(ProcessQueueAsync) { Name = "threadQueue", IsBackground = true };
            threadQueue.Start();
        }

        /// <summary>
        /// 缓存入队
        /// </summary>
        public static void CacheFailedRequest(string url, string jsonBody)
        {
            var failedRequest = new FailedRequest
            {
                Url = url,
                JsonBody = jsonBody
            };
            _failedqueue.Add(failedRequest);
            RetryRequests?.Invoke($"上抛失败缓存（入队）：url:{url}\r\n{jsonBody} 剩余：{_failedqueue.Count}缓存数");
        }

        /// <summary>
        /// 后台线程处理队列
        /// </summary>
        private static void ProcessQueueAsync()
        {
            foreach (var request in _failedqueue.GetConsumingEnumerable())
            {
                try
                {
                    List<FailedRequest> failedRequests = LoadFailedRequests();
                    failedRequests.Add(request);
                    File.WriteAllText(FailedRequestsFile, JsonConvert.SerializeObject(failedRequests, Formatting.Indented));
                    RetryRequests?.Invoke($"缓存写入完成：url:{request.Url} 剩余：{_failedqueue.Count}缓存数");
                }
                catch (Exception ex)
                {
                    RetryRequests?.Invoke($"缓存写入异常：{ex} 剩余：{_failedqueue.Count}缓存数");
                    _failedqueue.Add(request);
                }
            }
        }

        /// <summary>
        /// 加载缓存
        /// </summary>
        public static List<FailedRequest> LoadFailedRequests()
        {
            lock (FailedRequestsFile)
            {
                if (!File.Exists(FailedRequestsFile))
                {
                    return new List<FailedRequest>();
                }
                var jsonContent = File.ReadAllText(FailedRequestsFile);
                return JsonConvert.DeserializeObject<List<FailedRequest>>(jsonContent) ?? new List<FailedRequest>();
            }
        }

        /// <summary>
        /// 删除指定缓存
        /// </summary>
        public static void RemoveFailedRequest(FailedRequest failedRequest)
        {
            lock (FailedRequestsFile)
            {
                var failedRequests = LoadFailedRequests();
                failedRequests.RemoveAll(r => r.Url == failedRequest.Url && r.JsonBody == failedRequest.JsonBody);
                File.WriteAllText(FailedRequestsFile, JsonConvert.SerializeObject(failedRequests, Formatting.Indented));
                RetryRequests?.Invoke($"删除缓存：url:{failedRequest.Url}\r\n{failedRequest.JsonBody}");
            }
        }

        /// <summary>
        /// 停止队列
        /// </summary>
        public static void Stop()
        {
            _failedqueue.CompleteAdding();
        }
    }

    public class ServerResponse
    {
        public string Result { get; set; }
        public string Message { get; set; }
    }

    public class FailedRequest
    {
        public string Url { get; set; }
        public string JsonBody { get; set; }
    }
}
