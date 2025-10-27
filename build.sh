#!/bin/bash

echo "🔨 Building C Library..."

mkdir -p libs

case "$(uname -s)" in
    Linux*)
        echo "🐧 Building for Linux..."
        gcc -shared -o libs/libmathlib.so src/mathlib.c -I includes -fPIC -O2
        # Create a symlink for the C# app
        cd libs && ln -sf libmathlib.so mathlib && cd ..
        echo "✅ Built Linux library: libs/libmathlib.so -> libs/mathlib"
        ;;
    Darwin*)
        echo "🍎 Building for macOS..."
        if command -v clang >/dev/null 2>&1; then
            clang -dynamiclib -o libs/libmathlib.dylib src/mathlib.c -I includes -O2
        else
            gcc -dynamiclib -o libs/libmathlib.dylib src/mathlib.c -I includes -O2
        fi
        # Create a symlink for the C# app
        cd libs && ln -sf libmathlib.dylib mathlib && cd ..
        echo "✅ Built macOS library: libs/libmathlib.dylib -> libs/mathlib"
        ;;
    CYGWIN*|MINGW*|MSYS*)
        echo "🪟 Building for Windows..."
        gcc -shared -o libs/mathlib.dll src/mathlib.c -I includes -D MATHLIB_EXPORTS -O2
        echo "✅ Built Windows library: libs/mathlib.dll"
        ;;
    *)
        echo "❌ Unsupported platform: $(uname -s)"
        exit 1
        ;;
esac

# List what we built
echo "Final library files:"
ls -la libs/