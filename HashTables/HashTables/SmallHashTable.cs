using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.HashTables
{
    public class SmallHashTable
    {
        public readonly int capacity;

        public readonly List<KeyValuePair<string, string>>[] buckets;

        public SmallHashTable()
        {
            capacity = 1000;
            buckets = new List<KeyValuePair<string, string>>[capacity];
        }
    }
}
