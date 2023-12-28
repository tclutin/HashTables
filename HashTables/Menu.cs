using HashTables.HashFunctions;
using HashTables.HashTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    public class Menu
    {
        public SmallHashTable<int, string> _smallTable = new SmallHashTable<int, string>();

        public void Импортозамещение()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1.SmallTable");
                Console.WriteLine("2.BigTable");

                Console.Write("Введите действие: ");
                int value = ParseInt();

                switch (value)
                {
                    case 1:
                        GenerateSmallTable();
                        break;
                   case 2:
                        //todo big
                        break;
                    default:
                        Console.WriteLine("Укажите корректный пункт меню");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void GenerateSmallTable()
        {
            Console.Clear();
            Console.WriteLine("Инициализация SmallTable");
            Console.ReadLine();
            _smallTable = new SmallHashTable<int, string>();
            Console.Clear();
            SubMenuForSmallTable();
        }
       
        //create generatebigtable

        public void SubMenuForSmallTable()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1.Division");
            Console.WriteLine("2.Multiply");
            Console.WriteLine("3.FNV1");
            Console.WriteLine("4.MD5Num");
            Console.WriteLine("5.Mixed");
            Console.WriteLine("6.SimpleShift");

            Console.Write("Введите действие: ");
            int value = ParseInt();

            switch (value)
            {
                case 1:
                    Console.WriteLine("Выбран DivisionMethod");
                    _smallTable._hash = new DivisionMethod();
                    GeneratorForSmallTable();
                    break;
                case 2:
                    Console.WriteLine("Выбран MultiplyMethod");
                    _smallTable._hash = new MultiplyMethod();
                    GeneratorForSmallTable();
                    break;
                case 3:
                    Console.WriteLine("Выбран FNV1");
                    _smallTable._hash = new FNVMethod();
                    GeneratorForSmallTable();
                    break;
                case 4:
                    Console.WriteLine("Выбран MD5Num");
                    _smallTable._hash = new MD5NumMethod();
                    GeneratorForSmallTable();
                    break;
                case 5:
                    Console.WriteLine("Выбран Mixed");
                    _smallTable._hash = new MixedMethod();
                    GeneratorForSmallTable();
                    break;
                case 6:
                    Console.WriteLine("Выбран SimpleShiftMethod");
                    _smallTable._hash = new SimpleShiftMethod();
                    GeneratorForSmallTable();
                    break;
                default:
                    Console.WriteLine("Укажите корректный пункт меню");
                    Console.ReadLine();
                    break;
            }
        }

        //submenu for bigtable

        public void GeneratorForSmallTable()
        {
            Console.ReadLine();
            Console.Clear();
            Console.Write("Введите количество элементов для генерации: ");
            int value = ParseInt();

            for (int i = 0; i < value; i++)
            {
                _smallTable.Add(i, "Hello");
            }
            Console.WriteLine($"Коэф.заполнения: {_smallTable.CalculateLoadFactor()}");
            Console.WriteLine($"Длиная цепочка: {_smallTable.GetLongChain()}");
            Console.WriteLine($"Короткая цепочка: {_smallTable.GetShortChain()}");
            Console.ReadLine();
        }

        //generator of leemtns for big table

        public int ParseInt()
        {
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                return number;
            }
            return 0;
        }
    }
}
