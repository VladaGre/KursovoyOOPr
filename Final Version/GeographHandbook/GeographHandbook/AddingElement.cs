using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace GeographHandbook
{

    public partial class AddingElement : Form
    {

        public AddingElement()
        {
            InitializeComponent();
            //Подключение хэш-таблицы
            for (int t = 0; t < Program._main.GetSize(); t++)
            {
                if (Program._main.GetNode(t) != null)
                {
                    if (Program._main.GetNode(t).GetNext() == null)
                    {
                        if (Program._main.GetNode(t).GetElement().GetType().Equals("Материк"))
                        {
                            comboBox1.Items.Add(Program._main.GetNode(t).GetElement().GetName());
                            comboBox7.Items.Add(Program._main.GetNode(t).GetElement().GetName());
                        }
                        else if (Program._main.GetNode(t).GetElement().GetType().Equals("Страна"))
                        {
                            comboBox2.Items.Add(Program._main.GetNode(t).GetElement().GetName());
                            comboBox3.Items.Add(Program._main.GetNode(t).GetElement().GetName());
                            comboBox4.Items.Add(Program._main.GetNode(t).GetElement().GetName());
                            comboBox5.Items.Add(Program._main.GetNode(t).GetElement().GetName());
                        }
                        else if (Program._main.GetNode(t).GetElement().GetType().Equals("Область") ||
                                Program._main.GetNode(t).GetElement().GetType().Equals("Штат") ||
                                Program._main.GetNode(t).GetElement().GetType().Equals("Провинция")
                               )
                        {
                            comboBox6.Items.Add(Program._main.GetNode(t).GetElement().GetName());
                        }
                    }
                    else
                    {
                        eNode temp = Program._main.GetNode(t);
                        while (temp != null)
                        {
                            if (Program._main.GetNode(t).GetElement().GetType().Equals("Материк"))
                            {
                                comboBox1.Items.Add(Program._main.GetNode(t).GetElement().GetName());
                                comboBox7.Items.Add(Program._main.GetNode(t).GetElement().GetName());
                            }
                            else if (Program._main.GetNode(t).GetElement().GetType().Equals("Страна"))
                            {
                                comboBox2.Items.Add(Program._main.GetNode(t).GetElement().GetName());
                                comboBox3.Items.Add(Program._main.GetNode(t).GetElement().GetName());
                                comboBox4.Items.Add(Program._main.GetNode(t).GetElement().GetName());
                                comboBox5.Items.Add(Program._main.GetNode(t).GetElement().GetName());
                            }
                            else if (Program._main.GetNode(t).GetElement().GetType().Equals("Область") ||
                                    Program._main.GetNode(t).GetElement().GetType().Equals("Штат") ||
                                    Program._main.GetNode(t).GetElement().GetType().Equals("Провинция")
                                   )
                            {
                                comboBox6.Items.Add(Program._main.GetNode(t).GetElement().GetName());
                            }
                            temp = temp.GetNext();
                        }
                    }
                }
            }
            //Виды форм правления
            comboBox10.Items.Add("Президентская республика");
            comboBox10.Items.Add("Парламентская республика");
            comboBox10.Items.Add("Смешанная республика");
            comboBox10.Items.Add("Абсолютная монархия");
            comboBox10.Items.Add("Конституционная монархия");
            comboBox10.Items.Add("Дуалистическая монархия");
            comboBox10.Items.Add("Однопартийная система");
        }

        private void button2_Click(object sender, EventArgs e)//Добавление страны
        {
            try
            {
                if (textBox2.TextLength == 0) throw new MyException("Неправильно введено название!");
                if (Program._main.presenceCM(textBox2.Text.ToString())) throw new MyException("Страна с данным названием уже добавлена!");
                if (comboBox10.SelectedItem==null) throw new MyException("Не указана форма правления!");
                if (((Mainland)Program._main.onefind(comboBox1.SelectedItem.ToString())).GetCitizen() < Convert.ToUInt64(textBox8.Text.ToString())) throw new MyException("Население страны не может быть больше населения материка!");
                if (((Mainland)Program._main.onefind(comboBox1.SelectedItem.ToString())).GetArea() < Convert.ToUInt32(textBox7.Text.ToString())) throw new MyException("Площадь страны не может быть больше площади материка!");
                Program._main.Add(new Country(Convert.ToUInt64(textBox8.Text.ToString()), Convert.ToUInt32(textBox7.Text.ToString()), textBox2.Text.ToString(), comboBox10.SelectedItem.ToString(), (Mainland)Program._main.onefind(comboBox1.SelectedItem.ToString())));
                comboBox2.Items.Add(textBox2.Text.ToString());
                comboBox3.Items.Add(textBox2.Text.ToString());
                comboBox4.Items.Add(textBox2.Text.ToString());
                comboBox5.Items.Add(textBox2.Text.ToString());
                textBox2.Clear();
                textBox8.Clear();
                textBox7.Clear();
                comboBox10.SelectedIndex = -1;
                comboBox1.SelectedIndex = -1;
            }
            catch (System.NullReferenceException)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Не выбран материк!", "Ошибка", buttons);
            }
            catch (System.FormatException)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Неправильно введены числовые данные!", "Ошибка", buttons);
            }
            catch (MyException exp)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(exp.GetMessage(), "Ошибка", buttons);
            }


        }

        private void button1_Click_1(object sender, EventArgs e)//Добавление материка
        {
            try
            {
                if (textBox1.TextLength == 0) throw new MyException("Неправильно введено название!");
                if (Program._main.presenceCM(textBox1.Text.ToString())) throw new MyException("Материк с данным названием уже добавлен!");
                Program._main.Add(new Mainland(Convert.ToUInt32(textBox4.Text.ToString()), Convert.ToUInt64(textBox6.Text.ToString()), ((float)Convert.ToUInt64(textBox6.Text.ToString())/Convert.ToUInt32(textBox4.Text.ToString())), textBox1.Text.ToString()));
                comboBox1.Items.Add(textBox1.Text.ToString());
                comboBox7.Items.Add(textBox1.Text.ToString());
                textBox1.Clear();
                textBox4.Clear();
                textBox6.Clear();
            }
            catch (System.FormatException)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Неправильно введены числовые данные!", "Ошибка", buttons);
            }
            catch (MyException ex)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(ex.GetMessage(), "Ошибка", buttons);
            }



        }

        private void button3_Click(object sender, EventArgs e)//Добавление области
        {
            try
            {
                if (textBox3.TextLength == 0) throw new MyException("Не введено название!");
                if (((Country)Program._main.onefind(comboBox2.SelectedItem.ToString())).GetCitizen() < Convert.ToUInt32(textBox10.Text.ToString())) throw new MyException("Население области не может быть больше населения страны!");
                if (Convert.ToUInt32(textBox11.Text.ToString()) > ((Country)Program._main.onefind(comboBox2.SelectedItem.ToString())).GetArea()) throw new MyException("Площадь области не может быть больше площади страны!");
                Program._main.Add(new Oblast(textBox3.Text.ToString(), Convert.ToUInt32(textBox10.Text.ToString()), Convert.ToUInt32(textBox11.Text.ToString()), (Country)Program._main.onefind(comboBox2.SelectedItem.ToString())));
                comboBox6.Items.Add(textBox3.Text.ToString());
                textBox3.Clear();
                textBox10.Clear();
                textBox11.Clear();
                comboBox2.SelectedIndex = -1;
            }
            catch (System.NullReferenceException)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Не выбрана страна!", "Ошибка", buttons);
            }
            catch (System.FormatException)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Неправильно введены числовые данные!", "Ошибка", buttons);
            }
            catch (MyException exp)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(exp.GetMessage(), "Ошибка", buttons);
            }

        }

        private void button4_Click(object sender, EventArgs e)//Добаление штата
        {
            try
            {
                if (textBox12.TextLength == 0) throw new MyException("Не введено название!");
                if (((Country)Program._main.onefind(comboBox3.SelectedItem.ToString())).GetCitizen() < Convert.ToUInt32(textBox14.Text.ToString())) throw new MyException("Население штата не может быть больше населения страны!");
                if (Convert.ToUInt32(textBox13.Text.ToString()) > ((Country)Program._main.onefind(comboBox3.SelectedItem.ToString())).GetArea()) throw new MyException("Площадь штата не может быть больше площади страны!");
                Program._main.Add(new State(textBox12.Text.ToString(), Convert.ToUInt32(textBox13.Text.ToString()), Convert.ToUInt32(textBox14.Text.ToString()), (Country)Program._main.onefind(comboBox3.SelectedItem.ToString())));
                comboBox6.Items.Add(textBox12.Text.ToString());
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                comboBox3.SelectedIndex = -1;
            }
            catch (System.NullReferenceException)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Не выбрана страна!", "Ошибка", buttons);
            }
            catch (System.FormatException)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Неправильно введены числовые данные!", "Ошибка", buttons);
            }
            catch (MyException exp)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(exp.GetMessage(), "Ошибка", buttons);
            }

        }

        private void button5_Click(object sender, EventArgs e)//Добавление провинции
        {
            try
            {
                if (textBox15.TextLength == 0) throw new MyException("Не введено название!");
                if (((Country)Program._main.onefind(comboBox4.SelectedItem.ToString())).GetCitizen() < Convert.ToUInt32(textBox17.Text.ToString())) throw new MyException("Население провинции не может быть больше населения страны!");
                if (Convert.ToUInt32(textBox16.Text.ToString()) > ((Country)Program._main.onefind(comboBox4.SelectedItem.ToString())).GetArea()) throw new MyException("Площадь провинции не может быть больше площади страны!");
                Program._main.Add(new Provinces(textBox15.Text.ToString(), Convert.ToUInt32(textBox17.Text.ToString()), Convert.ToUInt32(textBox16.Text.ToString()), (Country)Program._main.onefind(comboBox4.SelectedItem.ToString())));
                comboBox6.Items.Add(textBox15.Text.ToString());
                textBox15.Clear();
                textBox16.Clear();
                textBox17.Clear();
                comboBox4.SelectedIndex = -1;
            }
            catch (System.NullReferenceException)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Не выбрана страна!", "Ошибка", buttons);
            }
            catch (System.FormatException)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Неправильно введены числовые данные!", "Ошибка", buttons);
            }
            catch (MyException exp)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(exp.GetMessage(), "Ошибка", buttons);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox18.TextLength == 0) throw new MyException("Не введено название!");
                if (Convert.ToByte(textBox19.Text.ToString()) > 90 ||
                    Convert.ToByte(textBox19.Text.ToString()) < 0 ||
                     Convert.ToByte(textBox20.Text.ToString()) > 180 ||
                     Convert.ToByte(textBox20.Text.ToString()) < 0 ||
                     Convert.ToByte(textBox21.Text.ToString()) > 60 ||
                     Convert.ToByte(textBox22.Text.ToString()) > 60 ||
                     Convert.ToByte(textBox23.Text.ToString()) > 60 ||
                     Convert.ToByte(textBox24.Text.ToString()) > 60 ||
                    (
                     Convert.ToByte(textBox19.Text.ToString()) == 90 &&
                      Convert.ToByte(textBox21.Text.ToString()) != 0 &&
                       Convert.ToByte(textBox23.Text.ToString()) != 0
                    )
                    ||
                (
                Convert.ToByte(textBox20.Text.ToString()) == 180 &&
                      Convert.ToByte(textBox22.Text.ToString()) != 0 &&
                       Convert.ToByte(textBox24.Text.ToString()) != 0
                )) throw new MyException("Неправильно введены координаты!");
                if (Program._main.findRegion(comboBox6.SelectedItem.ToString(), Program._main.findCountry(comboBox5.SelectedItem.ToString(), (Mainland)Program._main.onefind(comboBox7.SelectedItem.ToString()))).GetCitizen() < Convert.ToUInt32(textBox25.Text.ToString())) throw new MyException("Население города не может быть больше населения региона!");
                Program._main.Add(new City(Convert.ToChar(comboBox8.SelectedItem), Convert.ToByte(textBox19.Text.ToString()), Convert.ToByte(textBox21.Text.ToString()), Convert.ToByte(textBox23.Text.ToString()),
                                                              Convert.ToChar(comboBox9.SelectedItem), Convert.ToByte(textBox20.Text.ToString()), Convert.ToByte(textBox22.Text.ToString()), Convert.ToByte(textBox24.Text.ToString()),
                                                              Convert.ToUInt32(textBox25.Text.ToString()), textBox18.Text.ToString(), Program._main.findRegion(comboBox6.SelectedItem.ToString(), Program._main.findCountry(comboBox5.SelectedItem.ToString(), (Mainland)Program._main.onefind(comboBox7.SelectedItem.ToString()))),
                                                              Program._main.findCountry(comboBox5.SelectedItem.ToString(), (Mainland)Program._main.onefind(comboBox7.SelectedItem.ToString())), (Mainland)Program._main.onefind(comboBox7.SelectedItem.ToString())));// Convert.ToUInt32(textBox17.Text.ToString()), Convert.ToUInt32(textBox16.Text.ToString()), (country)_main.onefind(comboBox4.SelectedItem.ToString())));
                if (checkBox1.Checked) Program._main.findCountry(comboBox5.SelectedItem.ToString(), (Mainland)Program._main.onefind(comboBox7.SelectedItem.ToString())).SetCapital(Program._main.findCity(textBox18.Text.ToString(),
                    Program._main.findRegion(comboBox6.SelectedItem.ToString(), Program._main.findCountry(comboBox5.SelectedItem.ToString(), (Mainland)Program._main.onefind(comboBox7.SelectedItem.ToString())))));
                if (checkBox2.Checked)
                {
                    if (Program._main.findRegion(comboBox6.SelectedItem.ToString(), Program._main.findCountry(comboBox5.SelectedItem.ToString(), (Mainland)Program._main.onefind(comboBox7.SelectedItem.ToString()))).GetType().Equals("Штат"))

                        Program._main.findState(comboBox6.SelectedItem.ToString(),
                                                Program._main.findCountry(comboBox5.SelectedItem.ToString(),
                                                (Mainland)Program._main.onefind(comboBox7.SelectedItem.ToString()))).SetCapital(Program._main.findCity(textBox18.Text.ToString(),
                                                Program._main.findRegion(comboBox6.SelectedItem.ToString(),
                                                Program._main.findCountry(comboBox5.SelectedItem.ToString(),
                                                (Mainland)Program._main.onefind(comboBox7.SelectedItem.ToString())))));
                    else throw new MyException("Регион не найден, попробуйте снова");
                }
                textBox18.Clear();
                textBox19.Clear();
                textBox20.Clear();
                textBox21.Clear();
                textBox22.Clear();
                textBox23.Clear();
                textBox24.Clear();
                textBox25.Clear();
                comboBox5.SelectedIndex = -1;
                comboBox6.SelectedIndex = -1;
                comboBox7.SelectedIndex = -1;
                comboBox8.SelectedIndex = -1;
                comboBox9.SelectedIndex = -1;

            }
            catch (System.NullReferenceException)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Не полностью введены данные о територии!", "Ошибка", buttons);
            }
            catch (System.FormatException)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Неправильно введены числовые данные!", "Ошибка", buttons);
            }
            catch (MyException exp)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(exp.GetMessage(), "Ошибка", buttons);
            }
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void AddingElement_Load(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}

