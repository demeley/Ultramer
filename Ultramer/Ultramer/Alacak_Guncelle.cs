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
    public partial class Alacak_Guncelle : Form
    {
        public Alacak_Guncelle()
        {
            InitializeComponent();
        }

        int guncel_id = Alacak_Listesi.secilen_id;

        string strBaglanti = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=|DataDirectory|\veritabani.mdb;Persist Security Info=False;";
        OleDbConnection baglanti;
        OleDbDataAdapter veriliste;
        DataSet veriler = new DataSet();

        private void Alacak_Guncelle_Load(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection(strBaglanti);
            string SQL = "SELECT * FROM alacak where id=" + guncel_id;
            veriliste = new OleDbDataAdapter(SQL, baglanti);
            veriliste.Fill(veriler);
            int kayitsayisi = veriler.Tables[0].Rows.Count;
            if (kayitsayisi != 0)
            {
                textBox1.Text = veriler.Tables[0].Rows[0]["ad"].ToString();
                textBox2.Text = veriler.Tables[0].Rows[0]["soyad"].ToString();
                textBox5.Text = veriler.Tables[0].Rows[0]["adres"].ToString();
                textBox6.Text = veriler.Tables[0].Rows[0]["telefon"].ToString();
                textBox7.Text = veriler.Tables[0].Rows[0]["borc"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SQL = "update alacak set ad=@ad_deger,soyad=@soyad_deger,adres=@adres_deger,telefon=@telefon_deger,borc=@borc_deger where id=" + guncel_id;
            OleDbConnection baglanti = new OleDbConnection(strBaglanti);
            OleDbCommand komut = new OleDbCommand(SQL, baglanti);

            komut.Parameters.Add(new OleDbParameter("@ad_deger", OleDbType.VarChar, 100));
            komut.Parameters["@ad_deger"].Value = textBox1.Text;

            komut.Parameters.Add(new OleDbParameter("@soyad_deger", OleDbType.VarChar, 300));
            komut.Parameters["@soyad_deger"].Value = textBox2.Text;

            komut.Parameters.Add(new OleDbParameter("@adres_deger", OleDbType.VarChar, 100));
            komut.Parameters["@adres_deger"].Value = textBox5.Text;

            komut.Parameters.Add(new OleDbParameter("@telefon_deger", OleDbType.VarChar, 300));
            komut.Parameters["@telefon_deger"].Value = textBox6.Text;

            komut.Parameters.Add(new OleDbParameter("@borc_deger", OleDbType.VarChar, 100));
            komut.Parameters["@borc_deger"].Value = textBox7.Text;

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            label8.Text="Veriler Başarıyla Güncellendi";
            textBox1.Text = ""; textBox2.Text = ""; textBox5.Text = ""; textBox6.Text = ""; textBox7.Text = "";
        }

        private void Alacak_Guncelle_FormClosing(object sender, FormClosingEventArgs e)
        {
            Alacak_Listesi alacak_listesi = new Alacak_Listesi();
            alacak_listesi.Show();
            Visible = false;
        }
    }
}
