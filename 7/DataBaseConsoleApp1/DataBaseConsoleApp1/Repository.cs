using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConsoleApp1
{
    struct Repository
    {
        private Worker[] workers;

        private string path;

        int index;

        string[] titles;

        public Boolean file;

        public Repository(int index)
        {
            this.path = @"database.txt";
            this.index = 0;
            this.titles = new string[7];
            this.workers = new Worker[1];
            this.file = File.Exists("database.txt");

        }

        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.workers, this.workers.Length * 2);
            }
        }

        public void Add(Worker ConcreteWorker)
        {
            this.Resize(index >= this.workers.Length);
            this.workers[index] = ConcreteWorker;
            this.index++;
        }  

        /// <summary>
        // метод создает файл
        /// </summary>
        public void CreateFile()
        {
            File.Create(this.path).Dispose();
        }

        /// <summary>
        // метод вывода данных из файла
        /// </summary>
        public void ViewFile()
        {
            Console.Clear();
            using (StreamReader sr = new StreamReader(this.path))
            {
                Console.WriteLine($"" +
                    $"{"ID",5}" +
                    $"{" Время",22} " +
                    $"{"Ф. И. О.",30} " +
                    $"{"Возраст",7} " +
                    $"{"Рост",4} " +
                    $"{"Дата рождения",15} " +
                    $"{"Место рождения",15}");

                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');
                    Console.WriteLine($"{args[0],5}" +
                            $"{args[1],22}" +
                            $"{args[2],30}" +
                            $"{args[3],7}" +
                            $"{args[4],4}" +
                            $"{args[5],15}" +
                            $"{args[6],15}");         
                }
                Console.ReadKey(true);
            }
        }

        /// <summary>
        /// вывод записи по ID
        /// </summary>
        public void ViewIDFile(int which)
        {
            Console.Clear();
            using (StreamReader sr = new StreamReader(this.path))
            {
                Console.WriteLine(this.workers[which-1].Print());
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Чтобы перейти в меню нажмите любую кнопку");
            Console.ResetColor();
            Console.ReadKey();
        }

        /// <summary>
        /// вывод записи по Датам
        /// </summary>
        public void ViewDateFile(DateTime fromDate, DateTime toDate)
        {
            Console.Clear();
            using (StreamReader sr = new StreamReader(this.path))
            {
                Console.WriteLine($"" +
                    $"{"ID",5}" +
                    $"{" Время",22} " +
                    $"{"Ф. И. О.",30} " +
                    $"{"Возраст",7} " +
                    $"{"Рост",4} " +
                    $"{"Дата рождения",15} " +
                    $"{"Место рождения",15}");
                Console.WriteLine($"{fromDate} &&&&&&&& {toDate} ");
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');
                    DateTime arrayDate = DateTime.Parse(args[1]);

                    if (arrayDate > fromDate && arrayDate < toDate)
                    {
                    Console.WriteLine($"{args[0],5}" +
                        $"{args[1],22}" +
                        $"{args[2],30}" +
                        $"{args[3],7}" +
                        $"{args[4],4}" +
                        $"{args[5],15}" +
                        $"{args[6],15}");
                    }
                    
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Чтобы перейти в меню нажмите любую кнопку");
            Console.ResetColor();
            Console.ReadKey();
        }

        /// <summary>
        /// Сортировка по ФИО
        /// </summary>
        public void IdSorted()
        {
            var sortedPeople1 = from p in workers
                                orderby p.ID
                                select p;

            foreach (var p in sortedPeople1)
                Console.WriteLine($"{p.ID} - {p.Fio}");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Сортировка ID
        /// </summary>
        public void FioSorted()
        {
            var sortedPeople1 = from p in workers
                                orderby p.Fio
                                select p;

            foreach (var p in sortedPeople1)
                Console.WriteLine($"{p.ID} - {p.Fio}");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Загрузка из файла в массив
        /// </summary>
        public void Load()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    Add(new Worker(args[0], args[1], args[2], args[3], args[4], args[5], args[6]));
                }
            }
        }

        /// <summary>
        /// добавление новой записи
        /// </summary>
        public void Write()
        {
            Console.Clear();
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {
                char key = 'y';

                do
                {
                    int data1Int = this.index + 1;
                    string data1 = data1Int.ToString();

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
        }

        /// <summary>
        /// удаляет запись по ID
        /// </summary>
        public void File_DeleteLine(int Line)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(path))
            {
                int Countup = 0;
                while (!sr.EndOfStream)
                {
                    Countup++;
                    if (Countup != Line)
                    {
                        using (StringWriter sw = new StringWriter(sb))
                        {
                            sw.WriteLine(sr.ReadLine());
                        }
                    }
                    else
                    {
                        sr.ReadLine();
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(sb.ToString());
            }           
        }

        /// <summary>
        /// Количество сотрудников
        /// </summary>
        public int Count { get { return this.index; } }  
        
        
    }
}
