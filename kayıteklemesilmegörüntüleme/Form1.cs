using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kayıteklemesilmegörüntüleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection Baglan = new SqlConnection("Data Source=LAPTOP\\-9IQ5NO3T\\Initial Catalog=Kutukhane;Integrated Security=True");

        private void verilerigoruntule()
        {
            Baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from kitaplar", Baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read()) {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["kitapad"].ToString());
                ekle.SubItems.Add(oku["yazar"].ToString());
                ekle.SubItems.Add(oku["yayinevi"].ToString());
                ekle.SubItems.Add(oku["sayfasayisi"].ToString());

                
                listView1.Items.Add(ekle);


                    
            }
            Baglan.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            verilerigoruntule();
        }
    }
}
