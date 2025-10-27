@echo off
echo 🔨 Building C Library for Windows...

mkdir libs 2>nul

echo Building mathlib.dll...
gcc -shared -o libs\mathlib.dll src\mathlib.c -I includes -D MATHLIB_EXPORTS -O2

if %errorlevel% neq 0 (
    echo ❌ Build failed!
    exit /b 1
)

echo ✅ Built: libs\mathlib.dll
dir libs\