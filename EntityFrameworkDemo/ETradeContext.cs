using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public  class ETradeContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        //veritabanı ile eşleşme burada yapılıyor
        //tablolarda producs ı arıyor eşleşme oluşuyor
        //bunu yaptıktan sonra kod yazabiliriz artık



    }
}
