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
    public partial class RegionInfo2 : Form//штат
    {
        State output;
        public RegionInfo2(State temp)
        {
            InitializeComponent();
            InitializeComponent();
            this.Text = temp.GetName();
            label2.Text = temp.GetArea().ToString();
            label5.Text = temp.GetCitizen().ToString();
            button1.Text = temp.GetCParents().GetName();
            if (temp.GetCapital() != null) button2.Text = temp.GetCapital().GetName();
            else button2.Text = "Не указана";
            output = temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CountryInfo temp = new CountryInfo(output.GetCParents());
            temp.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (output.GetCapital() != null)
            {
                CityInfo temp = new CityInfo(output.GetCapital());
                temp.ShowDialog(this);
            }
        }
    }
}
