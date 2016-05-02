using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeographHandbook
{
    
    static class Program
    {
        public static hesh _main = new hesh();//хэш-таблица
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form2());
            }
            catch
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Ваши действия привели к досрочному завершению программы!", "Ошибка", buttons);
            }

        }
    }
}
