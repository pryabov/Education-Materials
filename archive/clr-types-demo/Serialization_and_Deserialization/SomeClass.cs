using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace Serialization_and_Deserialization
{
    [XmlRoot]
    public class SomeClass
    {
        public SomeClass() { }

        [XmlElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [XmlAttribute("creation-date")]
        [JsonProperty("creationDate")]
        public DateTime Date { get; set; }

        [XmlAttribute("value")]
        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
