using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_3_ConsoleApp1
{
    class Program
    {

        /// <summary>
        /// Добавление номеров в HashSet
        /// </summary>
        static void AddNumber(HashSet<string> numbers)
        {
            char key = 'y';

            do
            {
                Console.WriteLine("");
                Console.WriteLine("Введите число для пополнения списка");
                Console.WriteLine("");
                string numberString = Console.ReadLine();
                string value = null;

                Boolean check = numbers.TryGetValue(numberString, out (value));

                if (!check)
                {
                    numbers.Add(numberString);
                    Console.Write("номер добавлен, добавить еще ? y/n");
                }

                if (check)
                {
                    Console.WriteLine("номер уже присутствует, добавить другой ? y/n");
                }
                key = Console.ReadKey(true).KeyChar;

            } while (char.ToLower(key) == 'y');

        }

        /// <summary>
        /// Вывод списка
        /// </summary>
        /// <param name="numbers"></param>
        static void PrintHash(HashSet<string> numbers)
        {
            foreach (var item in numbers)
            {
                Console.WriteLine();
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            HashSet<string> numbers = new HashSet<string>();

            numbers.Add("1");
            numbers.Add("2");
            numbers.Add("3");
            numbers.Add("4");
            numbers.Add("5");
            numbers.Add("6");

            Console.WriteLine("Текущий список чисел:");

            PrintHash(numbers);

            AddNumber(numbers);

            PrintHash(numbers);


        }
    }
}
