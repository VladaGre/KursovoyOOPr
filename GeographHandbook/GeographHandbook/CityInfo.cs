using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeographHandbook
{
    public partial class Form7 : Form//город
    {
        city output;
        public Form7(city temp)
        {
            output = temp;
            InitializeComponent();
            this.Text = temp.GetName();
            label4.Text = temp.GetAdress()[0]._degrees.ToString();
            label5.Text = temp.GetAdress()[1]._degrees.ToString();
            label8.Text = temp.GetAdress()[0]._minutes.ToString();
            label9.Text = temp.GetAdress()[1]._minutes.ToString();
            label12.Text = temp.GetAdress()[0]._seconds.ToString();
            label13.Text = temp.GetAdress()[1]._seconds.ToString();
            label22.Text = temp.GetAdress()[0]._polarity.ToString();
            label23.Text = temp.GetAdress()[1]._polarity.ToString();
            label17.Text = temp.GetCitizen().ToString();
            button1.Text = temp.GetCparents().GetName();
            button2.Text = temp.GetRparents().GetName();
            button3.Text = temp.GetMparents().GetName();
        }

        private void button1_Click(object sender, EventArgs e)//Страна
        {
            Form4 temp = new Form4(output.GetCparents());
            temp.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)//Регион
        {
            if (output.GetRparents().GetType().Equals("Область") ||
                        output.GetRparents().GetType().Equals("Провинция")
                       )
                {
                    Form5 temp = new Form5(output.GetRparents());
                    temp.ShowDialog(this);
                }
                else if (output.GetRparents().GetType().Equals("Штат") )
                {
                    Form6 temp = new Form6((state)output.GetRparents());
                    temp.ShowDialog(this);
                }
        }

        private void button3_Click(object sender, EventArgs e)//Материк
        {
            Form3 temp = new Form3(output.GetMparents());
            temp.ShowDialog(this);
        }
    }
}
