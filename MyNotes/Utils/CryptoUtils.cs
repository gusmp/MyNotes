using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Utils
{
    public static class CryptoUtils
    {
        public static byte[] GetSha1(string data)
        {
            return GetSha1(System.Text.Encoding.UTF8.GetBytes(data));
        }

        public static byte[] GetSha1(byte[] data)
        {
            SHA1Managed sha1Managed = new SHA1Managed();
            return (sha1Managed.ComputeHash(data));
        }
    }
}
