using System.Xml.Serialization;

namespace Entity
{
    [XmlRoot("Replica")]
    public class ReplicaEntity
    {
        [XmlElement("text")]
        public string text;

		[XmlElement("texture")]
		public string texture;
    }
}