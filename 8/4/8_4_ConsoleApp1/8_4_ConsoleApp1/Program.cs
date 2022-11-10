using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace _8_4_ConsoleApp1
{
    class Program
    {
        static void AddElemets(XDocument xDoc)
        {
            char key = 'y';

            do
            {
                Console.WriteLine("Введите ФИО");
                string fio = Console.ReadLine();
                Console.WriteLine("Введите Улицу");
                string street = Console.ReadLine();
                Console.WriteLine("Введите номер дома");
                string house = Console.ReadLine();
                Console.WriteLine("Введите номер квартиры");
                string flat = Console.ReadLine();
                Console.WriteLine("Введите номер мобильного");
                string mobile = Console.ReadLine();
                Console.WriteLine("Введите домашний телефон");
                string local = Console.ReadLine();

                XElement root = new XElement("Person",
                new XAttribute("name", fio),
                new XElement("Address",
                new XElement("Street", street),
                new XElement("HuserNumber", house),
                new XElement("FlatNumber", flat)),
                new XElement("Phones",
                new XElement("MobilePhone", mobile),
                new XElement("FlatPhones", local)));
                xDoc.Element("Persons").Add(root);                

                Console.WriteLine("номер уже присутствует, добавить другой ? y/n");
                key = Console.ReadKey(true).KeyChar;

            } while (char.ToLower(key) == 'y');
            xDoc.Save("employees.xml");
        }

        static void Main(string[] args)
        {
            XDocument xDoc = new XDocument(new XElement("Persons"));

            AddElemets(xDoc);

            Console.WriteLine("Элемент(ы) добавлен(ы)!!!");


        }
    }
}
