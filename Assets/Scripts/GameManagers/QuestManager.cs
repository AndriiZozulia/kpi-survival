using System;
using System.Xml.Serialization;
using Entity;
using UnityEngine;
using System.IO;

public class QuestManager 
{
    static QuestManager Instance;

    private const string basePath = "Assets/base_mm/";

    public string questID;

    [XmlArray("Quests"), XmlArrayItem("Quest")]
    public string[] quests;

    int _index = -1;

    QuestEntity questEntity;

    public static QuestManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new QuestManager();
            Instance.Load();
        }
        return Instance;
    }

    public void Load()
    {
        QuestManager questManager = XMLUtil.Deserialize<QuestManager>(Path.Combine(basePath, "Quests.xml"));

        var savedID = GameManagerBehaviour.GetInstance().GetSaveManager().GetSavedQuestID();
        questManager.questID = savedID ?? questManager.quests[0];
        questManager._index = Array.FindIndex(questManager.quests, element => element == questManager.questID);

        quests = questManager.quests;
        questID = questManager.questID;
        _index = questManager._index;

        Debug.Log(questID + " " + questID.Length + " " + _index);
    }

    public static void Save()
    {
        XMLUtil.Serialize(Instance, (Path.Combine(basePath, "Quests.xml")));
    }

    public string GetCurrQuestID()
    {
        if (_index < 0)
        {
            _index = Array.FindIndex(quests, element => element == questID);
        }

        if (_index >= 0)
        {
            return quests[_index];
        }

        throw new NullReferenceException();
    }

    public static string GetFirstQuestID()
    {
        return XMLUtil.Deserialize<QuestManager>(Path.Combine(basePath, "Quests.xml")).quests[0];
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

        if (Array.FindIndex(quests, element => element == findQuestID) != -1)
        {
            return XMLUtil.Deserialize<QuestEntity>(Path.Combine(basePath, "GameStory", findQuestID + ".xml"));
        }
        throw new NullReferenceException();
    }

    public int SetNextQuest()
    {
        if (_index >= 0 && _index < quests.Length - 1)
        {
            _index += 1;
            questID = quests[_index];
            questEntity = GetQuest();
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
