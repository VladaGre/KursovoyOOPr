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
    public partial class CityInfo : Form // Город
    {
        City output;
        public CityInfo(City temp)
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

        private void button1_Click(object sender, EventArgs e)// Страна
        {
            CountryInfo temp = new CountryInfo(output.GetCparents());
            temp.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)// Регион
        {
            if (output.GetRparents().GetType().Equals("Область") ||
                        output.GetRparents().GetType().Equals("Провинция")
                       )
                {
                    RegionInfo1 temp = new RegionInfo1(output.GetRparents());
                    temp.ShowDialog(this);
                }
                else if (output.GetRparents().GetType().Equals("Штат") )
                {
                    RegionInfo2 temp = new RegionInfo2((State)output.GetRparents());
                    temp.ShowDialog(this);
                }
        }

        private void button3_Click(object sender, EventArgs e)// Материк
        {
            MainlandInfo temp = new MainlandInfo(output.GetMparents());
            temp.ShowDialog(this);
        }
    }
}
