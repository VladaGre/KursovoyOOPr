using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace GeographHandbook
   
{
     [Serializable]
   public class Country : Element
    {
        ulong _citizens;
        City _capital;// Ссылка на столицу
        uint _area;
        Mainland _Mparents;// Ссылка на материк
        string _name;
        string _board;

         public City GetCapital()
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
         public Mainland GetMparents()
        {
            return _Mparents;
        }

         public void SetCapital(City capital)// Задать столицу
         {
             _capital = capital;
         }
        public Country(ulong citizens, uint area, string name, string board, Mainland Mparents)
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

         public ulong GetCitizen()
         {
             return _citizens;
         }

         protected Country(SerializationInfo info, StreamingContext context)// Десериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
 
            _citizens   = (uint)info.GetValue("size",  typeof(uint));
            _capital = (City)info.GetValue("capital", typeof(City));
            _area = (uint)info.GetValue("area", typeof(uint));
            _Mparents = (Mainland)info.GetValue("Mparents", typeof(Mainland));
            _name = (string)info.GetValue("name", typeof(string));
            _board = (string)info.GetValue("board", typeof(string));            
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)// Сериализация 
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
