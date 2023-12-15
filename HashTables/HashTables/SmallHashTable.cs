using HashTables.Models;


namespace HashTables.HashTables
{
    public class SmallHashTable<T, V>: IHashTable<T, V>
    {
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
            int index = GetBaseHash(key);
            var entity = new Entity<T, V>()
            {
                Key = key,
                Value = value,
            };

            if (buckets[index] == null)
            {
                buckets[index] = new List<Entity<T, V>>();
                buckets[index].Add(entity);
            }
            else
            {
                var current = buckets[index];
                foreach (var item in current)
                {
                    //todo
                }
            }

        }

        public V Get(T key)
        {
            int index = GetBaseHash(key);
            if (buckets[index] != null)
            {
                foreach (var item in buckets[index])
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }
            }
            return default(V);
        }

        public void Remove(T key, V value)
        {
            throw new NotImplementedException();
        }
    }
}
