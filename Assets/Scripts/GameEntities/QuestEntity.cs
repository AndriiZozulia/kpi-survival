using System.Xml.Serialization;

namespace Entity
{
    [XmlRoot("Quest")]
    public class QuestEntity
    {
        [XmlAttribute("id")]
        public string id;

        [XmlArray("Dialog"), XmlArrayItem("Replica")]
        public DialogEntity[] dialog;
    }
}
