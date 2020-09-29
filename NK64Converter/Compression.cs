
using System;
using System.IO;

namespace NK64Converter
{
    internal class Compression
    {
        public static bool Compress(string s)
        {
            using FileStream fs = File.Create("Output.NK64");
            string? outputbase64 = Convert.ToBase64String(File.ReadAllBytes(s));
            using StreamWriter sw = new StreamWriter(fs);
            sw.Write(outputbase64);

            FileInfo fi = new FileInfo(fs.Name);
            return fi.Length != 0;
        }

        public static bool Decompress()
        {
            using FileStream fs = File.Create("New.swf");
            byte[] bytes = Convert.FromBase64String(File.ReadAllText("Output.NK64"));
            fs.Write(bytes, 0, bytes.Length);

            FileInfo fi = new FileInfo(fs.Name);
            return fi.Length != 0;
        }
    }
}
