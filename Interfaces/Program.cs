﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            //IntarfacesIntro();
            //bir interface hiç bir zaman new lenemez .
            //IPerson person = new Customer();
            //IPerson person = new Student();
            //şeklinde kullanılabilir.
            CustomerManager customerManger = new CustomerManager();
            customerManger.Add(new SqlServerCustomerDal());//new den sonra sql veya oracle seçebiliriz
            // interfaceler katmanlar arası geçişte kullanılıyr
            Console.ReadLine();
            ICustomerDal[] customerDals = new ICustomerDal[3]
            {
                new SqlServerCustomerDal(),
                new OracleServerCustomerDal(),
                new MySqlServerCustomerDal(),

        };
            foreach (var customerDal in customerDals)
            {
                customerDal.Add();
            }
        }

        private static void IntarfacesIntro()
        {

            PersonManager manager = new PersonManager();
            manager.Add(new Customer
            {
                Id = 1,
                FirstName = "engin",
                LastName = "Demiroğ",
                Address = "Ankara"
            });
            Student student = new Student
            {
                Id = 2,
                FirstName = "derin",
                LastName = "demiroğ",
                Departmant = "mecatronics Engineering"
            };
        }
    }

    interface IPerson
    {
         int Id { get; set; }
        string FirstName{ get; set; }
        string LastName { get; set; }

    }

    class Customer : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
    class Student : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Departmant { get; set; }
    }
    class PersonManager
    {
        public void Add(IPerson person)
        {
            Console.WriteLine(person.FirstName);
        }
    }

}
           