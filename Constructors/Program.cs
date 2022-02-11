using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(10);
            customerManager.Add();
            //Product product = new Product(20);
            EmployeeManager employeeManager = new EmployeeManager(new DatabaseLogger());
            employeeManager.Add();
            Console.ReadLine();

        }
    }

    class CustomerManager
    {
        private int _count = 15;
        public CustomerManager(int count)
        {
            _count = count;

        }
        public void List()
        {
            Console.WriteLine("Listed {0} items", _count);
        }
        public void Add()
        {
            Console.WriteLine("added!");
        }
    }
    interface ILogger
    {
        void Log();
    }
    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("database logged");
        }
    }
    class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("file logger");
        }
    }
    class EmployeeManager
    {
        public ILogger Logger { get; set; }
        private ILogger _logger;
        public EmployeeManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Add()
        {
            Logger.Log();
            Console.WriteLine("Added!");
        }

        class Product
        {

            private int _Id;

            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
