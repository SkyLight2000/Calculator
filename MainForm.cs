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
        private bool p = false;

        Calc_Math cm = new Calc_Math();
        public BindingList<string> history;

        public CalculatorForm()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            ToolTip t = new ToolTip();
            t.SetToolTip(DeleteHistory, "Очистить журнал");

            history = new BindingList<string>();
            history.Add("Журнала еще нет");
            listBox1.DataSource = history;
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
            cm.N(1, rtb1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cm.N(2, rtb1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cm.N(3, rtb1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cm.N(4, rtb1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cm.N(5, rtb1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cm.N(6, rtb1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cm.N(7, rtb1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cm.N(8, rtb1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cm.N(9, rtb1);
        }

        private void buttonPI_Click(object sender, EventArgs e)
        {
            if (rtb1.Text.Last() == '+' || rtb1.Text.Last() == '-' || rtb1.Text.Last() == '×' || rtb1.Text.Last() == '÷')
            {
                cm.N(Math.PI, rtb1);
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
                if (rez == "" || rez == "-")
                {
                    rtb1.Text = "0";
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            cm.Cl('+', rtb1);
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            cm.Cl('-', rtb1);
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            cm.Cl('*', rtb1);
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            cm.Cl('/', rtb1);
        }

        private void buttonEq_Click(object sender, EventArgs e)
        {
            if ((string)listBox1.Items[0] == "Журнала еще нет")
            {
                history.Clear();
            }
            history.Add(cm.Calc(rtb1));

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
            if ((rtb1.Text.IndexOf("∞") == -1))
            {
                rtb1.Text += ",";
            }
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            history.Add(cm.MathFunc("sqrt", rtb1, listBox1));
        }


        private void buttonFact_Click(object sender, EventArgs e)
        {
            history.Add(cm.MathFunc("fact", rtb1, listBox1));
        }

        private void buttonSqr_Click(object sender, EventArgs e)
        {
            history.Add(cm.MathFunc("sqr", rtb1, listBox1));
        }

        private void buttonQub_Click(object sender, EventArgs e)
        {
            history.Add(cm.MathFunc("cube", rtb1, listBox1));
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            history.Add(cm.MathFunc("log", rtb1, listBox1));
        }

        private void buttonLn_Click(object sender, EventArgs e)
        {
            history.Add(cm.MathFunc("ln", rtb1, listBox1));
        }

        private void buttonTenAmp_Click(object sender, EventArgs e)
        {
            history.Add(cm.MathFunc("10", rtb1, listBox1));
        }

        private void buttonSin_Click(object sender, EventArgs e)
        {
            history.Add(cm.MathFunc("sin", rtb1, listBox1));
        }

        private void buttonCos_Click(object sender, EventArgs e)
        {
            history.Add(cm.MathFunc("cos", rtb1, listBox1));
        }

        private void buttonTan_Click(object sender, EventArgs e)
        {
            history.Add(cm.MathFunc("tan", rtb1, listBox1));
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
            history.Clear();
            history.Add("Журнала еще нет");
        }
    }
}