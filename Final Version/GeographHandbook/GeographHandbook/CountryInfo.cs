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
    public partial class CountryInfo : Form
    {
        Country output;
        public CountryInfo(Country temp)//Страна
        {
            InitializeComponent();
            label2.Text = temp.GetBoard();
            label5.Text = temp.GetCitizen().ToString();
            label8.Text = temp.GetArea().ToString();
            this.Text = temp.GetName();
            if(temp.GetCapital()!=null)button1.Text = temp.GetCapital().GetName();
            else button1.Text = "Не указана";
            button2.Text = temp.GetMparents().GetName();
            output = temp;
        }

        private void button1_Click(object sender, EventArgs e)//информация о столице
        {
            if (output.GetCapital() != null)
            {
                CityInfo temp = new CityInfo(output.GetCapital());
                temp.ShowDialog(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)//информация о материке
        {
            MainlandInfo temp = new MainlandInfo(output.GetMparents());
            temp.ShowDialog(this);
        }
    }
}
