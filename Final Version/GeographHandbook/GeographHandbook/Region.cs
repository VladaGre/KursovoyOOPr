using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace GeographHandbook
{
    public interface Region : Element
    {
        Country GetCParents();
        uint GetArea();
    }
    [Serializable]
   public class Oblast : Region // Область
    {
        string _name;
        uint _citizen;
        Country _cparents;
        uint _area;

        public uint GetArea()
        {
            return _area;
        }
        public Country GetCParents()
        {
            return _cparents;
        }

       public Oblast(string name,uint citizen,uint area,Country cparents)
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

        public ulong GetCitizen()
        {
            return _citizen;
        }

        protected Oblast(SerializationInfo info, StreamingContext context)// Десериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
 
            _citizen   = (uint)info.GetValue("citizen",  typeof(uint));
            _area = (uint)info.GetValue("area", typeof(uint));
            _name = (string)info.GetValue("name", typeof(string));
            _cparents = (Country)info.GetValue("cparents", typeof(Country));
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)// Сериализация
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
   public  class State : Region
    {
        string _name;
        uint _citizen;
        City _capital;
        uint _area;
        Country _cparents;// Страна-родитель

        public void SetCapital(City capital)// Назначить столицу
        {
            _capital = capital;
        }

        public City GetCapital()
        {
            return _capital;
        }
       public State(string name, uint citizen, uint area, Country cparents)
        {
            _name = name;
            _citizen = citizen;
            _capital = null;
            _area = area;
            _cparents = cparents;
        }

       public Country GetCParents()
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

        public ulong GetCitizen()
        {
            return _citizen;
        }

        protected State(SerializationInfo info, StreamingContext context)// Десериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
 
            _citizen   = (uint)info.GetValue("citizen",  typeof(uint));
            _area = (uint)info.GetValue("area", typeof(uint));
            _name = (string)info.GetValue("name", typeof(string));
            _cparents = (Country)info.GetValue("cparents", typeof(Country));
            _capital = (City)info.GetValue("capital", typeof(City));
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
         public virtual void GetObjectData(SerializationInfo info, StreamingContext context)// Сериализация
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
  public class Provinces : Region
    {
        string _name;
        uint _citizen;
        Country _cparents;// Страна-родитель
        uint _area;

       public Provinces(string name, uint citizen, uint area, Country cparents)
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

        public Country GetCParents()
        {
            return _cparents;
        }

        public string GetName()
        {
            return _name;
        }

        public ulong GetCitizen()
        {
            return _citizen;
        }

        protected Provinces(SerializationInfo info, StreamingContext context)// Десериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
 
            _citizen   = (uint)info.GetValue("citizen",  typeof(uint));
            _area = (uint)info.GetValue("area", typeof(uint));
            _name = (string)info.GetValue("name", typeof(string));
            _cparents = (Country)info.GetValue("cparents", typeof(Country));
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
         public virtual void GetObjectData(SerializationInfo info, StreamingContext context)// Сериализация
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
