using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.BiHashFunctions
{
    public interface IBiHashFunction<T>
    {
        int Hash(T key, int attempt, int capacity);
    }
}
