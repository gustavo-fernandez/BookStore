using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cryptography
{
    public class SHA256Utils
    {
        private SHA256Utils()
        {
        }

        public static string ComputeDigest(string inputText)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputText);
            byte[] digest = sha256.ComputeHash(inputBytes);
            return CryptoUtils.ByteArrayToHexString(digest);
        }

        public static string ComputeHMAC(string inputText, string salt)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputText);
            HMACSHA256 hmacSha256 = new HMACSHA256(saltBytes);
            byte[] hmac = hmacSha256.ComputeHash(inputBytes);
            return CryptoUtils.ByteArrayToHexString(hmac);
        }
    }
}
