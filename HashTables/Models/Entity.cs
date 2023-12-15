using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.Models
{
    public class Entity<T, V>
    {
        public T Key { get; set; }
        public V Value { get; set; }
        public Entity<T, V> Next { get; set; }
    }
}
