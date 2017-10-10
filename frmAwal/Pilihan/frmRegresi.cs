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
    public partial class frmRegresi : Form
    {
        fungsi func = new fungsi();
        public frmRegresi()
        {
            InitializeComponent();
        }
        private void frmRegresi_Load(object sender,EventArgs e)
        {

        }
        private void frmRegresi_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            btnSubmit.Visible = true;
            var choice = int.Parse(comboBox1.Text);
            if (!Enumerable.Range(2, 10).Contains(choice))
                throw new ArgumentOutOfRangeException("only 2 to 10 is allowed : " + comboBox1.Text);
            var textBoxes = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16,textBox17,textBox18,textBox19,textBox20};
            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i].Visible = i < choice * 2;
                textBoxes[i].Text = "";
            }
                
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(comboBox1.Text , out n);
            if (!isNumeric)
                MessageBox.Show("Harap masukkan jumlah pasangan terlebih dahulu");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int m,n;
            bool isNumeric1 = int.TryParse(comboBox1.Text, out m);
            bool isNumeric2 = int.TryParse(comboBox2.Text, out n);
            if (isNumeric1 && isNumeric2)
            {
                var cekKosong = this.Controls.OfType<TextBox>().Where((txt) => txt.Text.Length == 0 && txt.Visible == true);
                dgvHasil.Rows.Clear();
                if (cekKosong.Any())
                    MessageBox.Show("Harap masukkan semua pasangan dan pangkat yang ada!");
                else
                {
                    listBox1.Items.Clear();
                    int pas = int.Parse(comboBox1.Text);
                    int pang = int.Parse(comboBox2.Text);
                    double[] x = new double[pas];
                    double[] y = new double[pas];
                    double[] yAksen = new double[pas];
                    double[] sigX = new double[pang * 2];
                    double[] sigXY = new double[pang * 2];
                    double[] a = new double[pang + 1];
                    double[,] arr = new double[pang + 1, pang + 1];
                    double err = 0;
                    var labels = new Label[] { label3, label4, label5, label6 };
                    var textBoxes = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20 };
                    for (int i = 0; i < pas; i++)
                    {
                        x[i] = double.Parse(textBoxes[i * 2].Text) ;
                        y[i] = double.Parse(textBoxes[i * 2 + 1].Text);
                        yAksen[i] = 0;
                     
                    }
                    for (int i = 0; i <pang*2; i++)
                    {
                        sigX[i] = 0;
                        sigXY[i] = 0;
                    }
                    for (int i = 0; i < pang*2; i++)
                    {
                        for (int j = 0; j < pas; j++)
                        {
                            sigX[i] += Math.Pow(x[j], i + 1);
                            sigXY[i] += Math.Pow(x[j], i) * y[j];
                        }
                    }
                    double[,] tmp = new double[pang+1,pang+1];
                    for (int i = 0; i <= pang; i++)
                    {
                        for (int j = 0; j <= pang; j++)
                        {
                            if (i == 0 && j == 0)
                                arr[i, j] = pas;
                            else
                                arr[i, j] = sigX[i+j-1];
                            tmp[i, j] = arr[i, j];
                        }
                        
                    }
                    double detA = func.det(arr, pang + 1);
                    for (int i = 0; i <= pang; i++)
                    {
                        if (i>0)
                            for (int j = 0; j <= pang; j++)
                                arr[j, i - 1] = tmp[j, i - 1];
                        for (int j = 0; j <= pang; j++)
                            arr[j, i] = sigXY[j];
                        double detI = func.det(arr, pang + 1);
                        a[i] = detI / detA;
                        string kataa = string.Format("a{0} : ", i);
                        labels[i].Text  = kataa+a[i].ToString() ;
                        labels[i].Visible = true;
                    }
                    double sigE = 0;
                    for (int i = 0; i < pas; i++)
                    {
                        for (int j = 0; j <= pang; j++)
                        {
                            yAksen[i] += a[j] * Math.Pow(x[i], j);
                        }
                        sigE += Math.Pow (yAksen[i] - y[i],2);
                        err += Math.Abs(yAksen[i] - y[i]);
                        dgvHasil.Rows.Add(x[i].ToString("n10"), y[i].ToString("n10"), yAksen[i].ToString("n10"), (Math.Abs(yAksen[i] - y[i])).ToString("n10"));
                    }
                    string kata = string.Format("Total Error Regresi = {0:F10}", err);
                    listBox1.Items.Add(kata);
                    kata = string.Format("MSE Regresi = {0:F10}", sigE/pas);
                    listBox1.Items.Add(kata);
                    double nilaiX = double.Parse(textBox21.Text);
                    double[] fx = new double[3];
                    for(int i = 0;i<3;i++)
                        fx[i]=0;
                    double deltaX = double.Parse(textBox22.Text);
                    for (int i = 0; i < 3; i++)
                    {
                        if (i == 0) nilaiX -= deltaX;
                        else nilaiX += deltaX;
                        for (int j = 0; j <= pang; j++)
                            fx[i] += a[j] * Math.Pow(nilaiX, j);
                        kata = string.Format("f({0}) = {1}",nilaiX,fx[i]);
                        listBox1.Items.Add(kata);
                    }
                    double bda, fda, cda;
                    bda = (fx[1] - fx[0]) / deltaX;
                    fda = (fx[2] - fx[1]) / deltaX;
                    cda = (fx[2] - fx[0]) / (2 * deltaX);
                    kata = string.Format("BDA = {0}", bda);
                    listBox1.Items.Add(kata);
                    kata = string.Format("CDA = {0}", cda);
                    listBox1.Items.Add(kata);
                    kata = string.Format("FDA = {0}", fda);
                    listBox1.Items.Add(kata);
                    listBox1.Items.Add("Error : ");
                    double[] error = new double[6];
                    error[0] = (Math.Abs(bda - cda) * 100 )/ bda;
                    error[1] = Math.Abs(bda - fda) * 100 / bda;
                    error[2] = Math.Abs(cda - bda) * 100 / cda;
                    error[3] = Math.Abs(cda - fda) * 100 / cda;
                    error[4] = Math.Abs(fda - bda) * 100 / fda;
                    error[5] = Math.Abs(fda - cda) * 100 / fda;
                    double errorMin = error.Min();
                    kata = string.Format("BDA vs CDA = {0:f6}%", error[0]);
                    listBox1.Items.Add(kata);
                    kata = string.Format("BDA vs FDA = {0:f6}%", error[1]);
                    listBox1.Items.Add(kata);
                    kata = string.Format("CDA vs BDA = {0:f6}%", error[2]);
                    listBox1.Items.Add(kata);
                    kata = string.Format("CDA vs FDA = {0:f6}%", error[3]);
                    listBox1.Items.Add(kata);
                    kata = string.Format("FDA vs BDA = {0:f6}%", error[4]);
                    listBox1.Items.Add(kata);
                    kata = string.Format("FDA vs CDA = {0:f6}%", error[5]);
                    listBox1.Items.Add(kata);
                    kata = string.Format("Perbandingan error Regresi dengan nilai Error turunan terkecil:");
                    listBox1.Items.Add(kata);
                    kata = string.Format("Error turunan terkecil = {0:F6}", errorMin);
                    listBox1.Items.Add(kata);
                    kata = string.Format("Error Regresi = {0:F6}", err);
                    listBox1.Items.Add(kata);
                }
            }
            else
            {
                MessageBox.Show("Harap masukkan jumlah pasangan/pangkat terlebih dahulu!");
            }
        }

        private void frmRegresi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = new Form1();
            frm.Show();
        }
    }
}
