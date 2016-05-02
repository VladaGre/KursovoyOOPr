using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace GeographHandbook
{
    public interface region : element
    {
        country GetCParents();
        uint GetArea();
    }
    [Serializable]
   public class oblast : region //область
    {
        string _name;
        uint _citizen;
        country _cparents;
        uint _area;

        public uint GetArea()
        {
            return _area;
        }
        public country GetCParents()
        {
            return _cparents;
        }

       public oblast(string name,uint citizen,uint area,country cparents)
        {
            _name = name;
            _citizen = citizen;
            _area = area;
            _cparents = cparents;
        }

        public string GetType()
        {
            return "Область";
        }

        public string GetName()
        {
            return _name;
        }

        public int GetCitizen()
        {
            return (int)_citizen;
        }

        protected oblast(SerializationInfo info, StreamingContext context)//десериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
 
            _citizen   = (uint)info.GetValue("citizen",  typeof(uint));
            _area = (uint)info.GetValue("area", typeof(uint));
            _name = (string)info.GetValue("name", typeof(string));
            _cparents = (country)info.GetValue("cparents", typeof(country));
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)//сериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            info.AddValue("citizen", _citizen);
            info.AddValue("area", _area);
            info.AddValue("name", _name);
            info.AddValue("cparents", _cparents);
            
        }
    }
    [Serializable]
   public  class state : region//штат
    {
        string _name;
        uint _citizen;
        city _capital;
        uint _area;
        country _cparents;//Странна родитель

        public void SetCapital(city capital)//Назначить столицу
        {
            _capital = capital;
        }

        public city GetCapital()
        {
            return _capital;
        }
       public state(string name, uint citizen, uint area, country cparents)
        {
            _name = name;
            _citizen = citizen;
            _capital = null;
            _area = area;
            _cparents = cparents;
        }

       public country GetCParents()
       {
           return _cparents;
       }

        public string GetType()
        {
            return "Штат";
        }

        public string GetName()
        {
            return _name;
        }

        public uint GetArea()
        {
            return _area;
        }

        public int GetCitizen()
        {
            return (int)_citizen;
        }

        protected state(SerializationInfo info, StreamingContext context)//десериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
 
            _citizen   = (uint)info.GetValue("citizen",  typeof(uint));
            _area = (uint)info.GetValue("area", typeof(uint));
            _name = (string)info.GetValue("name", typeof(string));
            _cparents = (country)info.GetValue("cparents", typeof(country));
            _capital = (city)info.GetValue("capital", typeof(city));
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
         public virtual void GetObjectData(SerializationInfo info, StreamingContext context)//сериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            info.AddValue("citizen", _citizen);
            info.AddValue("area", _area);
            info.AddValue("name", _name);
            info.AddValue("cparents", _cparents);
            info.AddValue("capital", _capital);
            
        }
    }
    [Serializable]
  public class provinces : region//провинция
    {
        string _name;
        uint _citizen;
        country _cparents;//Страна родитель
        uint _area;//площадь

       public provinces(string name, uint citizen, uint area, country cparents)
        {
            _name = name;
            _citizen = citizen;
            _area = area;
            _cparents = cparents;
        }

        public uint GetArea()
       {
           return _area;
       }
        public string GetType()
        {
            return "Провинция";
        }

        public country GetCParents()
        {
            return _cparents;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetCitizen()
        {
            return (int)_citizen;
        }

        protected provinces(SerializationInfo info, StreamingContext context)//десериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
 
            _citizen   = (uint)info.GetValue("citizen",  typeof(uint));
            _area = (uint)info.GetValue("area", typeof(uint));
            _name = (string)info.GetValue("name", typeof(string));
            _cparents = (country)info.GetValue("cparents", typeof(country));
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
         public virtual void GetObjectData(SerializationInfo info, StreamingContext context)//сериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            info.AddValue("citizen", _citizen);
            info.AddValue("area", _area);
            info.AddValue("name", _name);
            info.AddValue("cparents", _cparents);
            
        }
    }
    }
