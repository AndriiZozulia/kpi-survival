using UnityEngine;
using UnityEngine.SceneManagement;
using Entity;

public class SceneLoader : MonoBehaviour
{

    public string sceneName;

    public void LoadScene()
    {
        if (sceneName.Equals(""))
        {
            sceneName = XMLUtil.Deserialize<SceneEntity>("Assets/base_mm/LastLoadedScene.xml").name;
        }

        SaveLastScene();

        if (Application.CanStreamedLevelBeLoaded(sceneName))
        { 
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        else
        {
            Debug.Log("Scene with name \"" + sceneName + "\" is not exist");
        }
    }

    private void SaveLastScene()
    {
        SceneEntity sceneItem = new SceneEntity();
        sceneItem.name = SceneManager.GetActiveScene().name;

        XMLUtil.Serialize(sceneItem, "Assets/base_mm/LastLoadedScene.xml");

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
    }
}