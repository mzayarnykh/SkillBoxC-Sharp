using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConsoleApp1
{
    struct Worker
    {
        #region Конструкторы

        public Worker(
            string ID,
            string HireDate, 
            string Fio,
            string Age,
            string Hight,
            string BirthDate,
            string OrigRigion)
        {
            this.iD = ID;
            this.hireDate = HireDate;
            this.fio = Fio;
            this.age = Age;
            this.hight = Hight;
            this.birthDate = BirthDate;
            this.origRigion = OrigRigion;            
        }

        #endregion

        #region Методы

        public string Print()
        {
            return $"" +
                $"{this.iD,5} " +
                $"{this.hireDate,22} " +
                $"{this.fio,30} " +
                $"{this.age,7} " +
                $"{this.hight,4}" +
                $"{this.birthDate,15}" +
                $"{this.origRigion,15}";
        }

        #endregion

        #region Свойства


        public string ID { get { return this.iD; } set { this.iD = value; } }
        public string Fio { get { return this.fio; } set { this.fio = value; } }
        public string HireDate { get { return this.hireDate; } set { this.hireDate = value; } }
        public string Age { get { return this.age; } set { this.age = value; } }
        public string Hight { get { return this.hight; } set { this.hight = value; } }
        public string BirthDate { get { return this.birthDate; } set { this.birthDate = value; } }
        public string OrigRigion { get { return this.origRigion; } set { this.origRigion = value; } }
        
        #endregion

        #region Поля

        /// <summary>
        /// Поле "ID"
        /// </summary>
        private string iD;

        /// <summary>
        /// Поле "Дата записи"
        /// </summary>
        private string hireDate;

        /// <summary>
        /// Поле "ФИО"
        /// </summary>
        private string fio;

        /// <summary>
        /// Поле "Возраст"
        /// </summary>
        private string age;

        /// <summary>
        /// Поле "Рост"
        /// </summary>
        private string hight;

        /// <summary>
        /// Поле "День рождения"
        /// </summary>
        private string birthDate;

        /// <summary>
        /// Поле "Город"
        /// </summary>
        private string origRigion;


        #endregion
    }
}
