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
    public partial class frmMetodeSimson : Form
    {
        double batasBawah, batasAtas, p, q, r, s, segment, nilaiEksak, trueError, absError;
        public frmMetodeSimson()
        {
            InitializeComponent();
        }

        private void frmMetodeSimson_Load(object sender, EventArgs e)
        {

        }
        public double integral(double a)
        {
            return p * (Math.Log(q) - Math.Log(q - r * a)) - s * a;
        }

        private void frmMetodeSimson_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = new Form1();
            frm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "1/3") label8.Text = "Segment 2 * i";
            else if (comboBox1.Text == "3/8") label8.Text = "Segment 3 * i";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool cek = false;
            dataGridView1.Rows.Clear();
            var cekKosong = this.Controls.OfType<TextBox>().Where((txt) => txt.Text.Length == 0 && txt.Visible == true);
            if (cekKosong.Any())
                MessageBox.Show("Harap masukkan semua pasangan dan pangkat yang ada!");
            else
            {
                if (comboBox1.Text == "1/3")
                {
                    if (double.Parse(textBox7.Text) % 2 != 0)
                    {
                        MessageBox.Show("Masukkan nilai segment yang valid!");
                    }
                    else cek=true;
                }
                else if (comboBox1.Text == "3/8")
                {
                    if (double.Parse(textBox7.Text) % 3 != 0)
                    {
                        MessageBox.Show("Masukkan nilai segment yang valid!");
                    }
                    else cek = true;
                }
                if (cek == true)
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
                a = p * ((r * batasAtas + Math.Log(q - r * batasAtas) * (q - r * batasAtas) - q) / r + Math.Log(q) * batasAtas) - ((s / 2) * batasAtas * batasAtas);
                b = p * ((r * batasBawah + Math.Log(q - r * batasBawah) * (q - r * batasBawah) - q) / r + Math.Log(q) * batasBawah) - ((s / 2) * batasBawah * batasBawah);
                nilaiEksak = a - b;
                string kata;
                kata = string.Format("Nilai eksak = {0:F6}", nilaiEksak);
                label9.Text = kata;
                double temp = batasBawah, deltaBatas = (batasAtas - batasBawah) / segment;
                for (int i = 0; i <= segment; i++)
                {
                    x.Add(temp);
                    y.Add(Math.Round(integral(temp), 7));
                    temp += deltaBatas;
                }
                double k = batasBawah;
                double sigma = 0;
                if(comboBox1.Text=="1/3"){
                    for (int i = 1; i <= segment-1; i++)
                    {
                        k += deltaBatas;
                        if (i % 2 == 1)
                        {
                            sigma += 4 * integral(k);
                        }
                        else
                        {
                            sigma += 2 * integral(k);
                        }
                    }
                    hasil = (integral(batasAtas) + integral(batasBawah) + sigma) * (deltaBatas / 3);
            
                }
                else if (comboBox1.Text == "3/8")
                {
                    for (int i = 0; i <= segment; i++)
                    {
                        if (i == 0 || i == segment)
                            hasil += y[i];
                        else if (i % 3 == 0)
                            hasil += y[i] * 2;
                        else
                            hasil += y[i] * 3;
                    }
                    hasil = hasil * (3 * (batasAtas  - batasBawah )) / (8 * segment);
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
                        dataGridView1.Rows.Add(x[i], y[i], hasil);
                    else
                        if (i % 2 == 1) {
                            if (comboBox1.Text == "1/3")
                                dataGridView1.Rows.Add(x[i], y[i] * 4);
                            else if (comboBox1.Text == "3/8")
                                dataGridView1.Rows.Add(x[i], y[i] * 3);
                        }
                            
                        else
                            dataGridView1.Rows.Add(x[i], y[i] * 2);
                        
                    }
                }
                }
            }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        }
    }

