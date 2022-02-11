using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class Product
    {
        //En önemli konu tablolara karşılık gelen bir nesne olması
        public int Id { get; set; }
        //configurasyon eşleşme yapılmalı
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

        public int StockAmount { get; set; }

    }
}
