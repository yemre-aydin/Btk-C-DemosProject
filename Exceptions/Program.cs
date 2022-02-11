using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {

            
            //ExceptionIntro()

            Find();

            try
            {

            }
            catch (RecordNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }

            Console.ReadLine();
        }

        private static void Find()
        {
            List<string> student = new List<string> { "Engin", "Derin", "Salih" };
            if (!student.Contains("Ahmet"))
            {
                throw new RecordNotFoundException();
            }
            else
            {
                Console.WriteLine("Record Found!");
            }
        }

        }
    }
