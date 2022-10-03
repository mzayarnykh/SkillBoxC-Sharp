using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            String fullName = "Иванов А.М.";
            Byte correntAge = 30;
            String studentMail = "alex_ivanov@mail.ru";
            float codeScore = 8.3F;
            float mathScore = 5.3F;
            float physicsScore = 7.8F;
            string titleName = "Ф.И.О.:";
            string titleAge = "Возраст:";
            string titleMail = "Email:";
            string titleCodeScore = "Баллы по программированию:";
            string titleMathScore = "Баллы по математике:";
            string titlePhysicsScore = "Баллы по физике:";
            //String newPattern = ("Ф.И.О.: {0} \nВозраст: {1} \nEmail: {2} \nБаллы по программированию: {3} \nБаллы по математике: {4} \nБаллы по физике:{5}\n");
            //Console.WriteLine(newPattern,
            //                  fullName,
            //                  correntAge,
            //                  studentMail,
            //                  codeScore,
            //                  mathScore,
            //                  physicsScore
            //                  );
            Console.WriteLine($"{titleName,26} {fullName,19}");
            Console.WriteLine($"{titleAge,26} {correntAge,19}");
            Console.WriteLine($"{titleMail,26} {studentMail,19}");
            Console.WriteLine($"{titleCodeScore,26} {codeScore,19}");
            Console.WriteLine($"{titleMathScore,26} {mathScore,19}");
            Console.WriteLine($"{titlePhysicsScore,26} {physicsScore,19}");
            Console.WriteLine("Чтобы подсчитать сумму балов и средний бал нажмите любую кнопку.");
            Console.ReadKey(true);
            float allScores = (codeScore + mathScore + physicsScore);
            float midScore = (allScores / 3);
            string formatedMidScore = midScore.ToString("#.#");
            string formatedAllScore = allScores.ToString("#.#");
            string titleMidScore ="Средний бал по всем предметам:";
            string titleAllScore = "Сумма балов по всем предметам:";
            Console.WriteLine($"{titleAllScore,30} {formatedAllScore,15}");
            Console.WriteLine($"{titleMidScore,30} {formatedMidScore,15}");
            //Console.WriteLine("Средний бал по всем предметам: {0:0.0}", midScore);
            Console.ReadKey(true);
        }

    }
}