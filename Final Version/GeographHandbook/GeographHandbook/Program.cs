using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeographHandbook
{
    
    static class Program
    {
        public static Hesh _main = new Hesh();
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
                Application.Run(new MainInterface());
            }
            catch
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Ваши действия привели к досрочному завершению программы!", "Ошибка", buttons);
            }

        }
    }
}
