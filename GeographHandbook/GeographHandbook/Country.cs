using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace GeographHandbook
   
{
     [Serializable]
   public class country : element
    {
        ulong _citizens;
        city _capital;//ссылка на столицу
        uint _area;
        mainland _Mparents;//ссылка на материк
        string _name;
        string _board;

         public city GetCapital()
        {
            return _capital;
        }
         public uint GetArea()
        {
            return _area;
        }
         public string GetBoard()
        {
            return _board;
        }
         public mainland GetMparents()
        {
            return _Mparents;
        }

         public void SetCapital(city capital)//задать столицу
         {
             _capital = capital;
         }
        public country(ulong citizens,uint area,string name,string board,mainland Mparents)//конструктор
        {
            _citizens = citizens;
            _Mparents = Mparents;
            _capital  = null;
            _area     = area;
            _name     = name;
            _board    = board;
        }

         public string GetType()
         {
             return "Страна";
         }

         public string GetName()
         {
             return _name;
         }

         public int GetCitizen()
         {
             return (int)_citizens;
         }

         protected country(SerializationInfo info, StreamingContext context)//десериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
 
            _citizens   = (uint)info.GetValue("size",  typeof(uint));
            _capital = (city)info.GetValue("capital", typeof(city));
            _area = (uint)info.GetValue("area", typeof(uint));
            _Mparents = (mainland)info.GetValue("Mparents", typeof(mainland));
            _name = (string)info.GetValue("name", typeof(string));
            _board = (string)info.GetValue("board", typeof(string));            
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)//сериализация 
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            info.AddValue("size", _citizens);
            info.AddValue("capital", _capital);
            info.AddValue("area", _area);
            info.AddValue("Mparents", _Mparents);
            info.AddValue("name", _name);
            info.AddValue("board", _board);           
        }
    }
}
