using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace _8_1_ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Вывод листа на экран
        /// </summary>
        /// <param name="args"></param>
        static public void PrintList(List<int> args)
        {
            List<int> showList = new List<int>(args);
            for (int i = 0; i < showList.Count; i++) Console.Write($"{showList[i]} ");
        }

        /// <summary>
        /// Заполнение листа случайными числами
        /// </summary>
        /// <param name="args"></param>
        static List<int> CreateList()
        {
            List<int> list = new List<int>();
            Random n = new Random();

            for (int i = 0; i < 100; i++)
            {
                list.Add(n.Next(0, 100));
            }
            return list;
        }

        /// <summary>
        /// Удаляем значения по заданным условиям
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static List<int> UpdateList(List<int> args)
        {
            List<int> list = new List<int>(args);
            for (int i = 0; i < list.Count; i++)

                if (list[i] > 25 && list[i] < 50)
                {
                    list.RemoveAt(i);
                }
            return list;
        }

        /// <summary>
        /// Пауза, enter для продолжения
        /// </summary>
        static public void Pause()
        {
            Console.WriteLine("");
            Console.WriteLine("enter for continue");
            Console.ReadKey(true);
        }



        static void Main(string[] args)
        {
            List<int> list = CreateList();

            PrintList(list);

            Pause();

            List<int> newlist = UpdateList(list);

            PrintList(newlist);
        }
    }
}
