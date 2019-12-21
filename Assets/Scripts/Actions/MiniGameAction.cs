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

    public void OnFinish(RatingEntity rating)
    {
        GameManagerBehaviour.GetInstance().GetStoryControlerManager().OnActionFinish();
        GameManagerBehaviour.GetInstance().GetRatingManager().Add(RatingPoint.Intelligence, rating.intelligence);
        GameManagerBehaviour.GetInstance().GetRatingManager().Add(RatingPoint.Respect, rating.respect);
        sceneLoader.sceneName = sceneLoader.GetLastLoadedScene().name;
        sceneLoader.LoadScene();
    }

    public void SetMiniGame(string id)
    {
        miniGameEntity = GameManagerBehaviour.GetInstance().GetQuestManager().GetQuest().GetActionEntity(id, ActionType.MiniGame) as MiniGameEntity;
        sceneLoader.sceneName = miniGameEntity.scene;
    }

    public void StartMiniGame()
    {
        sceneLoader.LoadScene();
    }
}
