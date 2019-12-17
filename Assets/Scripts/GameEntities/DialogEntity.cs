using System.Xml.Serialization;

namespace Entity
{
    [XmlRoot("DialogEntity")]
    public class DialogEntity
    {
        [XmlAttribute("id")]
        public string id;

        [XmlElement("BGTexture")]
        public string texture;

        [XmlArray("Replics"), XmlArrayItem("Replica")]
        public ReplicaEntity[] replics;
    }
}