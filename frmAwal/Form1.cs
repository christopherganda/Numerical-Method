using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmAwal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Interpolasi")
            {
                
                Form inter = new Pilihan.frmInterpolasi();
                this.Hide();
                inter.Show();
            }
            else if (comboBox1.Text == "Regresi")
            {
                Form reg = new Pilihan.frmRegresi();
                this.Hide();
                reg.Show();
            }
            else if (comboBox1.Text == "Turunan")
            {
                Form tur = new Pilihan.frmTurunan();
                this.Hide();
                tur.Show();
            }
            else if (comboBox1.Text == "Integral Trapesium")
            {
                Form tur = new Pilihan.frmIntegralTrapesium();
                this.Hide();
                tur.Show();
            }
            else if (comboBox1.Text == "Metode Simson")
            {
                Form tur = new Pilihan.frmMetodeSimson();
                this.Hide();
                tur.Show();
            }
            else if (comboBox1.Text == "Metode Euler")
            {
                Form euler = new Pilihan.frmMetodeEuler();
                this.Hide();
                euler.Show();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
               Application.ExitThread();
        }
    }
}
