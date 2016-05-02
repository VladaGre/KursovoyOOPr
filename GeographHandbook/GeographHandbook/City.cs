using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace GeographHandbook
{
    [Serializable]
   public  struct Coordinates//Для хранения координат
    {
        public char _polarity;//полярность
        public byte _degrees;//градусы
        public byte _minutes;//минуты
        public byte _seconds;//секунды
    }
    [Serializable]
    public class city: element
    {
        Coordinates []_adress;
        uint _citizens;
        string _name;
        region _Rparents;//ссылка на регион
        country _Cparents;//ссылка на страну
        mainland _Mparents;//ссылка на материк

        public country GetCparents()
        {
            return _Cparents;
        }
        public mainland GetMparents()
        {
            return _Mparents;
        }
        public Coordinates[] GetAdress()
        {
            return _adress;
        }
        public region GetRparents()
        {
            return _Rparents;
        }
        public city(char latitude_polarity, byte latitude_degrees, byte latitude_minutes, byte latitude_seconds,
                    char longitude_polarity, byte longitude_degrees, byte longitude_minutes, byte longitude_seconds,
                    uint citizens, string name, region Rparents, country Cparents, mainland Mparents)
        {
            _adress=new Coordinates[2];//широта и долгота
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

        public int GetCitizen()
        {
            return (int)_citizens;
        }

        protected city(SerializationInfo info, StreamingContext context)//десериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
 
            _citizens   = (uint)info.GetValue("citizen",  typeof(uint));
            _name = (string)info.GetValue("name", typeof(string));
            _Cparents = (country)info.GetValue("cparents", typeof(country));
            _Rparents = (region)info.GetValue("rparents", typeof(region));
            _Mparents = (mainland)info.GetValue("mparents", typeof(mainland));
            _adress = (Coordinates[])info.GetValue("adress", typeof(Coordinates[]));
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)//сериализация 
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
