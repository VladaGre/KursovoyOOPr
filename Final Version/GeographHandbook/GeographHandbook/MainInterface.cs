using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;



namespace GeographHandbook
{
    public partial class MainInterface : Form
    {
        private static Element[] poisk;
        public MainInterface()
        {
            InitializeComponent();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)//Добавить новый элемент
        {
            AddingElement temp = new AddingElement();
            temp.ShowDialog(this);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)//Работа с базой
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
                            Program._main = (Hesh)formater.Deserialize(myStream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)//Работа с базой
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

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)//Работа с базой
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
                            Hesh temp = new Hesh();
                            temp = (Hesh)formater.Deserialize(myStream);
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

        private void button1_Click(object sender, EventArgs e)//Поиск
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
        }

         void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//Дополнительно
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (poisk[e.RowIndex].GetType().Equals("Материк"))
                {
                    MainlandInfo temp = new MainlandInfo((Mainland)poisk[e.RowIndex]);
                    temp.ShowDialog(this);
                }
                else if (poisk[e.RowIndex].GetType().Equals("Страна"))
                {
                    CountryInfo temp = new CountryInfo((Country)poisk[e.RowIndex]);
                    temp.ShowDialog(this);
                }
                else if (poisk[e.RowIndex].GetType().Equals("Область") ||
                        poisk[e.RowIndex].GetType().Equals("Провинция")
                       )
                {
                    RegionInfo1 temp = new RegionInfo1((Region)poisk[e.RowIndex]);
                    temp.ShowDialog(this);
                }
                else if (poisk[e.RowIndex].GetType().Equals("Штат") )
                {
                    RegionInfo2 temp = new RegionInfo2((State)poisk[e.RowIndex]);
                    temp.ShowDialog(this);
                }
                else if (poisk[e.RowIndex].GetType().Equals("Город"))
                {
                    CityInfo temp = new CityInfo((City)poisk[e.RowIndex]);
                    temp.ShowDialog(this);
                }                
            }
        }

         private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
         {
             kur.AboutProgram temp = new kur.AboutProgram();
             temp.ShowDialog(this);
         }

         private void ИнструкцияToolStripMenuItem_Click(object sender, EventArgs e)
         {
            Instructions Form = new Instructions();
            Form.Show();
         }

         private void button2_Click(object sender, EventArgs e)
         {
             int _rows = 0;
             dataGridView1.Rows.Clear();
             poisk = new Element[Program._main.GetUse()];
             for (int x = 0; x < Program._main.GetSize(); x++)
             {
                 if(Program._main.GetNode(x)!=null)
                 {
                 dataGridView1.Rows.Add();
                 dataGridView1.Rows[_rows].Cells[0].Value = Program._main.GetNode(x).GetElement().GetName();
                 dataGridView1.Rows[_rows].Cells[1].Value = Program._main.GetNode(x).GetElement().GetType();
                 dataGridView1.Rows[_rows].Cells[2].Value = "Дополнительно";
                 poisk[_rows++] = Program._main.GetNode(x).GetElement();
                 }
             }
         }

        private void MainInterface_Load(object sender, EventArgs e)
        {

        }

        private void MainInterface_Load_1(object sender, EventArgs e)
        {

        }
    }
}
