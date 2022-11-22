using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Метод WriteLine:");

            Console.WriteLine("Hello World!!!");

            Console.ReadKey();

            Console.WriteLine("Метод Write:");
            Console.Write("Hello");
            Console.Write(" World");
            Console.Write(" !!!");

            Console.ReadLine();

        }
    }
}
