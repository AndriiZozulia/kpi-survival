using System.Xml.Serialization;

namespace Entity
{
    [XmlRoot("DialogEntity")]
    public class DialogEntity
    {
        [XmlElement("text")]
        public string text;

		[XmlElement("texture")]
		public string texture;
    }
}