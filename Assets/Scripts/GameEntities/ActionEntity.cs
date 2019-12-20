using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

public enum ActionType
{
    [XmlEnum(Name = "Dialog")]
    Dialog,

    [XmlEnum(Name = "MiniGame")]
    MiniGame,

    [XmlEnum(Name = "Final")]
    Final
}

namespace Entity
{
    [XmlRoot("Action")]
    public class ActionEntity
    {
        [XmlAttribute("id")]
        public string id;

        [XmlAttribute("type")]
        public ActionType type;

        [XmlAttribute("path")]
        public string path;

        [XmlAttribute("texture")]
        public string texture;

        [XmlAttribute("skip")]
        public bool skip;
    }
}
