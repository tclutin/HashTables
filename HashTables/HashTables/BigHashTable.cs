using HashTables.BiHashFunctions;
using HashTables.HashTables;
using HashTables.Models;


namespace HashTables.HashTable
{
    public class BigHashTable<V> : IHashTable<int, V>
    {
        private int capacity = 10000;
        private Entity<int, V>[] buckets;
        private readonly double maxFillFactor = 0.8;
        private List<int> _clasters = new List<int>();
        public int GetMaxClaster => _clasters.Max();
        public IBiHashFunction<int> HashFunc { get; set; }

        public BigHashTable()
        {
            buckets = new Entity<int, V>[capacity];
        }

        public void Add(int key, V value)
        {
            if (GetFillFactor() >= maxFillFactor) { ResizeTable(); }
            int attempt = 0;
            int hash = HashFunc.Hash(key, attempt, capacity);
            var entity = new Entity<int, V>()
            {
                Key = key,
                Value = value,
            };

            while (hash < capacity && attempt < capacity)
            {
                if (buckets[hash] is null || buckets[hash] is not null && buckets[hash].Key.Equals(key))
                {
                    buckets[hash] = entity;
                    _clasters.Add(attempt);
                    Console.WriteLine($"Добавился элемент с хешом {hash} и ключ-значением {entity.Key} - {entity.Value}");
                    return;
                }
                Console.WriteLine($"Произошла коллизия : ключи {key} - {buckets[hash].Key}");
                hash = HashFunc.Hash(key, ++attempt, capacity);
            }
            Console.WriteLine("Элемент не добавлен");
        }

        public void Remove(int key)
        {
            int attempt = 0;
            int hash = HashFunc.Hash(key, attempt, capacity);

            while (buckets[hash] is not null && attempt < capacity)
            {
                if (buckets[hash]?.Key.Equals(key) == true)
                {
                    buckets[hash] = null;
                    Console.WriteLine($"Элемент с ключом {key} удален.");
                    return;
                }
                hash = HashFunc.Hash(key, ++attempt, capacity);
            }
        }

        public V Get(int key)
        {
            int attempt = 0;
            int hash = HashFunc.Hash(key, attempt, capacity);

            while (buckets[hash] is not null)
            {
                if (buckets[hash].Key == key)
                {
                    return buckets[hash].Value;
                }
                hash = HashFunc.Hash(key, ++attempt, capacity);
            }
            return default(V);
        }

        public double GetFillFactor()
        {
            double count = buckets.Count(x => x is not null);
            return count / (double)capacity;
        }

        private void ResizeTable()
        {
            capacity *= 2;
            Console.WriteLine($"\nНачинаем перезаписывать таблицу : размер {capacity}\n");
            _clasters.Clear();
            Entity<int, V>[] newArray = new Entity<int, V>[capacity];
            foreach(Entity<int, V> element in buckets)
            {
                int attempt = 0;
                if (element is not null)
                {
                    int hash = HashFunc.Hash(element.Key, attempt, capacity);
                    while (attempt < capacity)
                    {
                        if (newArray[hash] is null)
                        {
                            newArray[hash] = element;
                            _clasters.Add(attempt);
                            Console.WriteLine($"Перезаписался элемент с ключ-значением {element.Key} - {element.Value} на хеш {hash}");
                            break;
                        }
                        hash = HashFunc.Hash(element.Key, ++attempt, capacity);
                    }
                }
            }
            buckets = newArray;
        }

        public void FillTable(int range, int min, int max)
        {
            List<int> uniqueKeys = new List<int>();
            Random random = new Random();
            for (int i = 0; i < range; i++)
            {
                int rand = random.Next(min, max);
                if (!uniqueKeys.Contains(rand))
                {
                    Add(rand, default(V));
                    uniqueKeys.Add(rand);
                } else { i--; }
            }
            uniqueKeys.Sort();
        }
    }
}