using EntityFrameworkDemo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();//veritabanını güncellemeyi sağlayan method
            //productdal daki getall metodunu çağırdık.
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }
        private void SearchProducts(string key)
        {
            var result= _productDal.GetByName(key);
            dgwProducts.DataSource = result;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                //ıd otomatik geliyor
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxunitPrice.Text),
                StockAmount = Convert.ToInt32(tbxstockAmount.Text)
            });
            LoadProducts();
            MessageBox.Show("Product Added!");
        }

        private void dgwProduct_CellContentClink(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("CellContent");
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts (tbxSearch.Text);
        }
    }
}
