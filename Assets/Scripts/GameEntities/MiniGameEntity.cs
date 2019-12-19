using System.Xml.Serialization;

namespace Entity
{
    [XmlRoot("MiniGameEntity")]
    public class MiniGameEntity : ActionBaseEntity
    {
        [XmlAttribute("id")]
        public string id;

        [XmlAttribute("difficulty")]
        public int difficulty;

        [XmlAttribute("scene")]
        public string scene;
    }
}
