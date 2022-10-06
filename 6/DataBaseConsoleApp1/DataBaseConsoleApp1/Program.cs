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

        // метод вызывает меню
        static void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Вас приветствует справочник С# что вы хотите сделать?");
            Console.WriteLine("1. Открыть справочник");
            Console.WriteLine("2. Добавить нового сотрудника");
            Console.WriteLine("3. Выйти");
            Console.ResetColor();
            Console.WriteLine();
            string open = Console.ReadLine();

            if (open == "1")
            {
                ViewFile();
            }

            if (open == "2")
            {
                AddPerson();
            }

            if (open == "2")
            {
                return;
            }
        }

        // метод добавления записи в файл
        static void AddPerson()
        {
            Console.Clear();
            using (StreamWriter sw = new StreamWriter("database.txt", true))
            {
                char key = 'y';

                do
                {                    
                    Console.Write("Введите ID записи: ");
                    string data1 = Console.ReadLine();

                    DateTime now = DateTime.Now;
                    string data2 = now.ToString();

                    Console.Write("Введите ФИО сотрудника: ");
                    string data3 = Console.ReadLine();

                    Console.Write("Введите возраст сотрудника: ");
                    string data4 = Console.ReadLine();

                    Console.Write("Введите рост сотрудника: ");
                    string data5 = Console.ReadLine();

                    Console.Write("Введите дату рождения сотрудника: ");
                    string data6 = Console.ReadLine();

                    Console.Write("Введите место рождения сотрудника: ");
                    string data7 = Console.ReadLine();

                    string note = string.Join("#", 
                        data1, 
                        data2, 
                        data3, 
                        data4, 
                        data5, 
                        data6, 
                        data7);
                    sw.WriteLine(note);

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Создать ещё одну запись ? y/n");
                    key = Console.ReadKey(true).KeyChar;
                    Console.ResetColor();
                } while (char.ToLower(key) == 'y');                
            }
            Menu();
        }

        // метод вывода данных из файла
        static void ViewFile()
        {
            Console.Clear();
            using (StreamReader sr = new StreamReader("database.txt"))
            {
                string line;
                Console.WriteLine($"" +
                    $"{"ID",5}" +
                    $"{" Время",22} " +
                    $"{"Ф. И. О.",15} " +
                    $"{"Возраст",7} " +
                    $"{"Рост",4} " +
                    $"{"Дата рождения",15} " +
                    $"{"Место рождения",15}");

                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('#');
                    Console.WriteLine($"" +
                        $"{data[0],5} " +
                        $"{data[1],20} " +
                        $"{data[2],15} " +
                        $"{data[3],7} " +
                        $"{data[4],4} " +
                        $"{data[5],15} " +
                        $"{data[6],15}");

                }                
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Чтобы перейти в меню нажмите любую кнопку");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        // метод создает файл
        static void CreateFile(string database)
        {
            File.Create(database).Dispose();
        }

        static void Main(string[] args)
        {
            Boolean file = File.Exists("database.txt");
            if (!file)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Файл отсутствует, создать y/n?");
                Console.ResetColor();
                Console.WriteLine();
                string create = Console.ReadLine();

                if (create == "y")
                {
                    File.Create(@"database.txt").Dispose();
                    Menu();
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Для корректной работы программы необходимо создать файл");
                Console.ResetColor();
                Console.ReadKey();
            } 

            else
            {
                Menu();
            }
        }
    }
}
