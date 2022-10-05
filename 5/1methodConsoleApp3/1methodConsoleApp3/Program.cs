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

        // Метод разделение строки на массив
        static string[] StringToArray(string stringToArray)
        {
            string[] stringSplit = stringToArray.Split(' ');
            return stringSplit;
        }

        // Метод вывода массива построчно
        static void PrintLines(string[] enterString)
        {            
            for (int i = 0; i < enterString.Length; i++)
            {
                Console.WriteLine(enterString[i]);
            }
        }

        // Основной код
        static void Main(string[] args)
        {
            Print("Задание 1. Метод разделения строки на слова");
            Print("Введите предложение:");
            string entrString = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Print("Вывод целиком");
            Console.ResetColor();
            Print(entrString);
            string[] strToArray = StringToArray(entrString);
            Delay();

            Console.ForegroundColor = ConsoleColor.Green;
            Print("Вывод построчно");
            Console.ResetColor();
            PrintLines(strToArray);
            Delay();
        }


}
}
