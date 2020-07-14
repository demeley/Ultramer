using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Ultramer
{
    public partial class Yeni_Alacak : Form
    {
        public Yeni_Alacak()
        {
            InitializeComponent();
        }

        string strBaglanti = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=|DataDirectory|\veritabani.mdb;Persist Security Info=False;";
        OleDbConnection baglanti;
        OleDbCommand komut;
        string cins="";

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="" && textBox2.Text!="" &&  textBox5.Text!="" && textBox6.Text!="" && textBox7.Text!="" && textBox3.Text != "")
            {
                string SQL = "insert into alacak(ad,soyad,adres,telefon,tarih,cins,aciklama,borc) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Text + "','" + cins + "','" + textBox3.Text + "','" + textBox7.Text + "')";
                baglanti = new OleDbConnection(strBaglanti);
                komut = new OleDbCommand(SQL, baglanti);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                label8.Text = "Müşteri Başarıyla Eklendi";
                textBox1.Text = ""; textBox2.Text = ""; textBox5.Text = ""; textBox3.Text = ""; textBox6.Text = ""; textBox7.Text = ""; dateTimePicker1.Value = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız. Lütfen Tüm Alanları Eksiksiz Doldurunuz..");
                textBox1.Text = ""; textBox2.Text = ""; textBox5.Text = ""; textBox6.Text = ""; textBox3.Text = ""; textBox7.Text = ""; dateTimePicker1.Value = DateTime.Now;
            }
            
        }

        private void Yeni_Alacak_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }
    }
}
