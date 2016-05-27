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
    public partial class MainlandInfo : Form
    {
        public MainlandInfo(Mainland temp)//материк
        {

            InitializeComponent();
                this.Text = temp.GetName();
                label4.Text = temp.GetArea().ToString();
                label5.Text = temp.GetDensity().ToString();
                label6.Text = temp.GetCitizen().ToString();           
        }
    }
}
