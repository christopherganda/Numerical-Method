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
    public partial class frmMetodeEuler : Form
    {
        private string Fungsi(List<string> stack, Dictionary<string, double> var)
        {
            if (stack.Count == 1)
            {
                double op1;
                double d, b;
                string num = "";
                string numDec = "";
                if (stack[0] == "e")
                {
                    op1 = Math.Exp(1);
                }
                else if (stack[0] != "l" && stack[0] != "s" && stack[0] != "t" && stack[0] != "c" && stack[0] != "n" && ((stack[0][0] >= 'A' && stack[0][0] <= 'Z') || (stack[0][0] >= 'a' && stack[0][0] <= 'z' || (stack[0][0] == '-' && (stack[0][1] > '9' || stack[0][1] < '0')))))
                {
                    op1 = var[stack[0]];
                }
                else
                {
                    op1 = Convert.ToDouble(stack[0]);
                }
                bool neg = false;
                if (Math.Floor(op1) < 0)
                {
                    neg = true;
                    op1 = Math.Abs(op1);
                }
                int len = 30;
                d = Math.Floor(op1);
                b = op1 - d;
                if (d == 0) num += "0";
                while (Math.Floor(d) > 0)
                {
                    num += '0' + (int)Math.Floor(d % 10.0);
                    d = Math.Floor(d / 10);
                }
                if (neg) num += '-';
                num = Reverse(num);
                while (len > 0)
                {
                    b *= 10;
                    len--;
                }
                b = Math.Floor(b);
                while (Math.Floor(b) > 0)
                {
                    numDec += '0' + (int)Math.Floor(b % 10.0);
                    b = Math.Floor(b / 10);
                }
                numDec = Reverse(numDec);
                if (numDec != "")
                {
                    num += '.';
                    for (int k = 0; k < 30 - numDec.Length; k++) num += '0';
                    num += numDec;
                }
                stack[0] = num;
            }

            while (stack.Count > 1)
            {
                for (int i = 0; i < stack.Count; i++)
                {
                    if (isOperator(stack[i]) && isOperand(stack[i + 1]) && isOperand(stack[i + 2]))
                    {
                        double op1, op2;
                        double hslOperand = 0;
                        if (stack[i + 1] == "e")
                        {
                            op1 = Math.Exp(1);
                        }
                        else if (stack[i + 1] != "l" && stack[i + 1] != "s" && stack[i + 1] != "t" && stack[i + 1] != "c" && stack[i + 1] != "n" && ((stack[i + 1][0] >= 'A' && stack[i + 1][0] <= 'Z') || (stack[i + 1][0] >= 'a' && stack[i + 1][0] <= 'z' || (stack[i + 1][0] == '-' && (stack[i + 1][1] > '9' || stack[i + 1][1] < '0')))))
                        {
                            op1 = var[stack[i + 1]];
                        }
                        else
                        {
                            op1 = Convert.ToDouble(stack[i + 1]);
                        }

                        if (stack[i + 2] == "e")
                        {
                            op2 = Math.Exp(1);
                        }
                        else if (stack[i + 2] != "l" && stack[i + 2] != "s" && stack[i + 2] != "t" && stack[i + 2] != "c" && stack[i + 2] != "n" && ((stack[i + 2][0] >= 'A' && stack[i + 2][0] <= 'Z') || (stack[i + 2][0] >= 'a' && stack[i + 2][0] <= 'z' || (stack[i + 2][0] == '-' && (stack[i + 2][1] > '9' || stack[i + 2][1] < '0')))))
                        {
                            op2 = var[stack[i + 2]];
                        }
                        else
                        {
                            op2 = Convert.ToDouble(stack[i + 2]);
                        }

                        if (stack[i] == "+") hslOperand = op1 + op2;
                        else if (stack[i] == "-") hslOperand = op1 - op2;
                        else if (stack[i] == "*") hslOperand = op1 * op2;
                        else if (stack[i] == "/") hslOperand = op1 / op2;
                        else if (stack[i] == "^") hslOperand = Math.Pow(op1, op2);
                        bool neg = false;
                        if (Math.Floor(hslOperand) < 0)
                        {
                            neg = true;
                            hslOperand = Math.Abs(hslOperand);
                        }

                        if (neg) hslOperand *= -1;
                        stack[i] = hslOperand.ToString();
                        stack.RemoveRange(i + 1, 2);
                    }
                    else if (isLSTC(stack[i]) && isOperand(stack[i + 1]))
                    {
                        double op1;
                        double hslOperand = 0;
                        if (stack[i + 1] == "e")
                        {
                            op1 = Math.Exp(1);
                        }
                        else if (stack[i + 1] != "l" && stack[i + 1] != "s" && stack[i + 1] != "t" && stack[i + 1] != "c" && stack[i + 1] != "n" && ((stack[i + 1][0] >= 'A' && stack[i + 1][0] <= 'Z') || (stack[i + 1][0] >= 'a' && stack[i + 1][0] <= 'z' || (stack[i + 1][0] == '-' && (stack[i + 1][1] > '9' || stack[i + 1][1] < '0')))))
                        {
                            op1 = var[stack[i + 1]];
                        }
                        else
                        {
                            op1 = Convert.ToDouble(stack[i + 1]);
                        }

                        if (stack[i] == "l") hslOperand = Math.Log(op1);
                        else if (stack[i] == "s") hslOperand = Math.Sin(op1 * Math.PI / 180);
                        else if (stack[i] == "t") hslOperand = Math.Tan(op1 * Math.PI / 180);
                        else if (stack[i] == "c") hslOperand = Math.Cos(op1 * Math.PI / 180);
                        bool neg = false;
                        if (Math.Floor(hslOperand) < 0)
                        {
                            neg = true;
                            hslOperand = Math.Abs(hslOperand);
                        }

                        if (neg) hslOperand *= -1;
                        stack[i] = hslOperand.ToString();
                        stack.RemoveRange(i + 1, 1);
                    }
                }
            }

            return stack[0];
        }
        public frmMetodeEuler()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool isOperator(string op)
        {
            if (op == "+" || op == "-" || op == "*" || op == "/" || op == "^") return true;
            return false;
        }
        private bool isLSTC(string lstc)
        {
            if (lstc == "l" || lstc == "s" || lstc == "t" || lstc == "c") return true;
            return false;
        }
        private bool isOperand(string op)
        {
            return !isOperator(op) && !isLSTC(op);
        }
        private void frmMetodeEuler_Load(object sender, EventArgs e)
        {

        }

        private void frmMetodeEuler_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = new Form1();
            frm.Show();
        }
        private string Reverse(string s)
        {
            string h = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                h += s[i];
            }
            return h;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            dgvHasil.Rows.Clear();
            var cekKosong = this.Controls.OfType<TextBox>().Where((txt) => txt.Text.Length == 0 && txt.Visible == true);
            if (cekKosong.Any()) MessageBox.Show("Harap lengkapi input-input yang tersedia");
            else
            {
                string fung = txtFungsi.Text;
                double eksak = double.Parse(txtNilaiEksak.Text);
                double x0 = double.Parse(txtX0.Text);
                double y0 = double.Parse(txtY0.Text);
                double xCari = double.Parse(txtXDicari.Text);
                int seg = int.Parse(txtSegment.Text);
                Stack<char> stack = new Stack<char>();
                List<string> prefix = new List<string>();
                fung = fung.Replace(" ", "");
                string tmpString = "";
                int[] arr = new int[256];
                arr['+'] = 1;
                arr['-'] = 1;
                arr['*'] = 2;
                arr['/'] = 2;
                arr['^'] = 3;
                arr['l'] = 3;
                arr['s'] = 3;
                arr['t'] = 3;
                arr['c'] = 3;
                for (int i = fung.Length - 1; i >= 0; i--)
                {
                    if (fung[i] == ' ') continue;
                    if (fung[i] < '0' || fung[i] > '9')
                    {
                        if (fung[i] == '.')
                        {
                            tmpString += fung[i];
                            continue;
                        }
                        if (fung[i] != 'l' && fung[i] != 's' && fung[i] != 't' && fung[i] != 'c' && fung[i] != 'n' && ((fung[i] >= 'A' && fung[i] <= 'Z') || (fung[i] >= 'a' && fung[i] <= 'z')))
                        {
                            tmpString += fung[i];
                            continue;
                        }
                        if (fung[i] == '-' && (i == 0 || fung[i - 1] == '(' || fung[i - 1] == '+' || fung[i - 1] == '-' || fung[i - 1] == '*' || fung[i - 1] == '/' || fung[i - 1] == '^'))
                        {
                            tmpString += fung[i];
                            continue;
                        }
                        if (tmpString != "")
                        {
                            tmpString = Reverse(tmpString);
                            prefix.Add(tmpString);
                        }
                        tmpString = "";
                        if (fung[i] == 'n')
                        {
                            if (fung[i - 1] == 'l') i -= 1;
                            else i -= 2;
                        }
                        else if (fung[i] == 's') i -= 2;
                        if (stack.Count == 0)
                        {
                            stack.Push(fung[i]);
                        }
                        else if (fung[i] == '(')
                        {
                            while (stack.Count != 0 && stack.Peek() != ')')
                            {
                                string tmp = "";
                                tmp += stack.Peek();
                                prefix.Add(tmp);
                                stack.Pop();
                            }
                            stack.Pop();
                        }
                        else if (fung[i] == ')')
                        {
                            stack.Push(fung[i]);
                        }
                        else
                        {
                            if (arr[fung[i]] >= arr[stack.Peek()] || stack.Peek() == ')')
                            {
                                stack.Push(fung[i]);
                            }
                            else
                            {
                                while (stack.Count != 0 && arr[stack.Peek()] > arr[fung[i]])
                                {
                                    string tmp = "";
                                    tmp += stack.Peek();
                                    prefix.Add(tmp);
                                    stack.Pop();
                                }
                                stack.Push(fung[i]);
                            }
                        }
                    }
                    else
                    {
                        tmpString += fung[i];
                    }
                    
                }
                if (tmpString != "")
                {
                    tmpString = Reverse(tmpString);
                    prefix.Add(tmpString);
                }
                while (stack.Count != 0)
                {
                    string tmp = "";
                    tmp += stack.Peek();
                    prefix.Add(tmp);
                    stack.Pop();
                }
                prefix.Reverse();
                tmpString = "";

                Dictionary<string, double> variable = new Dictionary<string, double>();
                List<string> prefixFunc;
                double delta = (xCari - x0) / seg;
                double xn = x0;
                double yn = y0;
                dgvHasil.Rows.Add(0, xn.ToString("F10"), yn.ToString("F10"));

                for (int j = 1; j <= seg; j++)
                {
                    prefixFunc = prefix.ToList();
                    variable["x"] = xn;
                    variable["y"] = yn;
                    variable["-x"] = -xn;
                    variable["-y"] = -yn;
                    variable["-e"] = Math.Exp(1) * -1;
                    xn = xn + delta;
                    yn = yn + Convert.ToDouble(Fungsi(prefixFunc, variable)) * delta;
                    //MessageBox.Show(yn.ToString());
                    //MessageBox.Show(Fungsi(prefixFunc, variable));
                    dgvHasil.Rows.Add(j, xn.ToString("F10"), yn.ToString("F10"));

                }
                label7.Text = string.Format("Error = {0:F10}", eksak - yn);
                label7.Visible = true;
            }
        }
    }
}
