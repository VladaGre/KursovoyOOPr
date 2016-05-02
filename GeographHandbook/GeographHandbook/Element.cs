using System;
using System.Runtime.Serialization;


namespace GeographHandbook
{
     
     public interface element : ISerializable
    {
         string GetType();
         string GetName();
         int GetCitizen();
    }

}
