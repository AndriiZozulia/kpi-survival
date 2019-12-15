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

        /*QuestManager questManager = new QuestManager();
        QuestEntity quest = new QuestEntity();
        DialogEntity dialog = new DialogEntity();
        dialog.text = "text1";
        quest.dialog = new DialogEntity[1];
        quest.dialog[0] = dialog;
        quest.id = "Chapter1/Day1/Ch1_Day1_Quest1";
        questManager.quests = new string[1];
        questManager.quests[0] = quest.id;
        questManager.questID = quest.id;

        XMLUtil.Serialize(quest, "Assets/base_mm/GameStory/" + quest.id + ".xml");
        XMLUtil.Serialize(questManager, "Assets/base_mm/Quests.xml");*/
    }
}