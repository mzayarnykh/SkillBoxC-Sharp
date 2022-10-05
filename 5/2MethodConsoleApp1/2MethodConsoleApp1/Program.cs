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

        // Метод реверсированного вывода массива
        static string[] Reverse(string[] someArray)
        {
            Array.Reverse(someArray);
            return someArray;
        }

        // Метод конвертрования строки в массив и реверсированный вывод
        static string[] SplitText(string Text)
        {
            string[] TextToArray = Text.Split(' ');
            string[] reverseArray = new string[TextToArray.Length];
            for (int i=0; i < TextToArray.Length; i++)
            {
                reverseArray[i] = TextToArray[i];
            }
            Reverse(reverseArray);
            return reverseArray;
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
            Print("Реверсия в массиве:");            
            Console.ResetColor();

            for (int i = 0; i < SplitText(Text).Length; i++)
            {
                Console.Write($"{SplitText(Text)[i]} ");
            }
            Delay();

        }


    }
}
