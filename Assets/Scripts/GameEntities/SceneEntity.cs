using System.Xml.Serialization;

namespace Entity
{
    [XmlRoot("SceneEntity")]
    public class SceneEntity
    {
        [XmlElement("name")]
        public string name;
    }
}