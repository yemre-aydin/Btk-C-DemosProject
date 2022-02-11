using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { Id=1,LastName="Demiroğ",Age=32};
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
            Console.ReadLine();

        }
    }

    [ToTable("Customers")]//dinamik sorgulamalarda çok kullanılır
    class Customer
    {
        public int Id { get; set; }
        
        //Customer i kullanacak kişilerin firstname i girmesi zorunlu olsun istiyorusak 
        [RequiredProperty]//kullanıyoruz
        //iş kurallarına örnek
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
    }

    class CustomerDal
    {
        [Obsolete("Dont use Add,instead use AddNew Method!")]//bu metotun yenisi yazıldığın da yazılımcıları uyarıyor yenisini kullan diyor
        public void Add(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!",customer.Id,customer.FirstName,customer.LastName,customer.Age);     
        }
        public void AddNew(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
    }

    class RequiredPropertyAttribute : Attribute//attribute sınıfların sonuna attribute yazılır
    {

    }

    class ToTableAttribute : Attribute
    {
        private string _tableName;
        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }
}
