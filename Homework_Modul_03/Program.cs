using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_Modul_03
{
    internal class Program
    {


        static void Delete(ref int[] array, int[] array2)
        {
            List<int> Result = array.ToList();

            for (int i = 0; i < array2.Length; i++)
            {
                for (int j = 0; j < Result.Count; j++)
                {
                    if (Result[j] == array2[i])
                    {
                        Result.RemoveAt(j);
                    }
                }
            }
            array = Result.ToArray();
        }
        public class Web_site
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public string Description { get; set; }
            public string Ip { get; set; }

            public override string ToString()
            {
                return $"{Name} {Url} {Description} {Ip}";
            }
        }

        public class Journal
        {
            public string Name { get; set; }
            public DateTime year_of_foundation { get; set; }
            public string Description { get; set; }
            public string Telephone { get; set; }
            public string e_mail { get; set; }
            public override string ToString()
            {
                return $"{Name} {year_of_foundation} {Description} {Telephone} {e_mail}";
            }
        }

        public class Shop
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string Description { get; set; }
            public string Telephone { get; set; }
            public string e_mail { get; set; }
            public override string ToString()
            {
                return $"{Name} {Address} {Description} {Telephone} {e_mail}";
            }
        }


        delegate void method();
        static void Main(string[] args)
        {

            string[] items = { "Задание 1", "Задание 2", "Задание 3",  "Выход" };
            method[] methods = new method[] { Method1, Method2, Method3, Exit };
            ConsoleMenu menu = new ConsoleMenu(items);
            int menuResult;
            do
            {
                menuResult = menu.PrintMenu();
                methods[menuResult]();
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
            } while (menuResult != items.Length - 1);
        }

        static void Method1()
        {
            Console.WriteLine("Введите размер: ");
            int n = int.Parse(Console.ReadLine());
            var str = new String('$', n);
            Console.WriteLine(str);
            int i = 0;
            while (i != n - 2)
            {
                Console.WriteLine("&" + new string('&', n - 2) + "&");
                i++;
            }
            Console.WriteLine(str);
            Console.ReadKey();
        }

        static void Method2()
        {
            Console.WriteLine("Введите значение:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine(IsPalindrome(x) ? "Палиндром" : "Не палиндром"); 
        }
        static bool IsPalindrome(int x)
        {
            int c = x, n = default;
            while (x > 0)
            {
                n = n * 10 + x % 10;
                x /= 10;
            }
            return c == n;
        }

        static void Method3()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int[] array2 = new int[] { 2, 5 };
            Delete(ref array, array2);
            foreach (int i in array)
                Console.WriteLine(i);
        }

        static void Exit()
        {
            Console.WriteLine("EXIT:)");
        }
    }


    class ConsoleMenu
    {
        string[] menuItems;
        int counter = 0;
        public ConsoleMenu(string[] menuItems)
        {
            this.menuItems = menuItems;
        }

        public int PrintMenu()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (counter == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menuItems[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.WriteLine(menuItems[i]);

                }
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    counter--;
                    if (counter == -1) counter = menuItems.Length - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    counter++;
                    if (counter == menuItems.Length) counter = 0;
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return counter;
        }
    }
}
