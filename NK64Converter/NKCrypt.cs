using System.IO;
using System.IO.Compression;

namespace NK64Converter
{
    class NKCrypt
    {
        private static byte[] Inflate(byte[] compressedBytes)
        {
            byte[] decompressedBytes = new byte[compressedBytes.Length];
            using (MemoryStream ms = new MemoryStream(compressedBytes))
            {
                using (DeflateStream decompressionStream = new DeflateStream(ms, CompressionMode.Decompress))
                {
                    decompressionStream.Read(decompressedBytes, 0, compressedBytes.Length);
                }
            }

            return decompressedBytes;
        }

        public static string Decrypt(byte[] ba)
        {
            int @char;
            ba = Inflate(ba);
            string @out = string.Empty;
            string key = "vviiiojrnmasfncvviiihhbcjvhwopvviiioidychnxm";
            int j = 0;

            for (int i = 0; i < ba.Length; i++)
            {
                @char = ba[i] ^ key[j];
                @out += (char)@char;
                j++;
                if (j >= key.Length)
                {
                    j = 0;
                }
            }

            return @out;
        }
    }
}
