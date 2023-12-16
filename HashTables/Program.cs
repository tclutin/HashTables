using HashTables.HashTables;

namespace HashTables
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            QSmallHashTable<string, string> table = new QSmallHashTable<string, string>();
            table.Add("a", "b");
            table.Add("c", "d");
            table.Add("d", "e");

            table.Add("e", "f");
            table.Add("f", "g");
            table.Add("f", "g");
            table.Add("f", "2");

            table.Add("cq", "2132132132132133");
            //foreach (var item in table.buckets)
            //{
            //    if (item != null)
            //    {
            //        foreach (var item2 in item)
            //        {
            //            Console.WriteLine($"{item2.Key} {item2.Value}");
            //        }
            //    }
            //}
            //Console.WriteLine(table.Count);
            //table.Remove("cq");
            //Console.WriteLine(table.Get("cq"));
            foreach (var item in table.buckets)
            {
                if (item != null)
                {
                    var x = item;
                    while (x != null)
                    {
                        Console.WriteLine($"{x.Key} {x.Value}");
                        x = x.Next;
                    }
                }
            }
            Console.WriteLine(table.Count);
            table.Remove("cq");
            table.Remove("a");
            Console.WriteLine(table.Get("cq"));
            foreach (var item in table.buckets)
            {
                if (item != null)
                {
                    var x = item;
                    while (x != null)
                    {
                        Console.WriteLine($"{x.Key} {x.Value}");
                        x = x.Next;
                    }
                }
            }
            Console.WriteLine(table.Count);
            //var x = table.Get("d");
            //Console.WriteLine($"{x}");
            //foreach (var item in table.buckets)
            //{
            //    if (item != null)
            //    {
            //        foreach (var item1 in item)
            //        {
            //            Console.WriteLine($"{item1.Key}, {item1.Value}");

            //        }
            //    }
            //}
        }
    }
}