#ifndef MATHLIB_H
#define MATHLIB_H

#ifdef __cplusplus
extern "C" {
#endif

// DLL export macro
#ifdef _WIN32
    #ifdef MATHLIB_EXPORTS
        #define MATHLIB_API __declspec(dllexport)
    #else
        #define MATHLIB_API __declspec(dllimport)
    #endif
#else
    #define MATHLIB_API
#endif

// Function declarations
MATHLIB_API int add(int a, int b);
MATHLIB_API int subtract(int a, int b);
MATHLIB_API double multiply(double a, double b);
MATHLIB_API double divide(double a, double b);
MATHLIB_API void get_version(char* buffer, int bufferSize);
MATHLIB_API int process_array(const int* input, int length, int* output);

#ifdef __cplusplus
}
#endif

#endif // MATHLIB_H