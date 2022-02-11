using Microsoft.AspNet.SignalR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo
{
    public class ProductDal
    {
        //veri tabanından veri çekme ekleme, silme ve güncelleme için kullanılacak
        SqlConnection _connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=ETrade;Trusted_Connection=true");

        public List<Product> GetAll()//burada ürünler listelenecek get all ile
        {
            //ilk operasyon sql database e bağlanmak
            //veri tabbanı bağlantı konumu
            //uzaktaki bir veri tabanına bağlanmak için true ı false yap ve uid=engin;password=123 gibi kod yazılacak
            //bağlantı nesnesi oluşturuldu aşağıda da bağlantı açılacak
            ConnectionControl();
            //veritabanı ile iletişim kuryoruz sql command sınıfından yararlanıyoruz
            SqlCommand command = new SqlCommand("Select*from Products",_connection);

            SqlDataReader reader = command.ExecuteReader();
            //Buradaki komutu listeye çevirmek gerekiyor

            List<Product> products = new List<Product>();

            while (reader.Read())
	        {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                };
                products.Add(product);
            }
            reader.Close();
            _connection.Close();

            return products;
        }

        public DataTable GetAll2()//burada ürünler listelenecek get all ile
        {
            //ilk operasyon sql database e bağlanmak
            //veri tabbanı bağlantı konumu
            //uzaktaki bir veri tabanına bağlanmak için true ı false yap ve uid=engin;password=123 gibi kod yazılacak
            //bağlantı nesnesi oluşturuldu aşağıda da bağlantı açılacak
            ConnectionControl();
            //veritabanı ile iletişim kuryoruz sql command sınıfından yararlanıyoruz
            SqlCommand command2 = new SqlCommand("Select*from Products", _connection);

            SqlDataReader reader2 = command2.ExecuteReader();
            //Buradaki komutu listeye çevirmek gerekiyor

            DataTable dataTable = new DataTable();
            dataTable.Load(reader2);//datatable ı reader ile doldurduk
            reader2.Close();
            _connection.Close();

            return dataTable;
        }

        private void ConnectionControl()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {//bağlantı açııken bir daha açmaya çalışırsak sıkıntı çıkar o yüzden if koşulu kullanıyoruz
                _connection.Open();
            }
        }

        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("ınsert into Products values(@name,@unitPrice,@stockAmount)", _connection);

            command.Parameters.AddWithValue("@name", product.Name);
            //sql enjection en sık yapılan saldırı yöntemleri
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);

            //command.ExecuteNonQuery();
            //etkilenen kayıt sayısını döndürür
            //kayıt olup olmadığını kontrol etmek için kullanılır
            
            _connection.Close();




        }
        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Products set Name=@name,UnitPrice=@unitPrice,StockAmount=@stockAmount where Id=@id)", _connection);

            command.Parameters.AddWithValue("@name", product.Name);
            //sql enjection en sık yapılan saldırı yöntemleri
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.Parameters.AddWithValue("@id", product.Id);

            //command.ExecuteNonQuery();
            //etkilenen kayıt sayısını döndürür
            //kayıt olup olmadığını kontrol etmek için kullanılır

            _connection.Close();




        }

    }
}
