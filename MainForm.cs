using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        private string a;
        private string b;
        private char operation;
        private bool p = false;

        public CalculatorForm()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            ToolTip t = new ToolTip();
            t.SetToolTip(DeleteHistory, "Очистить журнал");
        }

        private void N(double s)
        {
            if ((rtb1.Text.IndexOf("∞") == -1))
            {
                if (rtb1.Text == Math.PI.ToString())
                {
                    rtb1.Text = s.ToString();
                }
                else
                {
                    if (rtb1.Text == "0")
                    {
                        rtb1.Text = s.ToString();
                    }
                    else
                    {
                        rtb1.Text += s;
                    }
                }
            }
        }

        private void Calc()
        {
            if(textBox1.Text == "Журнала еще нет")
            {
                textBox1.Text = "";
            }
            int i = a.Length + 1;
            textBox1.Text += rtb1.Text;
            while (i < rtb1.Text.Length)
            {
                b += rtb1.Text[i];
                i++;
            }
            if (operation == '+')
            {
                rtb1.Text = Convert.ToString(Convert.ToDouble(a) + Convert.ToDouble(b));
            }
            if (operation == '-')
            {
                rtb1.Text = Convert.ToString(Convert.ToDouble(a) - Convert.ToDouble(b));
            }
            if (operation == '*')
            {
                rtb1.Text = Convert.ToString(Convert.ToDouble(a) * Convert.ToDouble(b));
            }
            if (operation == '/')
            {
                if (b == "0")
                {
                    rtb1.Font = new Font(rtb1.Font.Name, 25);
                    rtb1.Text = "Деление на ноль невозможно";
                }
                else
                {
                    rtb1.Text = Convert.ToString(Convert.ToDouble(a) / Convert.ToDouble(b));
                }
            }
            textBox1.Text += "=" + rtb1.Text;
            textBox1.AppendText(Environment.NewLine);
            b = null;
        }

        private void Cl(char c)
        {
            if ((rtb1.Text.IndexOf("∞") == -1))
            {
                if (p)
                {
                    Calc();
                }
                operation = c;
                a = rtb1.Text;
                switch (c)
                {
                    case '+':
                        rtb1.Text += "+";
                        break;
                    case '-':
                        rtb1.Text += "-";
                        break;
                    case '*':
                        rtb1.Text += "×";
                        break;
                    case '/':
                        rtb1.Text += "÷";
                        break;
                }
                p = true;
            }
        }

        private int Factorial(int N)
        {
            int factorial = 1;
            if (N != 0)
            {
                for(int i = 2; i <= N; i++)
                {
                    factorial *= i;
                }
            }
            return factorial;
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            rtb1.Text = "0";
            p = false;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (rtb1.Text == "0")
            {
                rtb1.Text = "0";
            }
            else
            {
                rtb1.Text += "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            N(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            N(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            N(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            N(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            N(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            N(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            N(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            N(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            N(9);
        }

        private void buttonPI_Click(object sender, EventArgs e)
        {
            if (rtb1.Text.Last() == '+' || rtb1.Text.Last() == '-'|| rtb1.Text.Last() == '×' || rtb1.Text.Last() == '÷')
            {
                N(Math.PI);
            }
            else
            {
                rtb1.Text = Math.PI.ToString();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            string rez = "";
            int i = 0;
            if (rtb1.Text != "0")
            {
                while (i < rtb1.Text.Length - 1)
                {
                    rez += rtb1.Text[i];
                    i++;
                }
                rtb1.Text = rez;
                if (rez == string.Empty)
                {
                    rtb1.Text = "0";
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Cl('+');
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            Cl('-');
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            Cl('*');
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            Cl('/');
        }
        private void buttonEq_Click(object sender, EventArgs e)
        {
            Calc();
            p = false;
        }

        private void buttonChangeSign_Click(object sender, EventArgs e)
        {
            if (rtb1.Text == "0")
            {
                rtb1.Text = "0";
            }
            else
            {
                if (rtb1.Text[0] == '-')
                {
                    rtb1.Text = rtb1.Text.Remove(0, 1);
                }
                else
                {
                    rtb1.Text = "-" + rtb1.Text;
                }
            }
        }

        private void buttonCom_Click(object sender, EventArgs e)
        {
            if((rtb1.Text.IndexOf("∞") == -1))
            {
                rtb1.Text += ",";
            }
        }

        private void History(string b)
        {
            a = rtb1.Text;
            if (textBox1.Text == "Журнала еще нет")
            {
                textBox1.Text = "";
            }
            if ((rtb1.Text.IndexOf("∞") == -1))
            {
                switch (b)
                {
                    case "sqrt":
                        rtb1.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(rtb1.Text)));
                        break;
                    case "fact":
                        rtb1.Text = Convert.ToString(Factorial(Convert.ToInt32(a)));
                        break;
                    case "sqr":
                        rtb1.Text = Convert.ToString(Math.Pow(Convert.ToDouble(a), 2));
                        break;
                    case "cube":
                        rtb1.Text = Convert.ToString(Math.Pow(Convert.ToDouble(a), 3));
                        break;
                    case "log":
                        rtb1.Text = Convert.ToString(Math.Log(Convert.ToDouble(a), 10));
                        break;
                    case "ln":
                        rtb1.Text = Convert.ToString(Math.Log(Convert.ToDouble(a)));
                        break;
                    case "10":
                        rtb1.Text = Convert.ToString(Math.Pow(10, Convert.ToDouble(a)));
                        break;
                    case "sin":
                        rtb1.Text = Convert.ToString(Math.Sin(Convert.ToDouble(a) * Math.PI / 180));
                        break;
                    case "cos":
                        rtb1.Text = Convert.ToString(Math.Cos(Convert.ToDouble(a) * Math.PI / 180));
                        break;
                    case "tan":
                        rtb1.Text = Convert.ToString(Math.Tan(Convert.ToDouble(a) * Math.PI / 180));
                        break;
                }
                if (b == "10")
                {
                    textBox1.AppendText(b + "^" + a + "=");
                }
                else
                {
                    textBox1.AppendText(b + "(" + a + ")=");
                }
                textBox1.Text += rtb1.Text;
                textBox1.AppendText(Environment.NewLine);
            }
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            History("sqrt");
        }


        private void buttonFact_Click(object sender, EventArgs e)
        {
            History("fact");
        }

        private void buttonSqr_Click(object sender, EventArgs e)
        {
            History("sqr");
        }

        private void buttonQub_Click(object sender, EventArgs e)
        {
            History("cube");
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            History("log");
        }

        private void buttonLn_Click(object sender, EventArgs e)
        {
            History("ln");
        }

        private void buttonTenAmp_Click(object sender, EventArgs e)
        {
            History("10");
        }

        private void buttonSin_Click(object sender, EventArgs e)
        {
            History("sin");
        }

        private void buttonCos_Click(object sender, EventArgs e)
        {
            History("cos");
        }

        private void buttonTan_Click(object sender, EventArgs e)
        {
            History("tan");
        }

        private void Load_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            rtb1.Text = fileText;
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            if (about.ShowDialog() == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void DeleteHistory_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Журнала еще нет";
        }
    }
}