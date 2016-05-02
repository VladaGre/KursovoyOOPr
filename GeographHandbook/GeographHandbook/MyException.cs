using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeographHandbook
{
    public class MyException : System.ApplicationException//пользовательский Exception
    {
       private string _message;//сообщение об ошибке
       public MyException() { }//конструктор
       public MyException(string message) : base(message) { _message = message; }//конструктор, сохраняющий сообщение об ошибке

       public string GetMessage()
       {
           return _message;
       }
    }
}
