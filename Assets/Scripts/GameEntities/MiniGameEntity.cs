using System.Xml.Serialization;

namespace Entity
{
    [XmlRoot("MiniGame")]
    public class MiniGameEntity
    {
        [XmlAttribute("id")]
        public string id;

        [XmlAttribute("difficulty")]
        public int difficulty;


    }
}
