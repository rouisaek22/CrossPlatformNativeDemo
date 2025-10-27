#!/bin/bash

echo "Building C Library..."

mkdir -p libs

# Detect platform and set appropriate options
case "$(uname -s)" in
    Linux*)
        echo "Building for Linux..."
        gcc -shared -o libs/libmathlib.so src/mathlib.c -I includes -fPIC -O2 -s
        cd app/
        dotnet build --runtime linux-x64
        echo "Built Linux library: libs/libmathlib.so"
        ;;
    Darwin*)
        echo "Building for macOS..."
        # Try clang first, fall back to gcc
        if command -v clang &> /dev/null; then
            clang -dynamiclib -o libs/libmathlib.dylib src/mathlib.c -I includes -O2 -current_version 1.0 -compatibility_version 1.0
            cd app/
            dotnet build --runtime osx-x64
        else
            gcc -dynamiclib -o libs/libmathlib.dylib src/mathlib.c -I includes -O2
            cd app/
            dotnet build --runtime osx-x64
        fi
        echo "Built macOS library: libs/libmathlib.dylib"
        ;;
    CYGWIN*|MINGW*|MSYS*)
        echo "Building for Windows..."
        gcc -shared -o libs/mathlib.dll src/mathlib.c -I includes -D MATHLIB_EXPORTS -O2 -s
        cd app/
        dotnet build --runtime win-x64
        echo "Built Windows library: libs/mathlib.dll"
        ;;
    *)
        echo "Unsupported platform: $(uname -s)"
        exit 1
        ;;
esac