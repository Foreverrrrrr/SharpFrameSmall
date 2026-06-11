using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SharpFrameSmall.language
{
    public class LocalizationService
    {
        private static readonly string[] SupportedCultures = { "zh-CN", "zh-TW", "en-US", "vi-VN" };

        public void ChangeCulture(string culture)
        {
            if (!SupportedCultures.Contains(culture)) return;

            var dict = new ResourceDictionary
            {
                Source = new Uri($"language/{culture}.xaml", UriKind.Relative)
            };
            var existing = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source?.OriginalString.StartsWith("language/") == true);

            if (existing != null)
                Application.Current.Resources.MergedDictionaries.Remove(existing);

            Application.Current.Resources.MergedDictionaries.Add(dict);
            Properties.Settings.Default.Language = culture;
            Properties.Settings.Default.Save();
        }

        public string LoadSavedCulture()
        {
            return Properties.Settings.Default.Language ?? "zh-CN";
        }
    }

    public class LanguageItem
    {
        public string Display { get; set; }
        public string Culture { get; set; }
    }
}
