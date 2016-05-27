using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace GeographHandbook
{
    [Serializable]
   public  struct Coordinates// Структура для хранения координат
    {
        public char _polarity;// Полярность
        public byte _degrees;// Градусы
        public byte _minutes;// Минуты
        public byte _seconds;// Секунды
    }
    [Serializable]
    public class City: Element
    {
        Coordinates []_adress;
        uint _citizens;
        string _name;
        Region _Rparents;// Ссылка на регион
        Country _Cparents;// Ссылка на страну
        Mainland _Mparents;// Ссылка на материк

        public Country GetCparents()
        {
            return _Cparents;
        }
        public Mainland GetMparents()
        {
            return _Mparents;
        }
        public Coordinates[] GetAdress()
        {
            return _adress;
        }
        public Region GetRparents()
        {
            return _Rparents;
        }
        public City(char latitude_polarity, byte latitude_degrees, byte latitude_minutes, byte latitude_seconds,
                    char longitude_polarity, byte longitude_degrees, byte longitude_minutes, byte longitude_seconds,
                    uint citizens, string name, Region Rparents, Country Cparents, Mainland Mparents)
        {
            _adress=new Coordinates[2];// Широта и долгота
            _adress[0]._degrees = latitude_degrees;
            _adress[0]._polarity = latitude_polarity;
            _adress[0]._minutes = latitude_minutes;
            _adress[0]._seconds = latitude_seconds;
            _adress[1]._degrees = longitude_degrees;
            _adress[1]._polarity = longitude_polarity;
            _adress[1]._minutes = longitude_minutes;
            _adress[1]._seconds = longitude_seconds;
            _citizens = citizens;
            _name = name;
            _Rparents = Rparents;
            _Cparents = Cparents;
            _Mparents = Mparents;
        }

        public string GetType()
        {
            return "Город";
        }

        public string GetName()
        {
            return _name;
        }

        public ulong GetCitizen()
        {
            return _citizens;
        }

        protected City(SerializationInfo info, StreamingContext context)// Десериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
 
            _citizens   = (uint)info.GetValue("citizen",  typeof(uint));
            _name = (string)info.GetValue("name", typeof(string));
            _Cparents = (Country)info.GetValue("cparents", typeof(Country));
            _Rparents = (Region)info.GetValue("rparents", typeof(Region));
            _Mparents = (Mainland)info.GetValue("mparents", typeof(Mainland));
            _adress = (Coordinates[])info.GetValue("adress", typeof(Coordinates[]));
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)// Сериализация 
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            info.AddValue("citizen", _citizens);
            info.AddValue("name", _name);
            info.AddValue("cparents", _Cparents);
            info.AddValue("mparents", _Mparents);
            info.AddValue("rparents", _Rparents);
            info.AddValue("adress", _adress);
            
        }

    }


}
