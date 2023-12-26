using HashTables.HashFunctions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.BiHashFunctions
{
    public class LinearMethod : IBiHashFunction<int>
    {
        public IHashFunction<int> _supportiveFunc { get; set; }
        public LinearMethod(IHashFunction<int> supportiveFunc)
        { 
            _supportiveFunc = supportiveFunc;
        }
        public int Hash(int key, int attempt, int capacity)
        {
            return (_supportiveFunc.Hash(key, capacity) + attempt) % capacity;
        }
    }
}
