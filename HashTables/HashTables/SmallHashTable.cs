using HashTables.Models;


namespace HashTables.HashTables
{
    public class SmallHashTable<T, V>: IHashTable<T, V>
    {
        public int Count = 0;

        public readonly int capacity = 1000;
        public readonly List<Entity<T, V>>[] buckets;

        public SmallHashTable()
        {
            buckets = new List<Entity<T, V>>[capacity];
        }

        public int GetBaseHash(T key)
        {
            return Math.Abs(key.GetHashCode() % 1000);
        }

        public void Add(T key, V value)
        {
            int index = 1;
            var entity = new Entity<T, V>()
            {
                Key = key,
                Value = value,
            };

            if (buckets[index] == null)
            {
                buckets[index] = new List<Entity<T, V>>();
                buckets[index].Add(entity);
                Count++;
                Console.WriteLine($"Добавился элемент с хешом {index} {entity.Key} - {entity.Value}");
            }
            else
            {
                var current = buckets[index];
                var bucket = current.Find(bucket => bucket.Key.Equals(key));
                if (bucket != null)
                {
                    bucket.Value = value;
                    Console.WriteLine($"Элемент с ключом {key} обновлен: {bucket.Value}");
                    return;
                }

                Console.WriteLine($"Произошла коллизия с хешом {index} {entity.Key} - {entity.Value}");
                current.Add(entity);
                Count++;
            }

        }

        public V Get(T key)
        {
            int index = 1;

            Entity<T, V> bucket = buckets[index].Find(bucket => bucket.Key.Equals(key));
            if (bucket != null)
            {
                return bucket.Value;
            }
            return default(V);
        }

        public void Remove(T key, V value)
        {
            throw new NotImplementedException();
        }
    }
}
