using System.Xml.Serialization;

namespace Entity
{
    [XmlRoot("Replica")]
    public class ReplicaEntity
    {
        [XmlAttribute("type")]
        public string type;

        [XmlAttribute("text")]
        public string text;

		[XmlAttribute("texture")]
		public string texture;
    }
}