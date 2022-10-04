using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1methodConsoleApp3
{
    class Program
    {
        // Метод вывода текста (Enter для продолжения выполнения кода)
        static void Print(string Text)
        {
            Console.WriteLine(Text);
        }
        // Метод задержки
        static void Delay()
        {
            Console.ReadKey(true);
        }
        // Метод вывода массива построчно
        static string[] PrintInLines(string[] Args)
        {
            string[] t = new string[Args.Length];
            for (int i = 0; i < Args.Length; i++)
            {
                t[i] = Args[i];
                Console.WriteLine(Args[i]);
            }
            return t;
        }
        // Основной код
        static void Main(string[] args)
        {
            Print("Задание 1. Метод разделения строки на слова");
            Print("Введите предложение:");
            string entrString = Console.ReadLine();
            string[] sentenceString = entrString.Split(' ');
            Console.ForegroundColor = ConsoleColor.Green;
            Print("Вывод целиком");
            Console.ResetColor();
            Print(entrString);
            Delay();
            Console.ForegroundColor = ConsoleColor.Green;
            Print("Вывод построчно");
            Console.ResetColor();
            PrintInLines(sentenceString);
            Delay();
        }


}
}
