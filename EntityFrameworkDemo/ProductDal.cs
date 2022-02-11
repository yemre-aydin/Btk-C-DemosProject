using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            //using  bellek için pahalı çokyer kaplayan bir nesne
            //işi biten nesneleri çöpe atıyor using de blog bitti anda çöpe atmasını beklemeden d
            //işini bitiriyor

            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.ToList();
                //çağırıldığında listeye çevirecek
            }
        }
        public List<Product> GetByName(string key)
        {
            //getByname ile Where den sonrasını bölüp method içine alabiliyoruz
            //böylece getall deyip uzun uzun yazmak yerine getbyname methodunu kullanaibliriz

            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p=>p.Name.Contains(key)).ToList();
                //çağırıldığında listeye çevirecek
            }
        }
        //fiyat kontorlü için bir method
        public List<Product> GetByUnitPrice(decimal price)
        {
            
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice>=price).ToList();
                //çağırıldığında listeye çevirecek
            }
        }
        public List<Product> GetByUnitPrice(decimal min,decimal max)
        {
            
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice>=min &&p.UnitPrice<=max).ToList();
                //çağırıldığında listeye çevirecek
            }
        }

        public Product GetById(int id)
        {
            
            using (ETradeContext context = new ETradeContext())
            {
                var result = context.Products.SingleOrDefault(p => p.Id == id);

                return result;

            }
        }


        public void Add(Product product)
        {
            using(ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Added;//ben yeni ürün ekledim anlamında
                context.SaveChanges();//yaptığımız işlemleri vertabanına yaz demek
                //kaydet
                

            }
        }
        public void Update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity= context.Entry(product);
                entity.State=EntityState.Modified;
                context.SaveChanges();//yaptığımız işlemleri vertabanına yaz demek
                                      //kaydet


            }
        }
        public void Delate(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();//yaptığımız işlemleri vertabanına yaz,sil ,güncelle demek
                                      //kaydet


            }
        }

    }
}
