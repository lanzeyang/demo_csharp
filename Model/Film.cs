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
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "year")]
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
