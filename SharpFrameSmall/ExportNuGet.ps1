# 允许临时执行
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass -Force
Set-Location -Path $PSScriptRoot
Write-Host "当前工作目录: $PSScriptRoot"

$projectFile = Join-Path $PSScriptRoot "SharpFrameSmall.csproj"
if (!(Test-Path $projectFile)) {
    Write-Error "项目文件不存在: $projectFile"
    exit 1
}

$parentDir  = Split-Path -Parent $PSScriptRoot
$packageDir = Join-Path $parentDir "Nuge\packages"

if (!(Test-Path $packageDir)) {
    New-Item -ItemType Directory -Path $packageDir | Out-Null
    Write-Host "已创建目录: $packageDir"
}

Write-Host "`n开始恢复依赖..."
dotnet restore $projectFile `
    --source "https://api.nuget.org/v3/index.json" `
    --packages $packageDir

if ($LASTEXITCODE -ne 0) {
    Write-Error "依赖恢复失败。"
    exit 1
}

Write-Host "`n----- 完成 -----"
Write-Host "包缓存路径：$packageDir"
Get-ChildItem -Path $packageDir | ForEach-Object {
    Write-Host "  $($_.Name)"
}

# 使用方式（在 CMD 中执行）:
# powershell -ExecutionPolicy Bypass -File "D:\Sundry\云同步\Csharp\SharpFrameSmall\SharpFrameSmall\ExportNuGet.ps1"