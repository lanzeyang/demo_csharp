using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Model
{
    [DataContract]
    public class WaterFee
    {
        [Newtonsoft.Json.JsonIgnore]
        [DataMember(Name = "prop0")]
        public string Name { get; set; }

        [DataMember(Name = "prop1")]
        public int Volume { get; set; }

        [DataMember(Name = "prop2")]
        public decimal Money { get; set; }
    }
}
