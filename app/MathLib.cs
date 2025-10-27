using System.Runtime.InteropServices;
using System.Text;

namespace MyApplication;

public static class MathLib
{
    #if WINDOWS
        private const string LIBRARY_NAME = "mathlib.dll";
    #elif LINUX
        private const string LIBRARY_NAME = "libmathlib.so";
    #elif MACOS
        private const string LIBRARY_NAME = "libmathlib.dylib";
    #else
        private const string LIBRARY_NAME = "mathlib.dll";
    #endif

    [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern int add(int a, int b);
    
    [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern int subtract(int a, int b);

    [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern double multiply(double a, double b);

    [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern double divide(double a, double b);
    
    [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void get_version(StringBuilder buffer, int bufferSize);
    
    [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern void get_description(StringBuilder buffer, int bufferSize);
    
    [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
    public static extern int process_array(int[] input, int length, int[] output);
}