using HashTables.HashTables;

namespace HashTables
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            SmallHashTable table = new SmallHashTable();

            Console.WriteLine(table.capacity);
        }
    }
}