using HashTables.HashFunctions;
using HashTables.HashTables;

namespace HashTables
{
    public class Program
    {
        public static void Main(string[] args)
        {

            SmallHashTable<int, string> table = new SmallHashTable<int, string>();

            table._hash = new MultiplyMethod();

            int numberOfElements = 100000;
            double totalLoadFactor = 0;

            for (int i = 0; i < numberOfElements; i++)
            {
                table.Add(i, "HELLO");

                double currentLoadFactor = table.Fuckingniggers();
                totalLoadFactor += currentLoadFactor;

                //Console.WriteLine($"Итерация {i + 1}: Коэффициент заполнения = {currentLoadFactor}");
            }

            double averageLoadFactor = (double)totalLoadFactor / numberOfElements;
            Console.WriteLine($"Средний коэффициент заполнения: {averageLoadFactor}");

            Console.WriteLine($"Коэф.заполнения: {table.Fuckingniggers()}");
            Console.WriteLine($"Длиная цепочка: {table.GetLongChain()}");
            Console.WriteLine($"Короткая цепочка: {table.GetShortChain()}");


            //for ints
            //    SmallHashTable<int, string> table = new SmallHashTable<int, string>();
            //    table._hash = new SimpleShiftMethod();
            //    table.Add(1, "1");
            //    table.Add(2, "2");
            //    table.Add(3, "3");
            //    table.Add(4, "4");
            //    table.Add(5, "5");



            //    for (int i = 0; i < 10000; i++)
            //    {
            //        table.Add(i, "");
            //    }

            //    foreach (var item in table._buckets)
            //    {
            //        if (item != null)
            //        {
            //            foreach (var item1 in item)
            //            {
            //                Console.WriteLine($"{item1.Key} -- {item1.Value}");
            //            }
            //        }
            //    }
            //    Console.WriteLine(table.GetLongChain());
            //    Console.WriteLine(table.GetShortChain());
            //    Console.WriteLine(table.CalculateLoadFactor());
            //}
        }

    }
}