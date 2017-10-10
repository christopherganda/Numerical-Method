using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmAwal.Pilihan
{
    public partial class frmIntegralTrapesium : Form
    {
        double batasBawah, batasAtas, p, q, r, s, segment, nilaiEksak, trueError, absError;
        public frmIntegralTrapesium()
        {
            InitializeComponent();
        }

        private void frmIntegralTrapesium_Load(object sender, EventArgs e)
        {

        }
        public double  integral(double a)
        {
            return p * (Math.Log(q) - Math.Log(q - r * a)) - s * a;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIntegralTrapesium_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = new Form1();
            frm.Show();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var cekKosong = this.Controls.OfType<TextBox>().Where((txt) => txt.Text.Length == 0 && txt.Visible == true);
            if (cekKosong.Any())
                MessageBox.Show("Harap masukkan semua pasangan dan pangkat yang ada!");
            else
            {
                double a, b;
                double hasil = 0;
                List<double> x = new List<double>();
                List<double> y = new List<double>();
                List<double> col = new List<double>();
                batasBawah = double.Parse(textBox1.Text);
                batasAtas = double.Parse(textBox2.Text);
                p = double.Parse(textBox3.Text);
                q = double.Parse(textBox4.Text);
                r = double.Parse(textBox5.Text);
                s = double.Parse(textBox6.Text);
                segment = double.Parse(textBox7.Text);
                dataGridView1.Columns[2].HeaderText = "Segmen 1-" + segment.ToString();
                a = p * ((r * batasAtas + Math.Log(q - r * batasAtas) * (q - r * batasAtas) - q) / r + Math.Log(q) * batasAtas) - ((s / 2) * batasAtas * batasAtas);
                b = p * ((r * batasBawah + Math.Log(q - r * batasBawah) * (q - r * batasBawah) - q) / r + Math.Log(q) * batasBawah) - ((s / 2) * batasBawah * batasBawah);
                nilaiEksak = a - b;
                string kata;
                kata = string.Format("Nilai eksak = {0:F6}", nilaiEksak);
                label9.Text = kata;
                double temp = batasBawah, deltaBatas = (batasAtas - batasBawah) / segment;
                while (temp <= batasAtas)
                {
                    x.Add(temp);
                    y.Add(Math.Round(integral(temp), 7));
                    temp += deltaBatas;
                }
                for (int i = 0; i < y.Count - 1; i++)
                {
                    double f = (x[i + 1] - x[i]) * (y[i + 1] + y[i]) / 2;
                    col.Add(f);
                    hasil += f;
                }
                trueError = nilaiEksak - hasil;
                kata = string.Format("True Error = {0:F6}", trueError);
                label10.Text = kata;
                absError = Math.Abs(trueError / nilaiEksak * 100);
                kata = string.Format("Absolute Relative Error = {0:F6}", absError);
                label11.Text = kata;
                for (int i = 0; i < x.Count-1; i++)
                {
                    if (i == 0)
                        dataGridView1.Rows.Add(x[i], y[i], col[i], hasil);
                    else
                        dataGridView1.Rows.Add(x[i], y[i], col[i],"");
                        
                    }
                }

            }

 
                
            


            

        }
    }

