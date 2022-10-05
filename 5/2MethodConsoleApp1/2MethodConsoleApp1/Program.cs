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

        // Метод конвертрования строки в массив
        static string[] SplitText(string Text)
        {
            string[] TextToArray = Text.Split(' ');
            return TextToArray;
        }

        // Метод получает массив реверсирует и собирает в строку
        static string Reverse(string someArray)
        {
            string [] splittedArray = SplitText(someArray);
            Array.Reverse(splittedArray);
            string reverseDone = string.Join(" ", splittedArray);
            return reverseDone;
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
            string Text = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Print("Было введено:");
            Console.ResetColor();
            Print(Text);

            Console.ForegroundColor = ConsoleColor.Green;
            Print("Реверсия:");            
            Console.ResetColor();
            string reversedText = Reverse(Text);
            Print(reversedText);
            Delay();

        }


    }
}
