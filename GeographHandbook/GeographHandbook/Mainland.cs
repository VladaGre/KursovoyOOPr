using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace GeographHandbook
{
    [Serializable]
    public class mainland : element
    {
       private uint   _area;//площадь
       private ulong  _citizen;//население
       private float  _density;//плотность
       private string _name;

        public uint GetArea()
       {
           return _area;
       }

        public float GetDensity()
        {
            return _density;
        }

        public mainland(uint area,ulong citizen,float density,string name)//конструктор
        {
            _area    = area;
            _citizen = citizen;
            _density = density;
            _name    = name;
        }

        mainland(mainland other)//конструктор//не используется
        {
            _area    = other._area;
            _citizen = other._citizen;
            _density = other._density;
            _name    = other._name;
        }

        public string GetType()
        {
            return  "Материк";
        }

        public string GetName()
        {
            return _name;
        }

        public int GetCitizen()
        {
            return (int)_citizen;
        }

        protected mainland(SerializationInfo info, StreamingContext context)//десериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
 
            _name   = (string)info.GetValue("size",  typeof(string));
            _area = (uint)info.GetValue("area", typeof(uint));
            _citizen = (ulong)info.GetValue("citizen", typeof(ulong));
            _density = (float)info.GetValue("density", typeof(float));
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)//сериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            info.AddValue("size", _name);
            info.AddValue("area", _area);
            info.AddValue("citizen", _citizen);
            info.AddValue("density", _density);
        }
    }
}
