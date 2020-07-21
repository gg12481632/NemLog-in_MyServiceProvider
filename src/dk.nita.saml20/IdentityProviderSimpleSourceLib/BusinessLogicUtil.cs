using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProviderSimpleSourceLib
{
    public class BusinessLogicUtil
    {
        public static string DeflateDecompress(string str)
        {
            byte[] encoded = Convert.FromBase64String(str);
            MemoryStream memoryStream = new MemoryStream(encoded);

            StringBuilder result = new StringBuilder();
            using (DeflateStream stream = new DeflateStream(memoryStream, CompressionMode.Decompress))
            {
                StreamReader testStream = new StreamReader(new BufferedStream(stream), Encoding.UTF8);
                // It seems we need to "peek" on the StreamReader to get it started. If we don't do this, the first call to 
                // ReadToEnd() will return string.empty.
                testStream.Peek();
                result.Append(testStream.ReadToEnd());

                stream.Close();
            }
            return result.ToString();
        }

        public static string ReplaceInvalidCharsInFileName(string filename)
        {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        }

        public static string GetMd5HashedSPEntityId(string entityID)
        {
            byte[] hash;
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            hash = md5.ComputeHash(Encoding.UTF8.GetBytes(entityID));

            // convert hash value to hex string 
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
            {
                // convert each byte to a Hexadecimalstring 
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }


    }
}
