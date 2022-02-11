﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecapDemo2
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomerManager customerManager = new CustomerManager();
            customerManager.Logger = new FileLogger();
            customerManager.Add();
            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        public ILogger Logger { get; set; }

        public void Add()
        {
        
            Logger.Log();
            Console.WriteLine("Customer Added!");
        }
    }

    class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("logged to file!");
        }
    }

class FileLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("File to fil");
    }
}
    class SmsLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Sms to file!");
        }
    }
    interface ILogger
    {
        void Log();
    }

    
}
