using System.Xml.Serialization;
using System;

namespace Entity
{
    [XmlRoot("Quest")]
    public class QuestEntity
    {
        [XmlAttribute("id")]
        public string id;

        [XmlAttribute("day")]
        public string day;

        [XmlAttribute("background")]
        public string background;

        [XmlArray("Actions"), XmlArrayItem("Action")]
        public ActionEntity[] actions;

        public string GetQuestPath()
        {
            return "Assets/base_mm/GameStory/" + day + "/" + id + ".xml";
        }

        public string GetActionPath(int index)
        {
            string path;
            if (index >= 0 && index < actions.Length)
            {
                path = "Assets/base_mm/GameStory/" + day + "/Dialogs/" + actions[index].path;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

            return path;
        }

        public DialogEntity GetDialogEntity(string dialogID)
        {
            return XMLUtil.Deserialize<DialogEntity>(GetActionPath(Array.FindIndex(actions, element => element.id == dialogID)));
        }
    }
}
