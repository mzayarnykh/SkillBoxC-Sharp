using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_homework_wpf
{
    public class Person
    {
        //Конструкторы

        public Person()
        {

        }

        public Person(string LastName, string FirstName, string FatherName, string Mobile, string Passport, string Comment)
        {
            this.lastName = LastName;
            this.firstName = FirstName;
            this.fatherName = FatherName;
            this.mobile = Mobile;
            this.passport = Passport;
            this.comment = Comment;
        }

        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }
        public string LastName { get { return this.lastName; } set { this.lastName = value; } }
        public string FatherName { get { return this.fatherName; } set { this.fatherName = value; } }
        public string Mobile { get { return this.mobile; } set { this.mobile = value; } }
        public string Passport { get { return this.passport; } set { this.passport = value; } }
        public string Comment { get { return this.comment; } set { this.comment = value; } }

        private string firstName;
        private string lastName;
        private string fatherName;
        private string mobile;
        private string passport;
        private string comment;

    }
}

