using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.HashFunctions
{
    public interface IHashFunction<T>
    {
        int Hash(T key);
    }
}
