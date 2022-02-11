using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlServer sqlServer = new SqlServer();
            sqlServer.Add();
            MySqlServer mySqlServer = new MySqlServer();
            mySqlServer.Add();
        }
    }

    class Database
    {
        public virtual void Add()
        {
            Console.WriteLine("aDDED BY dEFAULT");
        }
        public virtual void Delete()
        {
            Console.WriteLine("deleted by default");
        }
    }
    class SqlServer : Database
    {
        public override void Add()
        {
            Console.WriteLine("overrade edildi.");
            //base.Add();
        }
    }
    class MySqlServer : Database
    {

    }
}
