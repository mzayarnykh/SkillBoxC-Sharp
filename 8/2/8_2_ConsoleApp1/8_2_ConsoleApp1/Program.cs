using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_2_ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// add lines to phonebook
        /// </summary>
        /// <returns></returns>
        static Dictionary<string, string> phoneList()
        {
            var dictionary = new Dictionary<string, string>();

            Console.WriteLine("Введите ФИО");
            Console.WriteLine("");
            string name = Console.ReadLine();
            string number;

            do
            {
                Console.WriteLine("Введите номер");
                Console.WriteLine("");
                number = Console.ReadLine();
                if (number != "")
                {
                    dictionary.Add(number, name);
                }
                else break;
            }
            while (number != null);
            return dictionary;
        }

        /// <summary>
        /// поиск
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        static string lineSearch(Dictionary<string, string> dictionary)
        {
            Console.WriteLine("попробуем найти владельца номер... введите номер:");
            Console.WriteLine("");
            string searchNumer = Console.ReadLine();
            string search = null;
            Boolean Az = dictionary.TryGetValue(searchNumer, out search);
                        
            if (Az)
            {
                search = $"Владелец данного номера: {dictionary[searchNumer]}.";
            }

            if (!Az)
            {
                search = "владельца по такому номеру телефона не зарегистрировано";
            }
            return search;
        }
        static void Main(string[] args)
        {

            var dictionary = phoneList();

            string search = lineSearch(dictionary);

            Console.WriteLine(search);

        }
    }
}
