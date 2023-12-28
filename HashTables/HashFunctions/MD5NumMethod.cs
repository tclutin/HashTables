using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HashTables.HashFunctions
{
    public class MD5NumMethod : IHashFunction<int>
    {
        public int Hash(int key, int capacity)
        {
            return MD5Num(key, capacity);
        }

        public int MD5Num(int key, int capacity)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(key.ToString()));

                string hashString = BitConverter.ToString(hashBytes);

                string result = Regex.Replace(hashString, "\\D", "");

                BigInteger numericHash = BigInteger.Parse(result);

                return Math.Abs((int)((numericHash / 2) % capacity));
            }
        }
    }
}
