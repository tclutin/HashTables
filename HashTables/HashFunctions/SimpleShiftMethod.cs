using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.HashFunctions
{
    public class SimpleShiftMethod : IHashFunction<int>
    {
        public int Hash(int key, int capacity)
        {
            return SimpleShift(key, capacity); 
        }

        public int SimpleShift(int key, int capacity)
        {
            int hash = 0;

            foreach (char c in key.ToString())
            {
                hash = (hash << 5) + c;
            }

            return Math.Abs(hash % capacity);
        }
    }
}
