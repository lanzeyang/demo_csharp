using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Model
{
    [Serializable]
    [DataContract]
    public class Film
    {
        [DataMember(Name = "prop1")]
        public string Name { get; set; }

        [DataMember(Name = "prop2")]
        public int Year { get; set; }

        public Film Clone()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, this);
            stream.Position = 0;
            return formatter.Deserialize(stream) as Film;
        }
    }
}
