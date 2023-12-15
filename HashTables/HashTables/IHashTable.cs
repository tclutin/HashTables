using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.HashTables
{
    public interface IHashTable<T, V>
    {
        void Add(T key, V value);
        void Remove(T key, V value);
        V Get(T key);
    }
}
