param(
    [string]$SourceDir = "Assets/Build/V1.0.1",
    [string]$OutputRoot = ".publish/webgl-v1.0.1",
    [switch]$Force
)

$ErrorActionPreference = "Stop"

function Resolve-ProjectPath {
    param([string]$Path)

    if ([System.IO.Path]::IsPathRooted($Path)) {
        return $Path
    }

    return Join-Path (Get-Location) $Path
}

$sourcePath = Resolve-ProjectPath $SourceDir
$outputPath = Resolve-ProjectPath $OutputRoot
$sitePath = Join-Path $outputPath "site"
$zipPath = Join-Path $outputPath "webgl-v1.0.1-static-host.zip"

if (-not (Test-Path $sourcePath)) {
    throw "Source directory not found: $sourcePath"
}

$requiredFiles = @(
    "index.html",
    "Build/V1.0.1.data",
    "Build/V1.0.1.framework.js",
    "Build/V1.0.1.loader.js",
    "Build/V1.0.1.wasm",
    "Build/V1.0.1.jpg"
)

foreach ($relativePath in $requiredFiles) {
    $fullPath = Join-Path $sourcePath $relativePath
    if (-not (Test-Path $fullPath)) {
        throw "Required file missing: $fullPath"
    }
}

if (Test-Path $outputPath) {
    if (-not $Force) {
        throw "Output path already exists: $outputPath. Re-run with -Force to overwrite."
    }

    Remove-Item -LiteralPath $outputPath -Recurse -Force
}

New-Item -ItemType Directory -Path $sitePath | Out-Null
Get-ChildItem -LiteralPath $sourcePath -Force | ForEach-Object {
    Copy-Item -LiteralPath $_.FullName -Destination $sitePath -Recurse -Force
}

$zipParent = Split-Path $zipPath -Parent
if (-not (Test-Path $zipParent)) {
    New-Item -ItemType Directory -Path $zipParent | Out-Null
}

Compress-Archive -Path (Join-Path $sitePath "*") -DestinationPath $zipPath -CompressionLevel Optimal -Force

$siteFiles = Get-ChildItem -LiteralPath $sitePath -Recurse -File
$summary = [pscustomobject]@{
    SourceDir = $sourcePath
    SiteDir = $sitePath
    ZipPath = $zipPath
    FileCount = $siteFiles.Count
    TotalBytes = ($siteFiles | Measure-Object -Property Length -Sum).Sum
}

$summary | Format-List
