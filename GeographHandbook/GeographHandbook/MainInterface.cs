using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;



namespace GeographHandbook
{
    public partial class Form2 : Form
    {
        private static element[] poisk;
        public Form2()
        {
            InitializeComponent();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)//Добавить новый элемент
        {
            Form1 temp = new Form1();
            temp.ShowDialog(this);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)//работа с базой
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            var formater = new BinaryFormatter();
                            Program._main = (hesh)formater.Deserialize(myStream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)//работа с базой
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    var formater = new BinaryFormatter();
                    formater.Serialize(myStream, Program._main);
                    myStream.Close();
                }
            }
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)//работа с базой
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            var formater = new BinaryFormatter();
                            hesh temp = new hesh();
                            temp = (hesh)formater.Deserialize(myStream);
                            Program._main.AddTo(temp);
                            temp = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//поиск
        {
            dataGridView1.Rows.Clear();
            poisk = Program._main.find(textBox1.Text);
            for (int x = 0; x < poisk.Length;x++ )
            {
                dataGridView1.Rows.Add(); 
                dataGridView1.Rows[x].Cells[0].Value = poisk[x].GetName();
                dataGridView1.Rows[x].Cells[1].Value = poisk[x].GetType();
                dataGridView1.Rows[x].Cells[2].Value = "Дополнительно";
                
            }
            dataGridView1.CellClick +=
            new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

         void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//дополнительно
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (poisk[e.RowIndex].GetType().Equals("Материк"))
                {
                    Form3 temp = new Form3((mainland)poisk[e.RowIndex]);
                    temp.ShowDialog(this);
                }
                else if (poisk[e.RowIndex].GetType().Equals("Страна"))
                {
                    Form4 temp = new Form4((country)poisk[e.RowIndex]);
                    temp.ShowDialog(this);
                }
                else if (poisk[e.RowIndex].GetType().Equals("Область") ||
                        poisk[e.RowIndex].GetType().Equals("Провинция")
                       )
                {
                    Form5 temp = new Form5((region)poisk[e.RowIndex]);
                    temp.ShowDialog(this);
                }
                else if (poisk[e.RowIndex].GetType().Equals("Штат") )
                {
                    Form6 temp = new Form6((state)poisk[e.RowIndex]);
                    temp.ShowDialog(this);
                }
                else if (poisk[e.RowIndex].GetType().Equals("Город"))
                {
                    Form7 temp = new Form7((city)poisk[e.RowIndex]);
                    temp.ShowDialog(this);
                }                
            }
        }

         private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
         {
             MessageBoxButtons buttons = MessageBoxButtons.OK;
             MessageBox.Show("Информация о программе", "Справка", buttons);
         }

         private void оАвтореToolStripMenuItem_Click(object sender, EventArgs e)
         {
             MessageBoxButtons buttons = MessageBoxButtons.OK;
             MessageBox.Show("\tКурсовая работа по ООП \nГребенник Влады Владимировны ПИ-15-2", "Справка", buttons);
         }

    }
}
