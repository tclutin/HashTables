using HashTables.HashFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace HashTables.BiHashFunctions
{
    public class DoubleHashing : IBiHashFunction<int>
    {
        public IHashFunction<int> _supportiveFunc { get; set; } 
        public DoubleHashing(IHashFunction<int> supportiveFunc)
        {
            _supportiveFunc = supportiveFunc;
        }
        public int Hash(int key, int attempt, int capacity)
        {
            int prime = 2927;
            double offset = prime - (key % (prime - 1));
            return (int)Math.Abs((_supportiveFunc.Hash(key, capacity) + attempt * offset) % capacity);
        }
    }
}
