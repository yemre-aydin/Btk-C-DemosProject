
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // ArrayList();
            List<string> cities = new List<string>();
            cities.Add("Ankara");
            cities.Add("istanbul");
            Dictionary<string,string> dictionary= new Dictionary<string, string>();
            dictionary.Add("book", "kitap");
            dictionary.Add("table", "Masa");
            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { Id = 1, Name = "Engin" });
            customers.Add(new Customer { Id = 2, Name = "Derin" });

            List<Customer> customers2 = new List<Customer> {
            new Customer { Id = 1, Name = "Engin" },
            new Customer { Id = 2, Name = "Derin" }
                };
            var count = customers.Count;
            var customer2 = new Customer
            {
                Id = 3,
                Name = "Salih"
            };
            customers.Add(customer2);
            customers.AddRange(new Customer[2]
            {
                new Customer{ Id=4,Name="Ali"},
                new Customer{Id=5,Name="Ayşe"}
            });

            


            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Name);
            }

            Console.ReadLine();

            

        }

        private static void ArrayList()
        {
            ArrayList cities = new ArrayList();
            cities.Add("Ankara");
            cities.Add("Adana");
            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }
            cities.Add("İstanbul");
            Console.WriteLine(cities[2]);


        }

        class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
