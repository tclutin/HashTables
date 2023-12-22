using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.HashFunctions
{
    public class MultiplyMethod : IHashFunction<int>
    {
        public int Hash(int key, int capacity)
        {
            return Multiply(key, capacity);
        }

        public int Multiply(int key, int capacity)
        {
            const double GOLDEN = 0.6180339887;

            return (int)Math.Abs(capacity * (key * GOLDEN % 1));
        }
    }
}
