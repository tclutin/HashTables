using HashTables.HashFunctions;
using HashTables.HashTables;

namespace HashTables
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //for strings
            //SmallHashTable<string, string> table = new SmallHashTable<string, string>();
            //table.Add("a", "b");
            //table.Add("c", "d");
            //table.Add("d", "e");

            //table.Add("e", "f");
            //table.Add("f", "g");
            //table.Add("f", "g");
            //table.Add("f", "2");

            //table.Add("cq", "2132132132132133");

            //foreach (var item in table._buckets)
            //{
            //    if (item != null)
            //    {
            //        foreach (var item1 in item)
            //        {
            //            Console.WriteLine($"{item1.Key} -- { item1.Value}");
            //        }
            //    }
            //}
            //Console.WriteLine(table._count);
            //table.Remove("cq");
            //table.Remove("f");
            //table.Remove("c");
            //foreach (var item in table._buckets)
            //{
            //    if (item != null)
            //    {
            //        foreach (var item1 in item)
            //        {
            //            Console.WriteLine($"{item1.Key} -- {item1.Value}");
            //        }
            //    }
            //}
            //Console.WriteLine(table._count);



            //for ints
            SmallHashTable<int, string> table = new SmallHashTable<int, string>();
            table._hash = new MultiplyMethod();
            table.Add(1, "1");
            table.Add(2, "2");
            table.Add(3, "3");
            table.Add(4, "4");
            table.Add(5, "5");

            for (int i = 0; i < 10000; i++)
            {
                table.Add(i, "1");
            }

            foreach (var item in table._buckets)
            {
                if (item != null)
                {
                    foreach (var item1 in item)
                    {
                        Console.WriteLine($"{item1.Key} -- {item1.Value}");
                    }
                }
            }
            Console.WriteLine((int)20 % 1000);
        }
    }
}