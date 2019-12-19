using UnityEngine;
using Entity;

public class MiniGameAction : MonoBehaviour
{
    private SceneLoader sceneLoader;
    private MiniGameEntity miniGameEntity;

    protected void Start()
    {
        sceneLoader = GetComponent<SceneLoader>();
    }

    public void OnStart()
    {

    }

    public void OnFinish()
    {
        sceneLoader.sceneName = sceneLoader.GetLastLoadedScene().name;
        sceneLoader.LoadScene();
    }

    public void SetMiniGame(string id)
    {
        miniGameEntity = QuestManager.GetInstance().GetQuest().GetActionEntity(id, ActionType.MiniGame) as MiniGameEntity;
        sceneLoader.sceneName = miniGameEntity.scene;
    }

    public void StartMiniGame()
    {
        sceneLoader.LoadScene();
    }
}
