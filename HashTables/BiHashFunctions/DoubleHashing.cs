using HashTables.HashFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.BiHashFunctions
{
    public class DoubleHashing : IBiHashFunction<int>
    {
        public int Hash(int key, int attempt, int capacity)
        {
            //         Простое хеширование:
            //         hash1(key) = key % capacity
            //         hash2(key) = prime - (key % prime)
            //         (где prime - простое число меньше capacity)

            int prime = 4999;
            DivisionMethod func1 = new DivisionMethod();
            DivisionMethod func2 = new DivisionMethod();
            double sdvig = prime - (key % (prime - 1));
            //return (int)Math.Abs((func1.Hash(key, capacity) + attempt * (1 + func2.Hash(key, 11))) % capacity);
            return (int)Math.Abs((func1.Hash(key, capacity) + attempt * sdvig) % capacity);
        }
    }
}
