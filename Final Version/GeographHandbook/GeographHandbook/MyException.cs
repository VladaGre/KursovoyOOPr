using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeographHandbook
{
    public class MyException : System.ApplicationException// Пользовательский Exception
    {
       private string _message;// Сообщение об ошибке
       public MyException() { }
       public MyException(string message) : base(message) { _message = message; }// Конструктор, сохраняющий сообщение об ошибке

       public string GetMessage()
       {
           return _message;
       }
    }
}
