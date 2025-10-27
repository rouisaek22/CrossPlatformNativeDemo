using System;
using System.Text;
using MyApplication;

namespace NativeLibraryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Cross-Platform Native Library Demo ===\n");
            
            DisplayPlatformInfo();
            Console.WriteLine();
            
            TestBasicMath();
            Console.WriteLine();
            
            TestLibraryInfo();
            Console.WriteLine();
            
            TestArrayProcessing();
            Console.WriteLine();
            
            // Console.WriteLine("Press any key to exit...");
            // Console.ReadKey();
        }
        
        static void DisplayPlatformInfo()
        {
            Console.WriteLine($"Platform: {Environment.OSVersion}");
            Console.WriteLine($"Runtime: {System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}");
            Console.WriteLine($"Process Architecture: {System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture}");
            Console.WriteLine($"Native Library: {MyNativeLibrary.GetLibraryFilename()}");
        }
        
        static void TestBasicMath()
        {
            Console.WriteLine("🧮 Basic Math Operations:");
            
            int a = 15, b = 7;
            double x = 12.5, y = 3.2;
            
            Console.WriteLine($"  {a} + {b} = {MathLib.add(a, b)}");
            Console.WriteLine($"  {a} - {b} = {MathLib.subtract(a, b)}");
            Console.WriteLine($"  {x} × {y} = {MathLib.multiply(x, y):F2}");
            Console.WriteLine($"  {x} ÷ {y} = {MathLib.divide(x, y):F2}");
            
            // Test error case
            Console.WriteLine($"  Division by zero protection: {MathLib.divide(10.0, 0.0):F2}");
        }
        
        static void TestLibraryInfo()
        {
            Console.WriteLine("📚 Library Information:");
            
            StringBuilder version = new(256);
            MathLib.get_version(version, version.Capacity);
            Console.WriteLine($"  Version: {version}");
            
            StringBuilder description = new(256);
            MathLib.get_description(description, description.Capacity);
            Console.WriteLine($"  Description: {description}");
        }
        
        static void TestArrayProcessing()
        {
            Console.WriteLine("🔢 Array Processing:");
            
            int[] inputArray = { 1, 2, 3, 4, 5, 10 };
            int[] outputArray = new int[inputArray.Length];
            
            int sum = MathLib.process_array(inputArray, inputArray.Length, outputArray);
            
            Console.WriteLine($"  Input:  [{string.Join(", ", inputArray)}]");
            Console.WriteLine($"  Output: [{string.Join(", ", outputArray)}]");
            Console.WriteLine($"  Sum of processed values: {sum}");
            
            // Test with empty array
            int[] emptyInput = Array.Empty<int>();
            int[] emptyOutput = Array.Empty<int>();
            int emptySum = MathLib.process_array(emptyInput, emptyInput.Length, emptyOutput);
            Console.WriteLine($"  Empty array result: {emptySum}");
        }
    }
}