using System;
using System.Xml.Serialization;
using Entity;
using UnityEngine;

public class QuestManager 
{
    public static QuestManager Instance;

    public static QuestManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = Load();
        }
        return Instance;
    }

    [XmlElement("QuestID")]
    public string questID;

    [XmlArray("Quests"), XmlArrayItem("Quest")]
    public string[] quests;

    [XmlIgnore]
    private int _index = -1;

    private static QuestManager Load()
    {
        QuestManager questManager = XMLUtil.Deserialize<QuestManager>("Assets/base_mm/Quests.xml");
        questManager._index = Array.FindIndex(questManager.quests, element => element == questManager.questID);
        return questManager;
    }

    public static void Save()
    {
        XMLUtil.Serialize(Instance, "Assets/base_mm/Quests.xml");
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

        Debug.Log("There is no curr quest");
        
        return null;
    }

    public QuestEntity GetCurrQuest()
    {
        return GetQuest(questID);
    }

    public QuestEntity GetQuest(string findQuestID)
    {
        if (Array.FindIndex(Instance.quests, element => element == findQuestID) != -1)
        {
            return XMLUtil.Deserialize<QuestEntity>("Assets/base_mm/GameStory/" + findQuestID + ".xml");
        }
        else
        {
            Debug.Log("There is no quest with id: " + findQuestID);
        }

        return null;
    }

    public string SetNextQuest()
    {
        string nextQuest = "";
        if (_index > 0 && _index < quests.Length - 1)
        {
            _index += 1;
            questID = quests[_index];
            nextQuest = questID;
        }

        return nextQuest;
    }
}
