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
    public partial class Form5 : Form//область и провинция
    {
        region output;
        public Form5(region temp)
        {
            InitializeComponent();
            this.Text = temp.GetName();
            label2.Text = temp.GetArea().ToString();
            label5.Text = temp.GetCitizen().ToString();
            button1.Text = temp.GetCParents().GetName();
            output = temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 temp = new Form4(output.GetCParents());
            temp.ShowDialog(this);
        }
    }
}
