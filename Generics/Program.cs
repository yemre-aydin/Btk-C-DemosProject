using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Program
    {
        static void Main(string[] args)
        {

            Utilities utilities = new Utilities();
            List<string> result = utilities.BuildList<string>("Ankara","İzmir","Adana");
            //string bir list oluştur dedik.
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            List<Customer> result2 = utilities.BuildList<Customer>(new Customer { FirstName="engin"}, new Customer());
            Console.ReadLine();

        }
    }

    class Utilities
    {
        public List<T> BuildList<T>(params T[] items)
        {
            return new List<T>(items);
        }
    }
    class Product
    {

    }
    interface IProductDal:IRepository<Product> 
    {
        
    }
    class Customer
    {

        public string FirstName { get; set; }

    }
    interface IStudentDal : IRepository<Student>//student e kızmadı çünkü referans noktası
    {

    }
    class Student
    {

    }
    interface ICustomerDal:IRepository<Customer>
    {
        void Custom();
        
    }
    

    interface IRepository<T> where T : class,new()
        //new () yazarak ta referans tip olmalı ayrıca new lenebilir olmalı diyoruz ve new her zaman sona konulmalı
        // where T: class yazarak referans tipi belirtebiliyoruz
        //özel koşul koayabiliyoruz generics lere belirli bir kısıtlamalr getirebiliyoruz
    {
        //repository genellikle veritabanı için kullanılır
        //T TYpe den gelir
        List<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Update(T entity);

        void Delete(T entity);
    }

    class ProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
