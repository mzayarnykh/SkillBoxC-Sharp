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
            Console.WriteLine("Задание №1: Матрица");
            Console.Write("Введите количество строк");
            Console.WriteLine("");
            string linesString = Console.ReadLine();
            byte lines = byte.Parse(linesString);

            Console.Write("Введите количество столбцов");
            Console.WriteLine("");
            string rowsString = Console.ReadLine();
            byte rows = byte.Parse(rowsString);


            Random r = new Random();
            int[,] matrix = new int[lines,rows];
            int summ = 0;

            for (int i=0; i<lines; i++)
            {
                for (int j=0; j<rows; j++)
                {
                    matrix[i,j] = r.Next(-10, 10);
                    Console.Write($"{matrix[i,j],3} ");
                    summ += matrix[i,j];
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Сумма всех чисел: {summ}");
            Console.WriteLine($"Матрица 2:");

            int[,] matrixB = new int[lines, rows];
            int[,] matrixC = new int[lines, rows];

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    matrixB[i, j] = r.Next(-10, 10);
                    Console.Write($"{matrixB[i, j],3} ");
                    matrixC[i, j] = matrix[i, j] + matrixB[i, j];
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Сумма Матриц 1 и 2:");

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write($"{matrixC[i, j],3} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey(true);

        }
    }
}
