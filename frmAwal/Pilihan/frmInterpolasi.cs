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
    public partial class frmInterpolasi : Form
    {
        public frmInterpolasi()
        {
            InitializeComponent();
        }

        private void frmInterpolasi_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            checkBox5.Visible = false;
            btnHitung.Visible = false;
            label4.Visible = false;
            comboBox3.Visible = false;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Form frm = new Form1();
            frm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Newton")
            {

                label4.Visible = false;
                comboBox3.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                btnHitung.Visible = true;
                listBox1.Items.Clear();

            }
            else if (comboBox1.Text == "Spline")
            {
                label4.Visible = true;
                comboBox3.Visible = true;
                btnHitung.Visible = true;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                btnHitung.Visible = true;
            }
            else if (comboBox1.Text == "Langsung" || comboBox1.Text=="Lagrange")
            {
                label4.Visible = false;
                comboBox3.Visible = false;
                listBox1.Items.Clear();
                textBox11.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                if (comboBox2.Text == "3")
                {
                    checkBox1.Visible = true;
                    checkBox2.Visible = true;
                    checkBox3.Visible = true;
                    checkBox4.Visible = false;
                    checkBox5.Visible = false;
                }
                else if (comboBox2.Text == "4")
                {
                    checkBox1.Visible = true;
                    checkBox2.Visible = true;
                    checkBox3.Visible = true;
                    checkBox4.Visible = true;
                    checkBox5.Visible = false;
                }
                else if (comboBox2.Text == "5")
                {
                    checkBox1.Visible = true;
                    checkBox2.Visible = true;
                    checkBox3.Visible = true;
                    checkBox4.Visible = true;
                    checkBox5.Visible = true;
                }
                btnHitung.Visible = true;
            }
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            var cekKosong = this.Controls.OfType<TextBox>().Where((txt) => txt.Text.Length == 0 && txt.Visible == true);
            listBox1.Items.Clear();
            if (cekKosong.Any())
            {
                MessageBox.Show("Harap masukkan semua input");
            }
            else
            {
                int jlh = Convert.ToInt16(comboBox2.Text);
                double has = Convert.ToDouble(textBox11.Text);
                string kata;
                
                if (comboBox1.Text == "Newton")
                {
                    double[] x = new double[jlh];
                    double[] y = new double[jlh];
                    //MessageBox.Show(jlh.ToString());
                    if (jlh == 5)
                    {
                        x[0] = Convert.ToDouble(textBox1.Text);
                        x[1] = Convert.ToDouble(textBox2.Text);
                        x[2] = Convert.ToDouble(textBox3.Text);
                        x[3] = Convert.ToDouble(textBox4.Text);
                        x[4] = Convert.ToDouble(textBox5.Text);
                        y[0] = Convert.ToDouble(textBox6.Text);
                        y[1] = Convert.ToDouble(textBox7.Text);
                        y[2] = Convert.ToDouble(textBox8.Text);
                        y[3] = Convert.ToDouble(textBox9.Text);
                        y[4] = Convert.ToDouble(textBox10.Text);
                    }
                    else if (jlh == 4)
                    {
                        x[0] = Convert.ToDouble(textBox1.Text);
                        x[1] = Convert.ToDouble(textBox2.Text);
                        x[2] = Convert.ToDouble(textBox3.Text);
                        x[3] = Convert.ToDouble(textBox4.Text);
                        y[0] = Convert.ToDouble(textBox6.Text);
                        y[1] = Convert.ToDouble(textBox7.Text);
                        y[2] = Convert.ToDouble(textBox8.Text);
                        y[3] = Convert.ToDouble(textBox9.Text);
                    }
                    else if (jlh == 3)
                    {
                        x[0] = Convert.ToDouble(textBox1.Text);
                        x[1] = Convert.ToDouble(textBox2.Text);
                        x[2] = Convert.ToDouble(textBox3.Text);
                        y[0] = Convert.ToDouble(textBox6.Text);
                        y[1] = Convert.ToDouble(textBox7.Text);
                        y[2] = Convert.ToDouble(textBox8.Text);
                    }
                    double[,] st = new double[jlh, jlh];
                    for (int i = 0; i < jlh; i++)
                    {
                        st[i, 0] = y[i];
                    }
                    for (int k = 1; k <jlh; k++)
                    {
                        for (int i = 0; i < (jlh - k); i++)
                        {
                            st[i, k] = (st[i + 1, k - 1] - st[i, k - 1]) / (x[i + k] - x[i]);
                            //kata = string.Format("st[{0},{1}] = {2}", i, k, st[i, k]);
                            //MessageBox.Show(kata);
                        }
                    }
                    double jumlah = 0;
                    for (int i = 0; i < jlh; i++)
                    {
                        double suku = st[0, i];
                        for (int k = 0; k <= i - 1; k++)
                        {
                            suku = suku * (has - x[k]);
                        }
                        jumlah += suku;
                        kata = string.Format("b{0} = {1}", i, st[0, i]);
                        listBox1.Items.Add(kata);
                    }
                    kata = string.Format("Hasil = {0}", jumlah);
                    listBox1.Items.Add(kata);
                }
                else if (comboBox1.Text == "Lagrange")
                {
                    var cek = this.Controls.OfType<CheckBox>().Count((ck) => ck.Checked) > 1;
                    if (cek)
                    {
                        //double [] x = new double[0];
                        //double[] y = new double[0];
                        int n = 0;
                        int m = -1;
                        double[] x = new double[jlh];
                        double[] y = new double[jlh];
                        if (jlh == 5)
                        {
                            x[0] = Convert.ToDouble(textBox1.Text);
                            x[1] = Convert.ToDouble(textBox2.Text);
                            x[2] = Convert.ToDouble(textBox3.Text);
                            x[3] = Convert.ToDouble(textBox4.Text);
                            x[4] = Convert.ToDouble(textBox5.Text);
                            y[0] = Convert.ToDouble(textBox6.Text);
                            y[1] = Convert.ToDouble(textBox7.Text);
                            y[2] = Convert.ToDouble(textBox8.Text);
                            y[3] = Convert.ToDouble(textBox9.Text);
                            y[4] = Convert.ToDouble(textBox10.Text);
                        }
                        else if (jlh == 4)
                        {
                            x[0] = Convert.ToDouble(textBox1.Text);
                            x[1] = Convert.ToDouble(textBox2.Text);
                            x[2] = Convert.ToDouble(textBox3.Text);
                            x[3] = Convert.ToDouble(textBox4.Text);
                            y[0] = Convert.ToDouble(textBox6.Text);
                            y[1] = Convert.ToDouble(textBox7.Text);
                            y[2] = Convert.ToDouble(textBox8.Text);
                            y[3] = Convert.ToDouble(textBox9.Text);
                        }
                        else if (jlh == 3)
                        {
                            x[0] = Convert.ToDouble(textBox1.Text);
                            x[1] = Convert.ToDouble(textBox2.Text);
                            x[2] = Convert.ToDouble(textBox3.Text);
                            y[0] = Convert.ToDouble(textBox6.Text);
                            y[1] = Convert.ToDouble(textBox7.Text);
                            y[2] = Convert.ToDouble(textBox8.Text);
                        }
                        if(checkBox1.Checked){
                            n++;
                            //Array.Resize(ref x, x.Length + 1);
                            //Array.Resize(ref y, y.Length + 1);
                            //x[x.GetUpperBound(0)] = Convert.ToDouble(textBox1.Text);
                            //y[y.GetUpperBound(0)] = Convert.ToDouble(textBox6.Text);
                            m = 0;
                        }
                        if (checkBox2.Checked)
                        {
                            n++;
                            //Array.Resize(ref x, x.Length + 1);
                            //Array.Resize(ref y, y.Length + 1);
                            //x[x.GetUpperBound(0)] = Convert.ToDouble(textBox2.Text);
                            //y[y.GetUpperBound(0)] = Convert.ToDouble(textBox7.Text);
                            if (m < 0)
                                m = 1;
                        }
                        if (checkBox3.Checked)
                        {
                            n++;
                            //Array.Resize(ref x, x.Length + 1);
                            //Array.Resize(ref y, y.Length + 1);
                            //x[x.GetUpperBound(0)] = Convert.ToDouble(textBox3.Text);
                            //y[y.GetUpperBound(0)] = Convert.ToDouble(textBox8.Text);
                            if (m < 0)
                                m = 2;
                        }
                        if (checkBox4.Checked)
                        {
                            n++;
                            //Array.Resize(ref x, x.Length + 1);
                            //Array.Resize(ref y, y.Length + 1);
                            //x[x.GetUpperBound(0)] = Convert.ToDouble(textBox4.Text);
                            //y[y.GetUpperBound(0)] = Convert.ToDouble(textBox9.Text);
                            if (m < 0)
                                m = 3;
                        }
                        if (checkBox5.Checked)
                        {
                            n++;
                            //Array.Resize(ref x, x.Length + 1);
                            //Array.Resize(ref y, y.Length + 1);
                            //x[x.GetUpperBound(0)] = Convert.ToDouble(textBox5.Text);
                            //y[y.GetUpperBound(0)] = Convert.ToDouble(textBox10.Text);
                            if (m < 0)
                                m = 4;
                        }
                        
                        if ((checkBox3.Checked && !checkBox2.Checked && checkBox1.Checked) || (checkBox4.Checked && !checkBox3.Checked &&(checkBox2.Checked||checkBox1.Checked)) || (checkBox5.Checked && !checkBox4.Checked && (checkBox3.Checked ||checkBox2.Checked||checkBox1.Checked)))
                        {
                            listBox1.Items.Add("Mohon centang yang berurut");
                        }
                        else
                        {
                            kata = "f(x) = ";
                            double[] hasil = new double[n];
                            double[] yAksen = new double[jlh];
                            double[] error = new double[jlh];
                            for (int i = 0; i < n; i++)
                            {
                                if (i == n-1)
                                    kata += string.Format("L{0}f(x{0})", i);
                                else
                                    kata += string.Format("L{0}f(x{0}) + ", i);
                                
                                yAksen[i]=0;
                            }
                            listBox1.Items.Add(kata);
                            
                            for (int i = 0; i < jlh; i++)
                            {
                                
                                for (int j = m; j < n+m; j++)
                                {
                                    /* n=3
                                     l0 = x-x1/x0-x1 * x-x2/x0-x2
                                     */
                                    hasil[j-m] = 1;
                                    for (int k = m; k < n+m; k++)
                                    {
                                        if (j==k)
                                            continue;

                                        else
                                        {
                                            hasil[j-m] *= (x[i] - x[k]) / (x[j] - x[k]);
                                        }
                                    }
                                    
                                    yAksen[i] += hasil[j-m] * y[j];
                                }
                                
                                error[i] = yAksen[i] - y[i];
                                
                                
                            }
                            for (int j = m; j < n+m; j++)
                            {
                                kata = string.Format("L{0} = {1}", j-m, hasil[j-m]);
                                listBox1.Items.Add(kata);
                            }
                            double totError = 0;
                            for (int i = 0; i < jlh; i++)
                            {
                                kata = string.Format("{0,-20:F6}   {1,-20:F6}   {2,-20:F6}   {3,-20:F6}   ", x[i], y[i], yAksen[i], error[i]);
                                listBox1.Items.Add(kata);
                                totError += error[i];
                                yAksen[i]=0;
                            }
                            kata = string.Format("Total error = {0}", totError);
                            
                            for (int j = m; j < n+m; j++)
                            {
                                /* n=3
                                    l0 = x-x1/x0-x1 * x-x2/x0-x2
                                    */
                                hasil[j-m] = 1;
                                for (int k = m; k < n+m; k++)
                                {
                                    if (j == k)
                                        continue;

                                    else
                                    {
                                        hasil[j-m] *= (has - x[k]) / (x[j] - x[k]);
                                    }
                                }
                                yAksen[j] += hasil[j-m] * y[j];
                            }

                            double jum = 0;
                            for (int i = 0; i <jlh; i++)
                                jum += yAksen[i];
                            kata = string.Format("f({0}) = {1}", has, jum);
                            listBox1.Items.Add(kata);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Centang minimal 2");
                    }
                    
                }
                else if (comboBox1.Text == "Langsung")
                {
                    var cek = this.Controls.OfType<CheckBox>().Count((ck) => ck.Checked) > 1;
                    if (cek)
                    {
                        double[] x = new double[0];
                        double[] y = new double[0];
                        int n = 0;
                        //pengecekan fungsi yang mau di ambil
                        if (checkBox1.Checked)
                        {
                            n++;
                            Array.Resize(ref x, x.Length + 1);
                            Array.Resize(ref y, y.Length + 1);
                            x[x.GetUpperBound(0)] = Convert.ToDouble(textBox1.Text);
                            y[y.GetUpperBound(0)] = Convert.ToDouble(textBox6.Text);
                        }
                        if (checkBox2.Checked)
                        {
                            n++;
                            Array.Resize(ref x, x.Length + 1);
                            Array.Resize(ref y, y.Length + 1);
                            x[x.GetUpperBound(0)] = Convert.ToDouble(textBox2.Text);
                            y[y.GetUpperBound(0)] = Convert.ToDouble(textBox7.Text);
                        }
                        if (checkBox3.Checked)
                        {
                            n++;
                            Array.Resize(ref x, x.Length + 1);
                            Array.Resize(ref y, y.Length + 1);
                            x[x.GetUpperBound(0)] = Convert.ToDouble(textBox3.Text);
                            y[y.GetUpperBound(0)] = Convert.ToDouble(textBox8.Text);
                        }
                        if (checkBox4.Checked)
                        {
                            n++;
                            Array.Resize(ref x, x.Length + 1);
                            Array.Resize(ref y, y.Length + 1);
                            x[x.GetUpperBound(0)] = Convert.ToDouble(textBox4.Text);
                            y[y.GetUpperBound(0)] = Convert.ToDouble(textBox9.Text);
                        }
                        if (checkBox5.Checked)
                        {
                            n++;
                            Array.Resize(ref x, x.Length + 1);
                            Array.Resize(ref y, y.Length + 1);
                            x[x.GetUpperBound(0)] = Convert.ToDouble(textBox5.Text);
                            y[y.GetUpperBound(0)] = Convert.ToDouble(textBox10.Text);
                        }
                        //end pengecekan fungsi
                        kata = string.Format("Matriks {0} x {1} :", n, n);
                        listBox1.Items.Add(kata);
                        double[,] xB = new double[n, n];
                        //pembuatan matriks nxn
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                xB[i, j] = Math.Pow(x[i], j);
                            }
                        }
                        //end pembuatan matriks nxn
                        kata = "";
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                kata += String.Format("{0,-20:F6}   ", xB[i, j]);
                            }
                            listBox1.Items.Add(kata);
                            kata = "";
                        }
                        frmAwal.fungsi func = new fungsi();
                        xB = func.invers(xB, n);
                        kata = string.Format("Matriks Inverse {0} x {1} :", n, n);
                        listBox1.Items.Add(kata);
                        kata = "";
                        double[] a = new double[n];
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                kata += String.Format("{0,-20:F6}   ", xB[i, j]);
                            }
                            listBox1.Items.Add(kata);
                            kata = "";
                            a[i] = 0;
                        }
                        listBox1.Items.Add("Nilai variabel a setelah matriks inverse dikali dengan y");
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                a[i] += xB[i, j] * y[j];
                            }
                            kata = string.Format("a{0} = {1}", i, a[i]);
                        }
                        double hasil = 0;
                        for (int i = 0; i < n; i++)
                        {
                            hasil += a[i] * Math.Pow(has, i);
                        }
                        kata = string.Format("f({0}) = {1}", has, hasil);
                        listBox1.Items.Add(kata);
                    }
                    else
                    {
                        MessageBox.Show("Centang minimal 2");
                    }
                }
                else if (comboBox1.Text == "Spline")
                {
                    double[] x = new double[jlh];
                    double[] y = new double[jlh];
                    int pangkat = Convert.ToInt16(comboBox3.Text);
                    if (jlh == 5)
                    {
                        x[0] = Convert.ToDouble(textBox1.Text);
                        x[1] = Convert.ToDouble(textBox2.Text);
                        x[2] = Convert.ToDouble(textBox3.Text);
                        x[3] = Convert.ToDouble(textBox4.Text);
                        x[4] = Convert.ToDouble(textBox5.Text);
                        y[0] = Convert.ToDouble(textBox6.Text);
                        y[1] = Convert.ToDouble(textBox7.Text);
                        y[2] = Convert.ToDouble(textBox8.Text);
                        y[3] = Convert.ToDouble(textBox9.Text);
                        y[4] = Convert.ToDouble(textBox10.Text);
                    }
                    else if (jlh == 4)
                    {
                        x[0] = Convert.ToDouble(textBox1.Text);
                        x[1] = Convert.ToDouble(textBox2.Text);
                        x[2] = Convert.ToDouble(textBox3.Text);
                        x[3] = Convert.ToDouble(textBox4.Text);
                        y[0] = Convert.ToDouble(textBox6.Text);
                        y[1] = Convert.ToDouble(textBox7.Text);
                        y[2] = Convert.ToDouble(textBox8.Text);
                        y[3] = Convert.ToDouble(textBox9.Text);
                    }
                    else if (jlh == 3)
                    {
                        x[0] = Convert.ToDouble(textBox1.Text);
                        x[1] = Convert.ToDouble(textBox2.Text);
                        x[2] = Convert.ToDouble(textBox3.Text);
                        y[0] = Convert.ToDouble(textBox6.Text);
                        y[1] = Convert.ToDouble(textBox7.Text);
                        y[2] = Convert.ToDouble(textBox8.Text);
                    }
                
                    if (pangkat == 1)
                    {
                        double linSpline = 0;
                        for (int i = 0; i < jlh - 1; i++)
                        {
                            //rumus
                            if (x[i] <= has && x[i + 1] >= has)
                            {
                                kata = string.Format("Nilai {0} berada pada range {1} dan {2}", has, x[i], x[i + 1]);
                                listBox1.Items.Add(kata);
                                linSpline += y[i] + ((y[i + 1] - y[i]) * (has - x[i]) / (x[i + 1] - x[i]));
                                break;
                            }
                            //end rumus linear spline
                        }
                        kata = string.Format("f({0}) = {1}", has, linSpline);
                        listBox1.Items.Add(kata);
                    }
                    else if (pangkat == 2)
                    {
                        double[,] arr = new double[(jlh - 1) * 3, (jlh - 1) * 3];
                        int i = 0,j=0,k=0;
                        //deklarasi arr
                        while (j <= (jlh - 1) * 3 - 3)
                        {
                            arr[i, j] = Math.Pow(x[k], 2);
                            arr[i, j + 1] = x[k];
                            arr[i, j + 2] = 1;
                            i++;
                            if (i % 2 == 0)
                                j += 3;
                            else
                                k += 1;
                        }
                        j = 0;
                        k = 1;
                        while (j < (jlh - 1) * 3 - 3)
                        {
                            arr[i, j] = 2*x[k];
                            arr[i, j + 1] = 1;
                            arr[i, j + 3] = arr[i,j]*-1;
                            arr[i, j + 4] = -1;
                            i++;
                            j += 3;
                            k += 1;
                        }
                        arr[arr.GetUpperBound(0), 0] = 1;
                        //end deklarasi arr
                        //cetak
                        listBox1.Items.Add("Persamaan yang di dapat : ");
                        for (i = 0; i < (jlh - 1) * 3; i++)
                        {
                            kata = "";
                            for (j = 0; j < (jlh - 1) * 3; j++)
                            {
                                if (j==((jlh - 1) * 3)-1)
                                    kata += string.Format("|{0,-15:F3}", arr[i, j]);
                                else
                                {
                                    if (arr[i, j] > 9)
                                        kata += string.Format("{0,-14:F3}", arr[i, j]);
                                    else
                                        kata += string.Format("{0,-15:F3}", arr[i, j]);
                                }
                                    
                            }
                            listBox1.Items.Add(kata);
                        }
                        //end cetak
                        //rumus penyelesaian
                        double[] tab = new double[(jlh-1)*3];
                        double[] hsl = new double[(jlh-1)*3];
                        k = 0;
                        int trip = (jlh-1)*3;
                        int min = jlh-2;
                        for (i = 0; i <trip-min-1 ; i++)
                        {
                            hsl[i] = y[k];
                            if (i % 2 == 0) k++;
                        }
                        tab[0] = 0;
                        tab[1] = (hsl[0] - hsl[1]) / (arr[0, 1] - arr[1, 1]);
                        tab[2] = (hsl[0] - arr[0, 0] * tab[0]);
                        tab[2] += arr[0, 1] * tab[1];
                        int start = 3;
                        int xi=trip-min-1;
                        k=3;
                        for (i = 2; i < trip - min - 3; i+=2)
                        {
                            tab[start] = (hsl[i] - hsl[i + 1]) - ((arr[xi, k] * tab[k - 3] + arr[xi, k + 1] * tab[k - 2]) * (-1 * (arr[i, k + 1] - arr[i + 1, k + 1]))) / (arr[i, k] - arr[i + 1, k]) - (arr[xi, k] * (-1 * (arr[i, k + 1] - arr[i + 1, k + 1])));
                            tab[start + 1] = ((hsl[i] - hsl[i + 1]) - ((arr[i, k] - arr[i + 1, k]) * tab[start])) / (arr[i, k + 1] - arr[i + 1, k + 1]);
                            tab[start + 2] = hsl[i] - arr[i, k] * tab[start] - arr[i, k + 1] * tab[start + 1];
                            start += 3;
                            xi += 1;
                            k += 3;
                        }
                        double quadSpline = 0;
                        for (i = 0; i < jlh - 1; i++)
                        {
                            if (x[i] <= has && x[i + 1] >= has)
                            {
                                double a = tab[i * 3];
                                double b = tab[i * 3 + 1];
                                double c = tab[i * 3 + 2];
                                quadSpline = a * has * has + b * has + c;
                            }
                        }
                        listBox1.Items.Add("Tabel Koefisien");
                        listBox1.Items.Add("     a[i]      b[i]      c[i]      ");
                        listBox1.Items.Add("------------------------------------");
                        for (i = 0; i < trip - 2; i++)
                        {
                            if (i % 3 == 0)
                            {
                                kata = string.Format("{0,8:f3}{1,9:f3}{2,9:f3}",tab[i],tab[i+1],tab[i+2]);
                                listBox1.Items.Add(kata);
                            }
                        }
                        kata=string.Format("F({0}) = {1}", has, quadSpline);
                        listBox1.Items.Add(kata);
                    }
                }
                

                
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "3")
            {
                textBox11.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
            }
            else if (comboBox2.Text == "4")
            {
                textBox11.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox5.Visible = false;
                textBox10.Visible = false;
            }
            else if (comboBox2.Text == "5")
            {
                textBox11.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
            }
            if (comboBox1.Text == "Newton")
            {


                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                btnHitung.Visible = true;
                listBox1.Items.Clear();

            }
            else if (comboBox1.Text == "Langsung" || comboBox1.Text == "Lagrange")
            {
                listBox1.Items.Clear();
                textBox11.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                if (comboBox2.Text == "3")
                {
                    checkBox1.Visible = true;
                    checkBox2.Visible = true;
                    checkBox3.Visible = true;
                    checkBox4.Visible = false;
                    checkBox5.Visible = false;
                }
                else if (comboBox2.Text == "4")
                {
                    checkBox1.Visible = true;
                    checkBox2.Visible = true;
                    checkBox3.Visible = true;
                    checkBox4.Visible = true;
                    checkBox5.Visible = false;
                }
                else if (comboBox2.Text == "5")
                {
                    checkBox1.Visible = true;
                    checkBox2.Visible = true;
                    checkBox3.Visible = true;
                    checkBox4.Visible = true;
                    checkBox5.Visible = true;
                }
                btnHitung.Visible = true;
            }
        }
    }
}
