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
    
    public partial class frmTurunan : Form
    {
        fungsi func = new fungsi();
        public frmTurunan()
        {
            InitializeComponent();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void frmTurunan_Load(object sender, EventArgs e)
        {
            var textBoxes = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20 };
            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i].Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            btnSubmit.Visible = true;
            var choice = int.Parse(comboBox1.Text);
            if (!Enumerable.Range(2, 10).Contains(choice))
                throw new ArgumentOutOfRangeException("only 2 to 10 is allowed = " + comboBox1.Text);
            var textBoxes = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20 };
            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i].Visible = i < choice * 2;
                textBoxes[i].Text = "";
            }
        }

        private void frmTurunan_Closed(object sender, FormClosedEventArgs e)
        {
            Form frm = new Form1();
            frm.Show();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var cekKosong = this.Controls.OfType<TextBox>().Where((txt) => txt.Text.Length == 0 && txt.Visible == true);
            if (cekKosong.Any())
                MessageBox.Show("Harap masukkan semua pasangan dan pangkat yang ada!");
            else
            {
                listBox1.Items.Clear();
                int pas = int.Parse(comboBox1.Text);
                int pang = int.Parse(textBox21.Text );
                double[] x = new double[pas];
                double[] y = new double[pas];
                double[] yAksen = new double[pas];
                double[] sigX = new double[pang * 2];
                double[] sigXY = new double[pang * 2];
                double[] a = new double[pang + 1];
                double[,] arr = new double[pang + 1, pang + 1];
                double err = 0;
                var textBoxes = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20 };
                for (int i = 0; i < pas; i++)
                {
                    x[i] = double.Parse(textBoxes[i * 2].Text);
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
                    if (i > 0)
                        for (int j = 0; j <= pang; j++)
                            arr[j, i - 1] = tmp[j, i - 1];
                    for (int j = 0; j <= pang; j++)
                        arr[j, i] = sigXY[j];
                    double detI = func.det(arr, pang + 1);
                    a[i] = detI / detA;
                    string kataa = string.Format("a{0} = {0}", i,a[i]);
                    listBox1.Items.Add(kataa);
                }
                double sigE = 0;
                listBox1.Items.Add("|               x               |                y               |                 y'                |              |y-y'|              |");
                for (int i = 0; i < pas; i++)
                {
                    for (int j = 0; j <= pang; j++)
                    {
                        yAksen[i] += a[j] * Math.Pow(x[i], j);
                    }
                    sigE += Math.Pow(yAksen[i] - y[i], 2);
                    err += Math.Abs(yAksen[i] - y[i]);
                    string kataa = string.Format("   {0:F10}         {1:F10}          {2:F10}               {3:F10}", x[i], y[i], yAksen[i], Math.Abs(y[i] - yAksen[i]));
                    listBox1.Items.Add(kataa);
                }
                string kata = string.Format("Total Error Regresi = {0:F10}", err);
                listBox1.Items.Add(kata);
                kata = string.Format("MSE Regresi = {0:F10}", sigE / pas);
                listBox1.Items.Add(kata);
                double nilaiX = double.Parse(textBox22.Text );
                double deltaX = double.Parse(textBox23.Text);
                double[] fx = new double[3];
                for (int i = 0; i < 3; i++)
                    fx[i] = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0) nilaiX -= deltaX;
                    else nilaiX += deltaX;
                    for (int j = 0; j <= pang; j++)
                        fx[i] += a[j] * Math.Pow(nilaiX, j);
                    kata = string.Format("f({0}) = {1}", nilaiX, fx[i]);
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
                error[0] = (Math.Abs(bda - cda) * 100) / bda;
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
                double[] f = new double[10];
                for (int i = 0; i < 10; i++)
                {
                    f[i] = 0;
                }
                for (int i = -4; i <= 4; i++)
                {
                    for (int j = 0; j < pang + 1; j++)
                    {
                        f[i + 4] += a[j] * Math.Pow(nilaiX + i * deltaX, j);
                    }
                }
                //turunan pertama
                listBox1.Items.Add("Turunan Pertama FDA(2 titik) : ");
                kata = string.Format("f(x) = {0}", f[4]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+1) = {0}", f[5]);
                listBox1.Items.Add(kata);
                kata = string.Format("f' = (f(x+1)-f(x))/deltaX = {0}", (f[5] - f[4]) / deltaX);
                listBox1.Items.Add(kata);
                listBox1.Items.Add("Turunan Pertama FDA(3 titik) : ");
                kata = string.Format("f(x) = {0}", f[4]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+1) = {0}", f[5]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+2) = {0}", f[6]);
                listBox1.Items.Add(kata);
                kata = string.Format("f' = (-3 * f(x) + 4 * f(x+1) - f(x+2)) / (2 * deltaX)= {0}", (-3 * f[4] + 4 * f[5] - f[6]) / (2 * deltaX));
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");
                listBox1.Items.Add("Turunan Pertama CDA(3titik) : ");
                kata = string.Format("f(x-1) = {0}", f[3]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+1) = {0}", f[5]);
                listBox1.Items.Add(kata);
                kata = string.Format("f' = (f(x+1) - f(x-1))/(2*deltaX) = {0}", (f[5] - f[3]) / (2 * deltaX));
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");

                listBox1.Items.Add("Turunan Pertama CDA(5titik) : ");
                kata = string.Format("f(x-2) = {0}", f[2]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x-1) = {0}", f[3]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+1) = {0}", f[5]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+2) = {0}", f[6]);
                listBox1.Items.Add(kata);
                kata = string.Format("f' = (-f(x+2) + 8 * f(x+1) - 8 * (x-1) + f(x-2)) / (12 * deltaX) =  {0}", (-f[6] + 8 * f[5] - 8 * f[3] + f[2]) / (12 * deltaX));
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");

                listBox1.Items.Add("Turunan Pertama BDA(2 titik) : ");
                kata = string.Format("f(x-1) = {0}", f[3]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x) = {0}", f[4]);
                listBox1.Items.Add(kata);
                kata = string.Format("f' = (f(x) - f(x-1))/deltaX= {0}", (f[4] - f[3]) / deltaX);
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");


                listBox1.Items.Add("Turunan Pertama BDA(3 titik) : ");
                kata = string.Format("f(x-2) = {0}", f[2]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x-1) = {0}", f[3]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x) = {0}", f[4]);
                listBox1.Items.Add(kata);
                kata = string.Format("f' = (-3 * f(x) + 4 * f(x-1) - f(x-2)) / (2 * deltaX)= {0}", (-3 * f[4] + 4 * f[3] - f[2]) / (2 * deltaX));
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");
                //turunan kedua
                listBox1.Items.Add("Turunan kedua FDA(3titik) : ");
                kata = string.Format("f(x) = {0}", f[4]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+1) = {0}", f[5]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+2) = {0}", f[6]);
                listBox1.Items.Add(kata);
                kata = string.Format("f'' = (f(x+2) - 2 * f(x+1) + f(x)) / (deltaX^2) = {0}", (f[6] - 2 * f[5] + f[4]) / (deltaX * deltaX));
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");


                listBox1.Items.Add("Turunan kedua FDA(4titik) : ");
                kata = string.Format("f(x) = {0}", f[4]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+1) = {0}", f[5]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+2) = {0}", f[6]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+3) = {0}", f[7]);
                listBox1.Items.Add(kata);
                kata = string.Format("f'' = (-f(x+3) + 4 * f(x+2) - 5 * f(x+1) + 2 * f(x)) / (deltaX^2) = {0}", (-f[7] + 4 * f[6] - 5 * f[5] + 2 * f[4]) / (deltaX * deltaX));
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");

                listBox1.Items.Add("Turunan kedua CDA (3 titik): ");
                kata = string.Format("f(x-1) = {0}", f[3]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x) = {0}", f[4]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+1) = {0}", f[5]);
                listBox1.Items.Add(kata);
                kata = string.Format("f'' = (f(x+1) - 2 * f(x) + f(x-1)) / (deltaX^2) = {0}", (f[5] - 2 * f[4] + f[3]) / (deltaX * deltaX));
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");

                listBox1.Items.Add("Turunan kedua CDA (5 titik): ");
                kata = string.Format("f(x-2) = {0}", f[2]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x-1) = {0}", f[3]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x) = {0}", f[4]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+1) = {0}", f[5]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+2) = {0}", f[6]);
                listBox1.Items.Add(kata);
                kata = string.Format("f'' = (-f(x+2) + 16 * f(x+1) - 30 * f(x) + 16 * f(x-1) - f(x-2)) / (12 * deltaX^2) = {0}", (-f[6] + 16 * f[5] - 30 * f[4] + 16 * f[3] - f[2]) / (12 * deltaX * deltaX));
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");

                listBox1.Items.Add("Turunan kedua BDA (3 titik): ");
                kata = string.Format("f(x-2) = {0}", f[2]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x-1) = {0}", f[3]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x) = {0}", f[4]);
                listBox1.Items.Add(kata);
                kata = string.Format("f'' = (f(x) - 2 * f(x-1) + f(x-2)) / (deltaX^2) = {0}", (f[4] - 2 * f[3] + f[2]) / (deltaX * deltaX));
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");

                listBox1.Items.Add("Turunan kedua BDA (4 titik): ");
                kata = string.Format("f(x-3) = {0}", f[1]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x-2) = {0}", f[2]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x-1) = {0}", f[3]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x) = {0}", f[4]);
                listBox1.Items.Add(kata);
                kata = string.Format("f'' = (-f(x-3) + 4 * f(x-2) - 5 * f(x-1) + 2 * f(x)) / (deltaX^2) = {0}", (-f[1] + 4 * f[2] - 5 * f[3] + 2 * f[4]) / (deltaX * deltaX));
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");
                //turunan ketiga
                listBox1.Items.Add("Turunan Ketiga FDA (4 titik): ");
                kata = string.Format("f(x) = {0}", f[4]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+1) = {0}", f[5]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+2) = {0}", f[6]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+3) = {0}", f[7]);
                listBox1.Items.Add(kata);
                kata = string.Format("f''' = (f(x+3) - 3 * f(x+2) + 3 * f(x+1) - f(x)) / (delta^3) = {0}", (f[7] - 3 * f[6] + 3 * f[5] - f[4]) / Math.Pow(deltaX, 3));
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");

                listBox1.Items.Add("Turunan Ketiga CDA (5 titik): ");
                kata = string.Format("f(x-2) = {0}", f[2]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x-1) = {0}", f[3]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+1) = {0}", f[5]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+2) = {0}", f[6]);
                listBox1.Items.Add(kata);
                kata = string.Format("f''' = (f(x+2) - 2 * f(x+1) + 2 * f(x-1) - f(x-2)) / 2 * deltaX^ 3 = {0}", (f[6] - 2 * f[5] + 2 * f[3] - f[2]) / 2 * Math.Pow(deltaX, 3));
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");

                listBox1.Items.Add("Turunan Ketiga BDA (4 titik): ");
                kata = string.Format("f(x-3) = {0}", f[1]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x-2) = {0}", f[2]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x-1) = {0}", f[3]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x) = {0}", f[4]);
                listBox1.Items.Add(kata);
                kata = string.Format("f''' = (-f(x-3) + 3 * f(x-2) - 3 * f(x-1) + f(x)) / deltaX^ 3 = {0}", (-f[1] + 3 * f[2] - 3 * f[3] + f[4]) / Math.Pow(deltaX, 3));
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");
                //turunan keempat
                listBox1.Items.Add("Turunan Keempat FDA (5 titik): ");
                kata = string.Format("f(x) = {0}", f[4]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+1) = {0}", f[5]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+2) = {0}", f[6]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+3) = {0}", f[7]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+4) = {0}", f[8]);
                listBox1.Items.Add(kata);
                kata = string.Format("f'''' = (f(x+4) - 4 * f(x+3) + 6 * f(x+2) - 4 * f(x+1) + f(x)) / delta^4 = {0}", (f[8] - 4 * f[7] + 6 * f[6] - 4 * f[5] + f[4]) / Math.Pow(deltaX, 4));
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");

                listBox1.Items.Add("Turunan Keempat CDA (5 titik): ");
                kata = string.Format("f(x-2) = {0}", f[2]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x-1) = {0}", f[3]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x) = {0}", f[4]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+1) = {0}", f[5]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x+2) = {0}", f[6]);
                listBox1.Items.Add(kata);
                kata = string.Format("f'''' = (f(x+2) - 4 * f(x+1) + 6 * f(x) - 4 * f(x-1) + f(x-2)) / delta^4 = {0}", (f[6] - 4 * f[5] + 6 * f[4] - 4 * f[3] + f[2]) / Math.Pow(deltaX, 4));
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");

                listBox1.Items.Add("Turunan Keempat BDA (5 titik): ");
                kata = string.Format("f(x-4) = {0}", f[0]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x-3) = {0}", f[1]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x-2) = {0}", f[2]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x-1) = {0}", f[3]);
                listBox1.Items.Add(kata);
                kata = string.Format("f(x) = {0}", f[4]);
                listBox1.Items.Add(kata);
                kata = string.Format("f'''' = (f(x-4) - 4 * f(x-3) + 6 * f(x-2) - 4 * f(x-1) + f(x)) / delta^4 = {0}", (f[0] - 4 * f[1] + 6 * f[2] - 4 * f[3] + f[4]) / Math.Pow(deltaX, 4));
                listBox1.Items.Add(kata);
                listBox1.Items.Add("");     }
      }
   }
}

