using HashTables.HashFunctions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.BiHashFunctions
{
    public class QuadraticProbing : IBiHashFunction<int>
    {
        private IHashFunction<int> _supportiveFunc { get; set; }
        public QuadraticProbing(IHashFunction<int> supportiveFunc)
        {
            _supportiveFunc = supportiveFunc;
        }

        public int Hash(int key, int attempt, int capacity)
        {
            double constant = 0.6180339887;
            double stepHash = (_supportiveFunc.Hash(key, capacity) + constant * attempt * attempt) % capacity;
            return Math.Abs((int)stepHash);
        }
    }
}
