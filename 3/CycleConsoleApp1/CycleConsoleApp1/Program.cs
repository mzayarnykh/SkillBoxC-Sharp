using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine("ЗАДАНИЕ № 1");
            Console.WriteLine("Bведите целое число");
            Console.WriteLine();
            string stringNumber = Console.ReadLine();
            int number = int.Parse(stringNumber);
            int result = number%2;
            string chet = "четное число";
            string nechet = "не четное число";
            if (result == 0)
            {
                Console.WriteLine($"{stringNumber,5} {chet,15}");
            }
            else
            {
                Console.WriteLine($"{stringNumber, 5} {nechet,15}  {"остаток от деления:"} {result}");
            }
            Console.WriteLine("Для продолжения нажмите любую кнопку...");
            Console.ReadKey(true);
            // -----------------------------------------------------------------------------------------
            // -----------------------------------------------------------------------------------------
            // -----------------------------------------------------------------------------------------
            Console.WriteLine("ЗАДАНИЕ № 2");
            Console.WriteLine("Сколько карт у вас на руках ?");
            Console.WriteLine();
            string stringcards = Console.ReadLine();
            byte cards = byte.Parse(stringcards);
            Console.WriteLine("Какие у вас карты?");
            byte cardNumber = 0;
            int totalScore = 0;
            for (byte c = cards; c > 0; c--)
            {
                cardNumber++;
                Console.WriteLine($"Номинал карты {cardNumber}");
                Console.WriteLine();
                string score = Console.ReadLine();
                bool sScore = score.All(char.IsDigit);
                if (sScore && byte.Parse(score)>0 && byte.Parse(score)<11)
                {
                    byte cardScore = byte.Parse(score);
                    totalScore = totalScore + cardScore;
                }
                else
                {
                    switch (score)
                    {
                        case "T":
                            score = "10";
                            break;
                        case "K":
                            score = "10";
                            break;
                        case "Q":
                            score = "10";
                            break;
                        case "V":
                            score = "10";
                            break;
                        default:
                            score = "0";
                            Console.WriteLine("!!! Такой карды в колоде нет, она не будет засчитана !!!");
                            break;
                    }
                    byte cardScore = byte.Parse(score);
                    totalScore = totalScore + cardScore;
                }
            }
            Console.WriteLine($"У Вас вышло {totalScore} очков:");
            Console.ReadKey(true);
            // -----------------------------------------------------------------------------------------
            // -----------------------------------------------------------------------------------------
            // -----------------------------------------------------------------------------------------
            Console.WriteLine("ЗАДАНИЕ № 3");
            Console.WriteLine("Введите число чтобы узнать является ли оно простым или нет");
            Console.WriteLine();
            string simpleNumberString = Console.ReadLine();
            byte simpleNumber = byte.Parse(simpleNumberString);
            byte sum = 1;
            bool pointer = false;
            while ((simpleNumber-1) > sum)
            {
                ;
                sum++;
                int sum1 = simpleNumber%sum;                              
                if (sum1 == 0)
                {
                    pointer = true;
                }
               // Console.WriteLine($"{simpleNumber} делим на {sum} Результат: {sum1}");
                
            }
            if (pointer)
            {
                Console.WriteLine("Число НЕ является простым");
            }
            else
            {
                Console.WriteLine("Число ЯВЛЯЕТСЯ простым");
            }
            
            Console.ReadKey(true);
                        
            // -----------------------------------------------------------------------------------------
            // -----------------------------------------------------------------------------------------
            // -----------------------------------------------------------------------------------------
            Console.WriteLine("ЗАДАНИЕ № 4");
            Console.WriteLine("Наименьший элемент в последовательности");
            Console.WriteLine("Введите длинну последовательности");
            Console.WriteLine();
            string longString = Console.ReadLine();
            byte lon = byte.Parse(longString);
            byte num = 0;
            int minValue = int.MaxValue;
            while (lon>0)
            {
                num++;
                Console.WriteLine($"Введите число №{num}");
                Console.WriteLine();
                string numbersString = Console.ReadLine();
                int numbers = int.Parse(numbersString);
                if (minValue > numbers)
                {
                    minValue = numbers;
                }
                lon--;
            }
            Console.WriteLine($"Минимальное число: {minValue}");
            Console.ReadKey(true);

            
            // -----------------------------------------------------------------------------------------
            // -----------------------------------------------------------------------------------------
            // -----------------------------------------------------------------------------------------

            Console.WriteLine("ЗАДАНИЕ № 5");
            Console.WriteLine("Игра «Угадай число»");
            Console.WriteLine("Введите максимальное число");
            Console.WriteLine();
            string maxNumberString = Console.ReadLine();
            int maxNumber = int.Parse(maxNumberString);
            Random r = new Random();
            int secret = r.Next(0, maxNumber);
           // Console.WriteLine(secret);
            Console.WriteLine("Угадайте число");
            while (true)
            {
                Console.WriteLine();
                string guessString = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(guessString))
                {
                    Console.WriteLine($"Загаданное число было:{secret}");
                    break;
                }
                int guess = int.Parse(guessString);
                if (guess > secret)
                {
                    Console.WriteLine("МЕНЬШЕ");
                }
                if (guess < secret)
                {
                    Console.WriteLine("БОЛЬШЕ");
                }
                if (guess == secret)
                {
                    Console.WriteLine("ПРАВИЛЬНО!!!");
                    break;
                }
            }
            Console.ReadKey(true);

        }
    }
}
