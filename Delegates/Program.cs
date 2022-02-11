using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void MyDelegate();
    //dönüş değeri olmaya void döndüren ve parametre olmayan operasyonlara delegelik yapıyor
        class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.SendMessager();
            customerManager.ShowAlert();
            MyDelegate myDelegate = customerManager.SendMessager;//elçi görevi görüyor
            myDelegate+=customerManager.ShowAlert;//mesaj ekleme yapılabiliyor 

            myDelegate();//delegeyi çağırınca çalışır kod 

            Console.ReadLine();
        }
    }

    public class CustomerManager
    {
        public void SendMessager()
        {
            Console.WriteLine("Hello");
        }

        public void ShowAlert()
        {
            Console.WriteLine("Be Careful");
        }

    }
}
