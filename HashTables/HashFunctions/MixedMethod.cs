using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HashTables.HashFunctions
{
    public class MixedMethod : IHashFunction<int>
    {
        public int Hash(int key, int capacity)
        {
            return Mixed(key, capacity);
        }

        public int Mixed(int key, int capacity)
        {
            int sha = 0;
            int mda = 0;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(key.ToString()));

                string hashString = BitConverter.ToString(hashBytes);
                string result = Regex.Replace(hashString, "\\D", "");

                BigInteger numericHash = BigInteger.Parse(result);
                sha = Math.Abs((int)(numericHash % capacity));
            }

            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(key.ToString()));

                string hashString = BitConverter.ToString(hashBytes);

                string result = Regex.Replace(hashString, "\\D", "");

                BigInteger numericHash = BigInteger.Parse(result);

                mda = Math.Abs((int)(numericHash % capacity));
            }

            return Math.Abs((sha + mda) % capacity);
        }
    }
}
