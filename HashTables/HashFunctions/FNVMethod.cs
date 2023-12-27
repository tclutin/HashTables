using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.HashFunctions
{
    public class FNVMethod : IHashFunction<int>
    {
        public int Hash(int key, int capacity)
        {
            return FNV(key, capacity);
        }

        public int FNV(int key, int capacity)
        {
            const uint FNV_prime = 16777619;
            const uint FNV_offset_basis = 2166136261;

            string value = key.ToString();

            uint hash = FNV_offset_basis;

            for (uint i = 0; i < value.Length; i++)
            {
                hash = (hash * FNV_prime) ^ value[(int)i];
            }

            return Math.Abs((int)(hash % capacity));
        }
    }
}