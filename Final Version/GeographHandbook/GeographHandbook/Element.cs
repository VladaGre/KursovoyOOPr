using System;
using System.Runtime.Serialization;


namespace GeographHandbook
{
     
     public interface Element : ISerializable
    {
         string GetType();
         string GetName();
        ulong GetCitizen();
    }

}
