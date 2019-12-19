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

        public string GetActionPath(int index, ActionType type)
        {

            string path;


            if (index >= 0 && index < actions.Length)
            {
                string typePath = "";
                switch (type)
                {
                    case ActionType.Dialog: typePath = "/Dialogs/"; break;
                    case ActionType.MiniGame: typePath = "/MiniGames/"; break;
                }

                path = "Assets/base_mm/GameStory/" + day + typePath + actions[index].path;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

            return path;
        }

        public ActionBaseEntity GetActionEntity(string id, ActionType type)
        {
            switch (type)
            {
                case ActionType.Dialog:
                    return XMLUtil.Deserialize<DialogEntity>(GetActionPath(Array.FindIndex(actions, element => element.id == id), type));

                case ActionType.MiniGame:
                    return XMLUtil.Deserialize<MiniGameEntity>(GetActionPath(Array.FindIndex(actions, element => element.id == id), type));
            }

            return null;
        }
    }
}
