using System;
using System.Xml.Serialization;
using Entity;
using UnityEngine;

public class QuestManager 
{
    static QuestManager Instance;

    public static QuestManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new QuestManager();
            Instance.Load();
        }
        return Instance;
    }

    public string questID;

    [XmlArray("Quests"), XmlArrayItem("Quest")]
    public string[] quests;

    int _index = -1;

    public void Load()
    {
        QuestManager questManager = XMLUtil.Deserialize<QuestManager>("Assets/base_mm/Quests.xml");

        var savedID = SaveManager.GetInstance().GetSavedQuestID();
        questManager.questID = savedID == null ? questManager.GetFirstQuestID() : savedID;

        questManager._index = Array.FindIndex(questManager.quests, element => element == questManager.questID);

        quests = questManager.quests;
        questID = questManager.questID;
        _index = questManager._index;

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

        throw new NullReferenceException();
    }

    public string GetFirstQuestID()
    {
        return quests[0];
    }

    public string GetLastQuestID()
    {
        return quests[quests.Length - 1];
    }

    public QuestEntity GetQuest(string findQuestID = "default")
    {
        if (findQuestID.Equals("default"))
        {
            findQuestID = questID;
        }

        if (Array.FindIndex(Instance.quests, element => element == findQuestID) != -1)
        {
            return XMLUtil.Deserialize<QuestEntity>("Assets/base_mm/GameStory/" + findQuestID + ".xml");
        }

        throw new NullReferenceException();
    }

    public int SetNextQuest()
    {
        if (_index >= 0 && _index < quests.Length - 1)
        {
            _index += 1;
            questID = quests[_index];
        }
        else
        {
            _index = -1;
        }

        return _index;
    }

    public DialogEntity GetDialogEntity(string id, string findQuest = "default")
    {
        if (findQuest.Equals("default"))
        {
            return GetQuest().GetActionEntity(id, ActionType.Dialog) as DialogEntity;
        }

        return GetQuest(findQuest).GetActionEntity(id, ActionType.Dialog) as DialogEntity;
    }

    public MiniGameEntity GetMiniGameEntity(string id, string findQuest = "default")
    {
        if (findQuest.Equals("default"))
        {
            return GetQuest().GetActionEntity(id, ActionType.MiniGame) as MiniGameEntity;
        }

        return GetQuest(findQuest).GetActionEntity(id, ActionType.MiniGame) as MiniGameEntity;
    }
}
