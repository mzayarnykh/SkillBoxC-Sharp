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

            // Проверка наличия файла базы данных
            Repository rep = new Repository(0);
            if (!rep.file)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Файл базы данных отсутствует, создать пустую базу? y/n");
                Console.ResetColor();
                Console.WriteLine();
                string create = Console.ReadLine();

                if (create == "y")
                {
                    rep.CreateFile();
                }
                if (create == "n")

                { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Для корректной работы программы необходимо создать файл");
                Console.ResetColor();
                Console.ReadKey();
                return;
                }
            }

            string exit = "0";
            rep.Load();

            do 
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Вас приветствует справочник С# что вы хотите сделать?");
                Console.WriteLine("1. Открыть справочник");
                Console.WriteLine("2. Поиск по ID");
                Console.WriteLine("3. Добавить нового сотрудника");
                Console.WriteLine("4. Удалить сотрудника");
                Console.WriteLine("5. Фильтрация по датам(от А(включительно) до Б(включительно)");
                Console.WriteLine("0. Выйти");
                Console.ResetColor();
                Console.WriteLine();
                string open = Console.ReadLine();

                if (open == "1")
                {                    
                    rep.ViewFile();
                }

                if (open == "2")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Введите номер записи");
                    Console.ResetColor();
                    Console.WriteLine();
                    string entID = Console.ReadLine();
                    int entIDint = int.Parse(entID);
                    rep.ViewIDFile(entIDint);
                    Console.ReadKey();
                }

                if (open == "3")
                {
                    rep.Write();
                    Console.ReadKey();
                }

                if (open == "4")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Введите номер записи");
                    Console.ResetColor();
                    Console.WriteLine();
                    string entID = Console.ReadLine();
                    int entIDint = int.Parse(entID);
                    rep.File_DeleteLine(entIDint);
                    Console.ReadKey();
                }

                if (open == "5")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Введите начальную дату");
                    Console.WriteLine();
                    string fromDateString = Console.ReadLine();
                    DateTime fromtDate = DateTime.Parse(fromDateString);
                    Console.WriteLine("Введите конечную дату");
                    Console.WriteLine();
                    string toDateString = Console.ReadLine();
                    DateTime toDate = DateTime.Parse(toDateString);
                    Console.ResetColor();
                    rep.ViewDateFile(fromtDate, toDate);
                    Console.ReadKey();
                }

                if (open == "0")
                {
                    break;
                }

            } while (exit != "1");
        }
    }
}
