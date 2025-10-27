#include "mathlib.h"
#include <string.h>
#include <math.h>

MATHLIB_API int add(int a, int b) {
    return a + b;
}

MATHLIB_API int subtract(int a, int b) {
    return a - b;
}

MATHLIB_API double multiply(double a, double b) {
    return a * b;
}

MATHLIB_API double divide(double a, double b) {
    if (b == 0.0) {
        return 0.0; // Simple error handling
    }
    return a / b;
}

MATHLIB_API void get_version(char* buffer, int bufferSize) {
    const char* version = "MathLib v0.1 Cross-Platform";
    strncpy(buffer, version, bufferSize - 1);
    buffer[bufferSize - 1] = '\0';
}

MATHLIB_API void get_description(char* buffer, int bufferSize) {
    const char* description = "High-performance math library for Windows, Linux, and macOS";
    strncpy(buffer, description, bufferSize - 1);
    buffer[bufferSize - 1] = '\0';
}

MATHLIB_API int process_array(const int* input, int length, int* output) {
    if (input == NULL || output == NULL || length <= 0) {
        return -1; // Error code
    }
    
    int sum = 0;
    for (int i = 0; i < length; i++) {
        output[i] = input[i] * 2; // Double each value
        sum += output[i];
    }
    
    return sum; // Return sum of processed values
}

MATHLIB_API double power(double baseValue, double exponent) {
    return pow(baseValue, exponent);
}

MATHLIB_API double square_root(double value) {
    if (value < 0.0) return 0.0;
    return sqrt(value);
}

MATHLIB_API int factorial(int n) {
    if (n < 0) return 0;
    if (n == 0 || n == 1) return 1;
    
    int result = 1;
    for (int i = 2; i <= n; i++) {
        result *= i;
    }
    return result;
}

MATHLIB_API int gcd(int a, int b) {
    while (b != 0) {
        int temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

MATHLIB_API int lcm(int a, int b) {
    if (a == 0 || b == 0) return 0;
    return (a * b) / gcd(a, b);
}