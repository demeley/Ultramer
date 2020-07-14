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
    public partial class Alacak_Listesi : Form
    {
        public Alacak_Listesi()
        {
            InitializeComponent();
        }

        string strBaglanti = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=|DataDirectory|\veritabani.mdb;Persist Security Info=False;";
        public static int secilen_id;
        OleDbConnection baglanti;

        private void Alacak_Listesi_Load(object sender, EventArgs e)
        {
            string anahtarkelime = "";
            alacak_list(anahtarkelime);
        }

        private void alacak_list(string anahtarkelime)
        {
            string SQL = "";
            baglanti = new OleDbConnection(strBaglanti);
            if (anahtarkelime == "")
            {
                SQL = "select *from alacak";
            }
            else if (anahtarkelime != "")

            {
                SQL = "select * from alacak WHERE ad like'%" + anahtarkelime + "%' or soyad like'%" + anahtarkelime + "%' or telefon like'%" + anahtarkelime + "%' ";
            }
            OleDbDataAdapter veriler = new OleDbDataAdapter(SQL, baglanti);
            DataSet veriseti = new DataSet();
            ListViewItem itm = new ListViewItem();
            listView1.Clear();
            string[] str = new string[6];
            baglanti.Open();
            veriler.Fill(veriseti);
            if (veriseti.Tables[0].Rows.Count != 0)
            {

                listView1.Columns.Add("ID", 0, HorizontalAlignment.Center);
                listView1.Columns.Add("AD", 100, HorizontalAlignment.Center);
                listView1.Columns.Add("SOYAD", 100, HorizontalAlignment.Center);
                listView1.Columns.Add("ADRES", 300, HorizontalAlignment.Center);
                listView1.Columns.Add("TELEFON", 90, HorizontalAlignment.Center);
                listView1.Columns.Add("BORÇ", 90, HorizontalAlignment.Center);

                for (int i = 0; i < veriseti.Tables[0].Rows.Count; i++)
                {
                    str[0] = veriseti.Tables[0].Rows[i]["id"].ToString();
                    str[1] = veriseti.Tables[0].Rows[i]["ad"].ToString();
                    str[2] = veriseti.Tables[0].Rows[i]["soyad"].ToString();
                    str[3] = veriseti.Tables[0].Rows[i]["adres"].ToString();
                    str[4] = veriseti.Tables[0].Rows[i]["telefon"].ToString();
                    str[5] = veriseti.Tables[0].Rows[i]["borc"].ToString();
                    itm = new ListViewItem(str);
                    listView1.Items.Add(itm);
                }
            }
            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string anahtarkelime = textBox1.Text;
            alacak_list(anahtarkelime);
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string anahtarkelime = "";
            if (listView1.SelectedItems.Count != 0)
            {
                int id = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                baglanti = new OleDbConnection(strBaglanti);
                OleDbCommand komut = new OleDbCommand("DELETE FROM alacak WHERE id=" + id, baglanti);
                DialogResult sonuc = MessageBox.Show("Seçilen Veriyi Silmek İstiyor Musunuz?", "Uyarı!!", MessageBoxButtons.YesNo);
                if (sonuc == DialogResult.Yes)
                {
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    textBox1.Text = "";
                    alacak_list(anahtarkelime);
                }
            }
        }

        private void gÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                secilen_id = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                Alacak_Guncelle guncelle = new Alacak_Guncelle();
                guncelle.ShowDialog();
                this.Hide();
            }
        } 

        
    }
}
