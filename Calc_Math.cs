using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    class Calc_Math
    {
        private string a;
        private string b;
        private char operation;
        private bool p = false;


        public void N(double s, RichTextBox r)
        {
            if ((r.Text.IndexOf("∞") == -1))
            {
                if (r.Text == Math.PI.ToString())
                {
                    r.Text = s.ToString();
                }
                else
                {
                    if (r.Text == "0")
                    {
                        r.Text = s.ToString();
                    }
                    else
                    {
                        r.Text += s;
                    }
                }
            }
        }

        public string Calc(RichTextBox r)
        {
            string s1, s2;
            int i = a.Length + 1;
            while (i < r.Text.Length)
            {
                b += r.Text[i];
                i++;
            }
            s1 = r.Text;
            if (operation == '+')
            {
                r.Text = Convert.ToString(Convert.ToDouble(a) + Convert.ToDouble(b));
            }
            if (operation == '-')
            {
                r.Text = Convert.ToString(Convert.ToDouble(a) - Convert.ToDouble(b));
            }
            if (operation == '*')
            {
                r.Text = Convert.ToString(Convert.ToDouble(a) * Convert.ToDouble(b));
            }
            if (operation == '/')
            {
                if (b == "0")
                {
                    r.Font = new Font(r.Font.Name, 25);
                    r.Text = "Деление на ноль невозможно";
                }
                else
                {
                    r.Text = Convert.ToString(Convert.ToDouble(a) / Convert.ToDouble(b));
                }
            }
            b = null;
            s2 = s1 + "=" + r.Text;
            return s2;
        }

        public void Cl(char c, RichTextBox r)
        {
            if ((r.Text.IndexOf("∞") == -1))
            {
                if (p)
                {
                    Calc(r);
                }
                operation = c;
                a = r.Text;
                switch (c)
                {
                    case '+':
                        r.Text += "+";
                        break;
                    case '-':
                        r.Text += "-";
                        break;
                    case '*':
                        r.Text += "×";
                        break;
                    case '/':
                        r.Text += "÷";
                        break;
                }
                p = true;
            }
        }

        public int Factorial(int N)
        {
            int factorial = 1;
            if (N != 0)
            {
                for (int i = 2; i <= N; i++)
                {
                    factorial *= i;
                }
            }
            return factorial;
        }

        public string MathFunc(string b, RichTextBox r, ListBox l)
        {
            CalculatorForm c = new CalculatorForm();
            if ((string)l.Items[0] == "Журнала еще нет")
            {
                c.history.Clear();
            }
            a = r.Text;
            if ((r.Text.IndexOf("∞") == -1))
            {
                switch (b)
                {
                    case "sqrt":
                        r.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(r.Text)));
                        break;
                    case "fact":
                        r.Text = Convert.ToString(Factorial(Convert.ToInt32(a)));
                        break;
                    case "sqr":
                        r.Text = Convert.ToString(Math.Pow(Convert.ToDouble(a), 2));
                        break;
                    case "cube":
                        r.Text = Convert.ToString(Math.Pow(Convert.ToDouble(a), 3));
                        break;
                    case "log":
                        r.Text = Convert.ToString(Math.Log(Convert.ToDouble(a), 10));
                        break;
                    case "ln":
                        r.Text = Convert.ToString(Math.Log(Convert.ToDouble(a)));
                        break;
                    case "10":
                        r.Text = Convert.ToString(Math.Pow(10, Convert.ToDouble(a)));
                        break;
                    case "sin":
                        r.Text = Convert.ToString(Math.Sin(Convert.ToDouble(a) * Math.PI / 180));
                        break;
                    case "cos":
                        r.Text = Convert.ToString(Math.Cos(Convert.ToDouble(a) * Math.PI / 180));
                        break;
                    case "tan":
                        r.Text = Convert.ToString(Math.Tan(Convert.ToDouble(a) * Math.PI / 180));
                        break;
                }
                if (b == "10")
                {
                    return b + "^" + a + "=" + r.Text;
                }
                else
                {
                    return b + "(" + a + ")=" + r.Text;
                }
            }
            return r.Text;
        }
    }
}
