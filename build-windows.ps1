# build-windows.ps1 - PowerShell script for Windows
Write-Host "🔨 Building C Library for Windows..."

# Create libs directory if it doesn't exist
if (-not (Test-Path "libs")) {
    New-Item -ItemType Directory -Path "libs" | Out-Null
}

# Build the DLL
$gccCommand = "gcc -shared -o libs\mathlib.dll src\mathlib.c -I includes -D MATHLIB_EXPORTS -O2"
Invoke-Expression $gccCommand

if ($LASTEXITCODE -ne 0) {
    Write-Host "❌ Build failed!"
    exit 1
}

Write-Host "✅ Built: libs\mathlib.dll"
Get-ChildItem "libs\"