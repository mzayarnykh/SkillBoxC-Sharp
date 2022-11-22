using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace _11_homework_wpf
{
    class Methods
    {

        // метод пересоздает файл
        public static void CreateFile(string database)
        {
            File.Create(database).Dispose();
        }

        // метод добавления роли записи
        public static void WhoIs(string who)
        {
            using (StreamWriter sw = new StreamWriter("account.txt", true))
            {
                sw.WriteLine(who);
            }
        }

        //Авторизация
        public bool UserAuth(string usr, string pwd)
        {
            bool who;

            if (usr == "admin" && pwd == "admin")
            {
                WhoIs("1");
                who = true;
            }

            else if (usr == "manager" && pwd == "manager")
            {
                WhoIs("2");
                who = true;

            }

            else
            {
                WhoIs("0");
                who = false;
            }
            return who;
        }

        public static void SerializePersonList(List<Person> СoncretePersonList, string Path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            Stream fStream = new FileStream(Path, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fStream, СoncretePersonList);
            fStream.Close();
        }

        public static List<Person> DeserializePersonList(string Path)
        {
            List<Person> tempPersonCol = new List<Person>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
            Stream fStream = new FileStream(Path, FileMode.Open, FileAccess.Read);
            tempPersonCol = xmlSerializer.Deserialize(fStream) as List<Person>;
            fStream.Close();
            return tempPersonCol;
        }

        public static void AddElement(string cm, string ln, string fn, string fna, string mb, string pa)
        {
            List<Person> list = DeserializePersonList("employees.xml");
            list.Add(new Person(ln, fn, fna, mb, pa, cm));
            SerializePersonList(list, "employees.xml");
            list = DeserializePersonList("employees.xml");
        }

        public static void EditElement(string cm, string id, string ln, string fn, string fna, string mb, string pa)
        {
            //Редактирование ListView
            string path = "employees.xml";
            int idToEdit = int.Parse(id);
            List<Person> list = DeserializePersonList(path);



            if (list[idToEdit].LastName != ln)
            {
                cm = cm + " Фамилия ";
            }

            if (list[idToEdit].FirstName != fn)
            {
                cm = cm + " Имя ";
            }

            if (list[idToEdit].FatherName != fna)
            {
                cm = cm + " Отчество ";
            }

            if (list[idToEdit].Mobile != mb)
            {
                cm = cm + " Мобильный ";
            }

            if (list[idToEdit].Passport != pa)
            {
                cm = cm + " Пасспорт";
            }
            cm = cm + "\n";

            list[idToEdit].LastName = ln;
            list[idToEdit].FirstName = fn;
            list[idToEdit].FatherName = fna;
            list[idToEdit].Mobile = mb;
            list[idToEdit].Passport = pa;
            list[idToEdit].Comment = list[idToEdit].Comment + cm;
            SerializePersonList(list, path);
        }

        public static void DeleteElement(string id)
        {
            string path = "employees.xml";
            //удаление элемента
            List<Person> list = DeserializePersonList(path);
            int idToDelete = int.Parse(id);
            list.RemoveAt(idToDelete);
            SerializePersonList(list, path);
            //повторное заполнение ListView
            list = DeserializePersonList(path);
        }
    }
}//listView.ItemsSource = list;
