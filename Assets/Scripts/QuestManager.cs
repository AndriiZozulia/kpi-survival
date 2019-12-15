using System;
using System.Xml.Serialization;
using Entity;

public class QuestManager
{
    [XmlElement("QuestID")]
    public string questID;

    [XmlArray("Quests"), XmlArrayItem("Quest")]
    public string[] quests;

    [XmlIgnore]
    private int _index = -1;

    public static QuestManager Load()
    {
        return XMLUtil.Deserialize<QuestManager>("Assets/base_mm/Quests.xml");
    }

    public static void Save(QuestManager questManager)
    {
        XMLUtil.Serialize(questManager, "Assets/base_mm/Quests.xml");
    }

    public string GetCurrQuestID()
    {
        if (_index < 0)
        {
            _index = Array.FindIndex(quests, element => element == questID);
        }

        if (_index > 0)
        {
            return quests[_index];
        }

        return null;
    }

    public string SetNextQuestID()
    {
        if (_index > 0 && _index < quests.Length - 1)
        {
            _index += 1;
            return quests[_index];
        }
        
        return null;
    }
}
