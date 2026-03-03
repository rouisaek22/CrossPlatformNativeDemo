# Cross-Platform Native Library Demo

A .NET application demonstrating P/Invoke integration with a native C math library. The solution includes both a feature-rich C math library (`mathlib`) and a .NET console application that showcases its capabilities.

Features:
- Basic arithmetic operations (add, subtract, multiply, divide)
- Advanced math functions (power, square root, factorial)
- Number theory utilities (GCD, LCM)
- Array processing with error handling
- Cross-platform compatibility layer
- Version and description information
- Platform-aware DLL loading

This repository contains both the managed C# demo app and the native C library it uses via P/Invoke.

## Prerequisites

- .NET SDK 9.0 or later (dotnet)
- A C compiler that can produce a Windows DLL (e.g. MinGW's `gcc`, or MSVC `cl`)
- PowerShell (examples below assume PowerShell on Windows)

## Quick start (PowerShell)

1) Build the native library (MinGW/GCC example — run from repository root):

- `mathlib.dll`: for windows
- `libmathlib.so`: for linux
- `libmathlib.dylib`: for osx

```powershell
gcc -shared -o .\libs\[mathlib.dll - libmathlib.so - libmathlib.dylib] .\src\mathlib.c -I .\includes -D MATHLIB_EXPORTS -O2 -lm
```

The `-lm` flag links the math library (needed for `pow()` and `sqrt()`). If using MSVC, the math functions are part of the C runtime.

2) Build the .NET application including the target OS (execute inside the app folder):

- The build system will automatically handle library copying to output.
- `-r` flag for target platform

```powershell
dotnet build -r [linux-x64 - win-x64 - osx-x64 - osx-arm64] -c Release
```

3) Run the demo app including the target OS (execute inside the app folder):

```powershell
dotnet run -r [linux-x64 - win-x64 - osx-x64 - osx-arm64] -c Release
```

The demo will show:
- Platform detection and library loading
- Basic arithmetic operations
- Array processing (doubles each value)
- Library version and description info
- Error handling (e.g., division by zero protection)

## Project structure

- `Project.sln` — Visual Studio / dotnet solution
- `app/` — C# application and `MyApplication.csproj`
- `src/` — C source files (native library)
- `includes/` — C header files (for the native library)
- `libs/` — place built native binaries (e.g. `mathlib.dll`) here

Key files:

- `app/MyApplication.csproj` — the .NET project
- `src/mathlib.c` — native C implementation
- `includes/mathlib.h` — native header

## API Reference

The native library (`mathlib`) provides:

Basic operations:
- `int add(int a, int b)` - Add two integers
- `int subtract(int a, int b)` - Subtract b from a
- `double multiply(double a, double b)` - Multiply two doubles
- `double divide(double a, double b)` - Divide a by b (returns 0 if b is 0)

Advanced math:
- `double power(double base, double exponent)` - Raise base to exponent
- `double square_root(double value)` - Calculate square root (returns 0 for negative input)
- `int factorial(int n)` - Calculate n! (returns 0 for negative input)

Number theory:
- `int gcd(int a, int b)` - Greatest Common Divisor
- `int lcm(int a, int b)` - Least Common Multiple

Array operations:
- `int process_array(const int* input, int length, int* output)` - Process array (doubles each value)

Information:
- `void get_version(char* buffer, int bufferSize)` - Get library version
- `void get_description(char* buffer, int bufferSize)` - Get library description

## Notes & Troubleshooting

- DLL loading: The native library must be in the same folder as the executable or on PATH
- Math errors: The library includes safety checks (e.g., division by zero protection)
- Arrays: Empty or null arrays return -1 as an error code
- Buffers: Version/description functions require pre-allocated buffers

<!-- ## Contributing

Areas for improvement:
- SIMD optimizations for array processing
- Additional mathematical functions
- Automated tests
- CI/CD pipeline
- Cross-platform build scripts -->

## License

See the `LICENSE` file in the repository root.