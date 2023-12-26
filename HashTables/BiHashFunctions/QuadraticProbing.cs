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
            double c1 = 0.61803398875;
            double c2 = 0.61803398875;
            double stepHash = (_supportiveFunc.Hash(key, capacity) * c1 * attempt + c2 * attempt * attempt) % capacity;
            return Math.Abs((int)stepHash);
            //int hash = (key + attempt * attempt) % capacity;
            //return hash;
        }
    }
}
