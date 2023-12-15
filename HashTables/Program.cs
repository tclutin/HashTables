using HashTables.HashTables;

namespace HashTables
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            SmallHashTable<string, string> table = new SmallHashTable<string, string>();
            table.Add("a", "b");
            table.Add("c", "d");
            table.Add("d", "e");
                
            table.Add("e", "f");
            table.Add("f", "g");
            table.Add("f", "g");
            table.Add("f", "g");
            table.Add("f", "g");
            table.Add("f", "g");

            var x = table.Get("f");
            Console.WriteLine($"{x}");
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