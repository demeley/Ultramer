using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ultramer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void yeniAlacakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yeni_Alacak alacak_ekle = new Yeni_Alacak();
            alacak_ekle.Show();
            alacak_ekle.MdiParent = this;
        }

        private void alacakListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alacak_Listesi alacak_list = new Alacak_Listesi();
            alacak_list.Show();
            alacak_list.MdiParent = this;
        }
    }
}
