using HashTables.Common;
using HashTables.Models;


namespace HashTables.HashTables
{
    public class SmallHashTable<T, V> : IHashTable<T, V>
    {
        public int Count = 0;

        public readonly int capacity = 1000;
        public readonly DoublyLinkedList<Entity<T, V>>[] buckets;

        public delegate int HashFunction(T key);

        public SmallHashTable()
        {
            buckets = new DoublyLinkedList<Entity<T, V>>[capacity];
        }

        public int GetBaseHash(T key)
        {
            if (key == null)
            {
                return 0;
            }

            Type valueType = typeof(T);

            if (valueType == typeof(string))
            {
                
            }

            return Math.Abs(key.GetHashCode() % capacity);
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
                buckets[index] = new DoublyLinkedList<Entity<T, V>>();
                buckets[index].AddLast(entity);
                Count++;
                Console.WriteLine($"Добавился элемент с хешом {index} {entity.Key} - {entity.Value}");
            }
            else
            {
                var current = buckets[index];
                var element = current.head;

                while (element != null)
                {
                    if (element.Data.Key.Equals(key))
                    {
                        element.Data.Value = entity.Value;
                        Console.WriteLine($"Элемент с ключом {key} и хешом {index} обновлен на значение {entity.Value}");
                        return;
                    }
                    element = element.Next;
                }
                Console.WriteLine($"Произошла коллизия с хешом {index} {entity.Key} - {entity.Value}");
                current.AddLast(entity);
                Count++;
            }

        }

        public V Get(T key)
        {
            int index = GetBaseHash(key); ;
            var current = buckets[index];
            var element = current.head;

            while (element != null)
            {
                if (element.Data.Key.Equals(key))
                {
                    return element.Data.Value;
                }
                element = element.Next;
            }
            return default(V);
        }

        public void Remove(T key)
        {
            int index = GetBaseHash(key);
            var current = buckets[index];

            if (current != null)
            {
                var element = current.head;

                while (element != null)
                {
                    if (element.Data.Key.Equals(key))
                    {
                        current.Remove(element.Data);
                        Count--;
                        Console.WriteLine($"Элемент с ключом {key} удален.");
                        return;
                    }
                    element = element.Next;
                }
            }

            Console.WriteLine($"Элемент с ключом {key} не найден.");

        }
    }
}
