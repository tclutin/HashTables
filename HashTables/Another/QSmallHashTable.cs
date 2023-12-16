using HashTables.Models;


namespace HashTables.HashTables
{
    public class QSmallHashTable<T, V>
    {
        public int Count = 0;

        public readonly int capacity = 1000;
        public readonly Entity<T, V>[] buckets;

        public QSmallHashTable()
        {
            buckets = new Entity<T, V>[capacity];
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
                buckets[index] = entity;
                Count++;
                Console.WriteLine($"Добавился элемент с хешом {index} {entity.Key} - {entity.Value}");
            }
            else
            {
                var current = buckets[index];
                while (current != null)
                {
                    if (current.Key.Equals(key))
                    {
                        current.Value = value;
                        Console.WriteLine($"Элемент с ключом {key} обновлен: {current.Value}");
                        return;
                    }

                    if (current.Next == null)
                    {
                        current.Next = entity;
                        Count++;
                        Console.WriteLine($"Произошла коллизия с хешом {index} {entity.Key} - {entity.Value}");
                        break;
                    }
                    current = current.Next;
                }
            }
        }

        public V Get(T key)
        {
            int index = 1;
            Entity<T, V> bucket = buckets[index];

            while (bucket != null)
            {
                if (bucket.Key.Equals(key))
                {
                    return bucket.Value;
                }
                bucket = bucket.Next;
            }
            return default(V);
        }

        public void Remove(T key)
        {
            int index = 1;
            Entity<T, V> bucket = buckets[index];
            //todo
        }
    }
}
