using System.Xml.Serialization;

namespace Entity
{
    public class ActionBaseEntity { }

    [XmlRoot("DialogEntity")]
    public class DialogEntity : ActionBaseEntity
    {
        [XmlAttribute("id")]
        public string id;

        [XmlElement("BGTexture")]
        public string texture;

        [XmlArray("Replics"), XmlArrayItem("Replica")]
        public ReplicaEntity[] replics;
    }
}