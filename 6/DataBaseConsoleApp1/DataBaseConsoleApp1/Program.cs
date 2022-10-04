using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean file = File.Exists(@"database.txt");
            if (!file)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Файл отсутствует, создать y/n?");
                Console.ResetColor();
                Console.WriteLine();
                string create = Console.ReadLine();
                if (create != "y")
                {
                    return;
                }                
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Вас приветствует справочник С# что вы хотите сделать?");
            Console.WriteLine("1. Открыть справочник");
            Console.WriteLine("2. Добавить нового сотрудника");
            Console.ResetColor();
            Console.WriteLine();
            string open = Console.ReadLine();
            if (open == "1")
            {
                using (StreamReader sr = new StreamReader("database.txt"))
                {
                    string line;
                    Console.WriteLine($"{"ID",5}{" Время",22} {"Ф. И. О.",15} {"Возраст",7} {"Рост",4} {"Дата рождения",15} {"Место рождения",15}");

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split('#');
                        Console.WriteLine($"{data[0],5} {data[1],20} {data[2],15} {data[3],7} {data[4],4} {data[5],15} {data[6],15}");

                    }
                    Console.ReadKey(true);
                }
            }
            if (open == "2")
            {            
            using (StreamWriter sw = new StreamWriter("database.txt", true))
            {
                char key = 'y';

                do
                {
                    string note = string.Empty;
                    Console.Write("Введите ID записи: ");
                    note += $"{Console.ReadLine()}#";

                    DateTime now = DateTime.Now;
                    note += $"{now}#";

                    Console.Write("Введите ФИО сотрудника: ");
                    note += $"{Console.ReadLine()}#";
                    

                    Console.Write("Введите возраст сотрудника: ");
                    note += $"{Console.ReadLine()}#";
                    

                    Console.Write("Введите рост сотрудника: ");
                    note += $"{Console.ReadLine()}#";
                    

                    Console.Write("Введите дату рождения сотрудника: ");
                    note += $"{Console.ReadLine()}#";
                    

                    Console.Write("Введите место рождения сотрудника: ");
                    note += $"{Console.ReadLine()}#";
                    sw.WriteLine(note);
                    Console.WriteLine();
                    Console.Write("Продожить n/y"); key = Console.ReadKey(true).KeyChar;
                    Console.WriteLine();
                } while (char.ToLower(key) == 'y');
            }
            }
        }
    }
}
