
using System;
using System.IO;

namespace NK64Converter
{
    internal class Program
    {
        private static void Main()
        {
            if (File.Exists("Input.swf"))
            {
                Console.WriteLine(Compression.Compress("Input.swf"));
                Console.ReadKey();
            }

            Console.WriteLine(Compression.Decompress());
            Console.ReadKey();
        }
    }
}
