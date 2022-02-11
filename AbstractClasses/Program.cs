using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Oracle();
            database.Delete();
            Database database1 = new SqlServer();
            database1.Delete();
        }
    }

    abstract class Database
    {
        public void Add()
        {
            Console.Write("Add bt default");
        }
        public abstract void Delete();
    }

    class SqlServer : Database
    {
        public override void Delete()
        {
            Console.WriteLine("deleted by sql");
        }
    }
    class Oracle : Database
    {
        public override void Delete()
        {
            Console.WriteLine("deleted by Oracle");

        }
    }
}
