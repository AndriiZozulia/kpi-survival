using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entity;

public class Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var saveManager = SaveManager.GetInstance();
        //saveManager.CreatePlayerSave();
        saveManager.LoadSettings();

        /* 
       DialogEntity dialog = new DialogEntity
       {
           id = "Dialog1",
           replics = new ReplicaEntity[1]
       };

       dialog.replics[0] = new ReplicaEntity
       {
           text = "TEXT_1",
           texture = "/texture/path"
       };

       QuestEntity quest = new QuestEntity
       {
           day = "Chapter1/Day1",
           id = "Quest1",
           actions = new ActionEntity[1]
       };
       quest.actions[0] = new ActionEntity
       {
           id = dialog.id,
           type = "Dialog",
           path = dialog.id + ".xml"
       };

       QuestManager questManager = new QuestManager();

       questManager.quests = new string[1];
       questManager.quests[0] = quest.day + "/" + quest.id;
       questManager.questID = quest.day + "/" + quest.id;

       XMLUtil.Serialize(quest, "Assets/base_mm/GameStory/" + quest.day + "/" + quest.id + ".xml");
       XMLUtil.Serialize(dialog, "Assets/base_mm/GameStory/" + quest.day + "/Dialogs/" + quest.actions[0].path);
       XMLUtil.Serialize(questManager, "Assets/base_mm/Quests.xml");*/

        /*var mg = new MiniGameEntity
        {
            id = "MiniGameHO",
            difficulty = 0,
            scene = "HiddenObject"
        };
        XMLUtil.Serialize(mg, "Assets/base_mm/MiniGameHO.xml");*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
