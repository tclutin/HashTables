using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.HashFunctions
{
    public class DivisionMethod : IHashFunction<int>
    {
        public int Hash(int key, int capacity)
        {
            return Division(key, capacity);
        }

        public int Division(int key, int capacity)
        {
            return Math.Abs(key) % capacity;
        }
    }
}
