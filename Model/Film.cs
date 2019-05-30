using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Model
{
    [Serializable]
    public class Film
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public DateTime now { get; set; }

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
