using System.Runtime.InteropServices;
using MyApplication;

namespace NativeLibraryDemo
{
    /// <summary>
    /// Provides platform-specific native library information
    /// </summary>
    public static class MyNativeLibrary
    {
        /// <summary>
        /// Gets the platform-specific library filename
        /// </summary>
        public static string GetLibraryFilename()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return "mathlib.dll";
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return "libmathlib.so";
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return "libmathlib.dylib";
            else
                throw new PlatformNotSupportedException($"Unsupported platform: {RuntimeInformation.OSDescription}");
        }
    }
}