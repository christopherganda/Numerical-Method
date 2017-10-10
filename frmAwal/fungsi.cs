using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmAwal
{
    class fungsi
    {
        public double[,] invers(double[,] arr, int n)
        {
            double[,] a = new double[n, n * 2];
            double[,] h = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = arr[i, j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = n; j < 2 * n; j++)
                {
                    if (i == j - n)
                        a[i, j] = 1;
                    else
                        a[i, j] = 0;
                }
            }
            for (int i = 0; i < n; i++)
            {
                double t = a[i, i];
                for (int j = i; j < 2 * n; j++)
                {
                    a[i, j] /= t;
                }
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        t = a[j, i];
                        for (int k = 0; k < 2 * n; k++)
                        {
                            a[j, k] -= t * a[i, k];
                        }
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = n; j < 2 * n; j++)
                {
                    h[i, j - n] = a[i, j];
                }
            }
            return h;
        }
        public double det(double[,] arr, int uk)
        {
            if (uk == 1)
            {
                return arr[0, 0];
            }
            else if (uk == 2)
            {
                return arr[0, 0] * arr[1, 1] - arr[0, 1] * arr[1, 0];
            }
            else
            {
                double[,] tmp = new double[100, 100];
                double res = 0;
                //kolom
                for (int i = 0; i < uk; i++)
                {
                    //baris
                    for (int j = 1; j < uk; j++)
                    {
                        //kolom
                        for (int k = 0; k < uk; k++)
                        {
                            if (k < i) tmp[j - 1, k] = arr[j, k];
                            //kurang 1 kolom kalau lbh besar dari kolom yang diskip
                            else if (k > i) tmp[j - 1, k - 1] = arr[j, k];
                        }
                    }
                    if (i % 2 == 0) res += arr[0, i] * det(tmp, uk - 1);
                    else res -= arr[0, i] * det(tmp, uk - 1);
                }
                return res;
            }
        }
    }
}
