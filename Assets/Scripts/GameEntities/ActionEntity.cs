using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Entity
{
    [XmlRoot("Action")]
    public class ActionEntity
    {
        [XmlAttribute("id")]
        public string id;

        [XmlAttribute("type")]
        public string type;

        [XmlAttribute("path")]
        public string path;

        [XmlAttribute("texture")]
        public string texture;
    }
}
