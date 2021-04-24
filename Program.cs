using System;
using System.IO;
using System.Linq;

namespace Task13
{
    class Program
    {
        static void Main()
        {
            try
            {
                int n = 3;
                CollectionType<Trapezium>[] array =
                {
                new CollectionType<Trapezium>(),
                new CollectionType<Trapezium>(),
                new CollectionType<Trapezium>()
            };
                array[0].AddLast(new Trapezium(4, 6, 4, 4));
                array[0].AddLast(new Trapezium(8, 10, 7, 7));
                array[0].AddLast(new Trapezium(10, 11, 10, 10));
                array[1].AddLast(new Trapezium(5, 7, 4, 4));
                array[2].AddLast(new Trapezium(7, 9, 6, 6));
                array[2].AddLast(new Trapezium(8, 10, 4, 4));

                SaveToFile(array);
                PrintToConsole(array);
                OrderBy(array);
                OrderByDescending(array);
                NSizeCollection(array, n);
                MaxCollection(array);
                MinCollection(array);
                Console.WriteLine("Запросы");
                Qeury0(array);
                Query1(array);
                Query2(array);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        static void SaveToFile(CollectionType<Trapezium>[] array)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream("info.txt", FileMode.Create)))
            {
                int i = 0;
                writer.WriteLine($"Сторона A\tСторона B\tСторона C\tСторона D\tПериметр\tПлощадь");
                writer.WriteLine("================================================================================================");
                foreach (var element in array)
                {
                    writer.WriteLine($"\t\t\t\t***{i} коллекция в массиве***");
                    foreach (var trapezium in element)
                    {
                        writer.WriteLine($"{trapezium.A}\t\t{trapezium.B}\t\t{trapezium.C}\t\t{trapezium.D}\t\t{trapezium.P}\t\t{trapezium.S}");
                    }
                    i++;
                }
                writer.WriteLine("================================================================================================\n");
            }
        }

        static void PrintToConsole(CollectionType<Trapezium>[] array)
        {
            int i = 0;
            Console.WriteLine($"Сторона A\tСторона B\tСторона C\tСторона D\tПериметр\tПлощадь");
            Console.WriteLine("================================================================================================");
            foreach (var collection in array)
            {
                Console.WriteLine($"\t\t\t***{i} коллекция в массиве***");
                foreach (var trapezium in collection)
                {
                    Console.WriteLine($"{trapezium.A}\t\t{trapezium.B}\t\t{trapezium.C}\t\t{trapezium.D}\t\t{trapezium.P}\t\t{trapezium.S}");
                }
                i++;
            }
            Console.WriteLine("================================================================================================\n");
        }

        static void OrderBy(CollectionType<Trapezium>[] array)
        {
            Console.WriteLine("Отсортированные по возрастанию коллекции: ");
            Console.WriteLine($"Сторона A\tСторона B\tСторона C\tСторона D\tПериметр\tПлощадь");
            Console.WriteLine("================================================================================================");
            int i = 0;
            foreach (var collection in array)
            {
                Console.WriteLine($"\t\t\t***{i} коллекция в массиве***");
                foreach (var trapezium in from trapezium in collection orderby trapezium.S select trapezium)
                {
                    Console.WriteLine($"{trapezium.A}\t\t{trapezium.B}\t\t{trapezium.C}\t\t{trapezium.D}\t\t{trapezium.P}\t\t{trapezium.S}");
                }
                i++;
            }
            Console.WriteLine("================================================================================================\n");
        }

        static void OrderByDescending(CollectionType<Trapezium>[] array)
        {
            Console.WriteLine("Отсортированные по убыванию коллекции: ");
            Console.WriteLine($"Сторона A\tСторона B\tСторона C\tСторона D\tПериметр\tПлощадь");
            Console.WriteLine("================================================================================================");
            int i = 0;
            foreach (var collection in array)
            {
                Console.WriteLine($"\t\t\t***{i} коллекция в массиве***");
                foreach (var trapezium in from trapezium in collection orderby trapezium.S descending select trapezium)
                {
                    Console.WriteLine($"{trapezium.A}\t\t{trapezium.B}\t\t{trapezium.C}\t\t{trapezium.D}\t\t{trapezium.P}\t\t{trapezium.S}");
                }
                i++;
            }
            Console.WriteLine("================================================================================================\n");
        }

        static void NSizeCollection(CollectionType<Trapezium>[] array, int n)
        {
            Console.WriteLine($"Коллекция размера {n}: ");
            Console.WriteLine($"Сторона A\tСторона B\tСторона C\tСторона D\tПериметр\tПлощадь");
            Console.WriteLine("================================================================================================");
            foreach (var collection in from item in array where item.Count == n select item)
            {
                foreach (var trapezium in collection)
                {
                    Console.WriteLine($"{trapezium.A}\t\t{trapezium.B}\t\t{trapezium.C}\t\t{trapezium.D}\t\t{trapezium.P}\t\t{trapezium.S}");
                }
            }
            Console.WriteLine("================================================================================================\n");
        }

        static void MaxCollection(CollectionType<Trapezium>[] array)
        {
            Console.WriteLine("Максимальная коллекция: ");
            Console.WriteLine($"Сторона A\tСторона B\tСторона C\tСторона D\tПериметр\tПлощадь");
            Console.WriteLine("================================================================================================");
            foreach (var collection in from item in array where item.Count == array.Max(index => index.Count) select item)
            {
                foreach (var trapezium in collection)
                {
                    Console.WriteLine($"{trapezium.A}\t\t{trapezium.B}\t\t{trapezium.C}\t\t{trapezium.D}\t\t{trapezium.P}\t\t{trapezium.S}");
                }
            }
            Console.WriteLine("================================================================================================\n");
        }

        static void MinCollection(CollectionType<Trapezium>[] array)
        {
            Console.WriteLine("Минимальная коллекция: ");
            Console.WriteLine($"Сторона A\tСторона B\tСторона C\tСторона D\tПериметр\tПлощадь");
            Console.WriteLine("================================================================================================");
            foreach (var collection in from item in array where item.Count == array.Min(index => index.Count) select item)
            {
                foreach (var trapezium in collection)
                {
                    Console.WriteLine($"{trapezium.A}\t\t{trapezium.B}\t\t{trapezium.C}\t\t{trapezium.D}\t\t{trapezium.P}\t\t{trapezium.S}");
                }
            }
            Console.WriteLine("================================================================================================\n");
        }

        static void Qeury0(CollectionType<Trapezium>[] array)
        {
            Console.WriteLine("Трапеции с площадью больше 100: ");
            Console.WriteLine($"Сторона A\tСторона B\tСторона C\tСторона D\tПериметр\tПлощадь");
            Console.WriteLine("================================================================================================");
            foreach (var collection in array)
            {
                foreach (var trapezium in from trapezium in collection where trapezium.S > 100 orderby trapezium.S select trapezium)
                {
                    Console.WriteLine($"{trapezium.A}\t\t{trapezium.B}\t\t{trapezium.C}\t\t{trapezium.D}\t\t{trapezium.P}\t\t{trapezium.S}");
                }
            }
            Console.WriteLine("================================================================================================\n");
        }

        static void Query1(CollectionType<Trapezium>[] array)
        {
            Console.WriteLine("Трапеции с периметром меньше 20: ");
            Console.WriteLine($"Сторона A\tСторона B\tСторона C\tСторона D\tПериметр\tПлощадь");
            Console.WriteLine("================================================================================================");
            foreach (var collection in array)
            {
                foreach (var trapezium in from trapezium in collection where trapezium.P < 20 orderby trapezium.S select trapezium)
                {
                    Console.WriteLine($"{trapezium.A}\t\t{trapezium.B}\t\t{trapezium.C}\t\t{trapezium.D}\t\t{trapezium.P}\t\t{trapezium.S}");
                }
            }
            Console.WriteLine("================================================================================================\n");
        }

        static void Query2(CollectionType<Trapezium>[] array)
        {
            Console.WriteLine("Трапеции с чётными сторонами: ");
            Console.WriteLine($"Сторона A\tСторона B\tСторона C\tСторона D\tПериметр\tПлощадь");
            Console.WriteLine("================================================================================================");
            foreach (var collection in array)
            {
                foreach (var trapezium in from trapezium in collection where trapezium.A % 2 == 0 && trapezium.B % 2 == 0 && trapezium.C % 2 == 0 && trapezium.D % 2 == 0 orderby trapezium.S select trapezium)
                {
                    Console.WriteLine($"{trapezium.A}\t\t{trapezium.B}\t\t{trapezium.C}\t\t{trapezium.D}\t\t{trapezium.P}\t\t{trapezium.S}");
                }
            }
            Console.WriteLine("================================================================================================\n");
        }
    }
}
