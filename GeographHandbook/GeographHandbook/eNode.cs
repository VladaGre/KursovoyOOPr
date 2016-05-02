using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace GeographHandbook
{
    [Serializable]
    class eNode : ISerializable
    {
        private element _name;
        private eNode _next;
       public  eNode(element name)
        {
            _name = name;
            _next = null;
        }

       public eNode(element name,eNode next)
       {
           _name = name;
           _next = next;
       }

        public eNode(eNode old)
       {
           if (old._next == null)
           {
               _name = old._name;
               _next = null;
           }
           else
           {
                   _name = old._name;
                   _next = new eNode(old._next);
           }
       }

        public element GetElement()
        {
            return _name;
        }

        public eNode GetNext()
        {
            return _next;
        }
        public void Add(element name)
        {
            _next = new eNode(name,_next);
        }

        protected eNode(SerializationInfo info, StreamingContext context)//десериализация
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
 
            _name     = (element)info.GetValue("name",    typeof(element));
            _next    = (eNode)info.GetValue("next",   typeof(eNode));
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)//сериализация 
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            info.AddValue("name", _name);
            info.AddValue("next", _next);
        }
    }
}
