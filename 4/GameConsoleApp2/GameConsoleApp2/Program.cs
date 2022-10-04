using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №1: Игра: Жизнь клеток");
            Console.WriteLine("Условие №1: Радиус зоны является не жилым(клетки вымирают)");
            Console.WriteLine("Условие №2: Для размножения клетки нужно (3, 5 или 6) других клеток рядом");
            Console.WriteLine("Условие №4: Клетка умрёт если рядом 1 или 2 другие клетки");
            Console.WriteLine("Условие №5: Клетка умрёт если рядом больше 6 клеток");
            // Ввод и запись данных для размера матрицы
            Console.Write("Введите длинну");
            Console.WriteLine("");
            string rowsString = Console.ReadLine();
            byte rows = byte.Parse(rowsString);
            Console.Write("Введите ширину");
            Console.WriteLine("");
            string linesString = Console.ReadLine();
            byte lines = byte.Parse(linesString);
            
            // Созданите переменной для матрицы, cells для подсчёта клеток 
            // gloCount для подсчёта клеток в матрице endGame триггер для завершения игры
            Random r = new Random();
            int[,] matrix = new int[lines, rows];
            int cells = 0;
            Boolean endGame = false;
            int gloCount = 0;
            int cycleOfLife = 1;

            //Формируем изнчальную матрицу
            Console.WriteLine($"Цикл жизни № {cycleOfLife}");
            cycleOfLife++;
            for (int i = 0; i < lines; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        matrix[i, j] = r.Next(0, 2);
                        matrix[i, 0] = 0;
                        matrix[0, j] = 0;
                        matrix[lines - 1, j] = 0;
                        matrix[i, rows - 1] = 0;
                        if (matrix[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                        Console.Write($"{matrix[i, j]} ");
                    // Помечаем клетки
                        if (matrix[i, j] == 1)
                        {
                            gloCount++;
                            Console.ResetColor();
                        }
                    }
                    
                    Console.WriteLine();
                }
                    Console.Write($"Всего клеток: {gloCount} ");
            gloCount = 0;

            //Запускаем цикл который согласно условиям пересобирает матрицу
            do
            {
                for (int i = 1; i < lines - 1; i++)
                {
                    for (int j = 1; j < rows - 1; j++)
                    {                     
                        // проверка соседних клеток 8 if'ов (по другому не сообразил) (((
                        // 1
                        if (matrix[i + 1, j] == 1)
                        {
                            cells++;
                        }
                        // 2
                        if (matrix[i, j + 1] == 1)
                        {
                            cells++;
                        }
                        // 3
                        if (matrix[i + 1, j + 1] == 1)
                        {
                            cells++;
                        }
                        // 4
                        if (matrix[i - 1, j] == 1)
                        {
                            cells++;
                        }
                        // 5
                        if (matrix[i, j - 1] == 1)
                        {
                            cells++;
                        }
                        // 6
                        if (matrix[i - 1, j - 1] == 1)
                        {
                            cells++;
                        }
                        // 7
                        if (matrix[i + 1, j - 1] == 1)
                        {
                            cells++;
                        }
                        // 8
                        if (matrix[i - 1, j + 1] == 1)
                        {
                            cells++;
                        }
                        // Условия жизни и размножения клеток
                        if (cells <= 2 || cells <= 4 || cells > 6)
                        {
                            matrix[i, j] = 0;
                        }
                        if (cells == 3 || cells == 5 || cells == 6)
                        {
                            matrix[i, j] = 1;
                        }
                        // подсчёт клеток в матрице
                        if (matrix[i, j] == 1)
                        {
                            gloCount++;
                        }
                        cells = 0;
                    }
                                                                            
                }
                Console.WriteLine();
                //Выводим матрицу на экран
                Console.WriteLine($"Цикл жизни № {cycleOfLife}");
                cycleOfLife++;
                for (int k = 0; k < lines; k++)
                {
                    for (int l = 0; l < rows; l++)
                    {
                        if (matrix[k, l] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.Write($"{matrix[k, l]} ");
                        
                        if (gloCount == 0)
                        {
                            endGame = false;
                        }
                        else
                        {
                            endGame = true;
                        }
                        Console.ResetColor();
                    }

                    Console.WriteLine();
                }

                //Если клетки еще остались можем завершить игру преждевременно
                Console.WriteLine($"{gloCount} продолжить игру ? (n - чтобы выйти)");
                string continueGmaeString = Console.ReadLine();
                if (continueGmaeString == "n")
                {
                    break;
                }
                else
                {
                    gloCount = 0;
                }
            }

            while (endGame);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Конец, клетки прожили {cycleOfLife-2} цикл(ов) и вымерли или вы прервали игру.");
            Console.ReadKey(true);
        }
    }
}
