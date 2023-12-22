using HashTables.Common;
using HashTables.HashFunctions;
using HashTables.Models;
using System.Drawing;


namespace HashTables.HashTables
{
    public class SmallHashTable<T, V> : IHashTable<T, V>
    {
        public int _count = 0;

        public readonly int _capacity = 1000;
        public readonly DoublyLinkedList<Entity<T, V>>[] _buckets;

        public IHashFunction<T> _hash;

        public SmallHashTable()
        {
            _buckets = new DoublyLinkedList<Entity<T, V>>[_capacity];
        }

        public int GetBaseHash(T key)
        {
            if (key == null)
            {
                return 0;
            }

            Type valueType = typeof(T);

            if (valueType == typeof(int))
            {
                return _hash.Hash(key, _capacity);
            }

            return 0;
        }

        public void Add(T key, V value)
        {
            int index = GetBaseHash(key);
            var entity = new Entity<T, V>()
            {
                Key = key,
                Value = value,
            };

            if (_buckets[index] == null)
            {
                _buckets[index] = new DoublyLinkedList<Entity<T, V>>();
                _buckets[index].AddLast(entity);
                _count++;
                Console.WriteLine($"Добавился элемент с хешом {index} и ключ-значением {entity.Key} - {entity.Value}");
            }
            else
            {
                var current = _buckets[index];
                var element = current.head;

                while (element != null)
                {
                    if (element.Data.Key.Equals(key))
                    {
                        element.Data.Value = entity.Value;
                        Console.WriteLine($"Элемент с ключом {key} и хешом {index}обновлен на значение {entity.Value}");
                        return;
                    }
                    element = element.Next;
                }
                Console.WriteLine($"Произошла коллизия с хешом {index} {entity.Key} - {entity.Value}");
                current.AddLast(entity);
                _count++;
            }

        }

        public V Get(T key)
        {
            int index = GetBaseHash(key); ;
            var current = _buckets[index];
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
            var current = _buckets[index];

            if (current != null)
            {
                var element = current.head;

                while (element != null)
                {
                    if (element.Data.Key.Equals(key))
                    {
                        current.Remove(element.Data);
                        _count--;
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
