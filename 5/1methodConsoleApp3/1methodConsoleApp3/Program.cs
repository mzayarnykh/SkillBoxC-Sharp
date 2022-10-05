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
        static void PrintLines(string enterString)
        {            
            string [] arrayToLines = StringToArray(enterString);
            for (int i = 0; i < arrayToLines.Length; i++)
            {
                Console.WriteLine(arrayToLines[i]);
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
  
            for (int i=0; i < StringToArray(entrString).Length; i++)
            {
                Console.Write($"{StringToArray(entrString)[i]} ");
            }
            Console.WriteLine();
            Delay();

            Console.ForegroundColor = ConsoleColor.Green;
            Print("Вывод построчно");
            Console.ResetColor();
            PrintLines(entrString);
            Delay();
        }


}
}
