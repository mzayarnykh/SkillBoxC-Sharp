using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2MethodConsoleApp3
{
    class Program
    {
        // Метод вывода текста (Enter для продолжения выполнения кода)
        static void Print(string Text)
        {
            Console.WriteLine(Text);
        }

        // Метод конвертрования строки в массив и реверсированный вывод
        static void ToArrayAndInvert(string Text)
        {
            string[] TextToArray = Text.Split(' ');
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Обычный текст");
            Console.ResetColor();
            Console.WriteLine($"{Text}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Реверсированный массив");
            Console.ResetColor();
            Array.Reverse(TextToArray);
            for (int i = 0; i < TextToArray.Length; i++)
            {
                Console.Write($"{TextToArray[i]} ");
            }
        }

        // Метод задержки
        static void Delay()
        {
            Console.ReadKey(true);
        }

        // Основной код
        static void Main(string[] args)
        {
            Print("Задание 2. Перестановка слов в предложении");
            Print("Введите предложение:");
            string entrString = Console.ReadLine();
            ToArrayAndInvert(entrString);
            Delay();
        }


    }
}
