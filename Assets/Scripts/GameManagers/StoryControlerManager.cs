using Entity;
using UnityEngine;

public class StoryControlerManager
{
    static StoryControlerManager Instance;

    public static StoryControlerManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new StoryControlerManager();
            Instance.Load();
        }
        return Instance;
    }

    QuestEntity currQuest;
    int actionIndex;

    public void Load(bool loadOnInit = true)
    {
        currQuest = GameManagerBehaviour.GetInstance().GetQuestManager().GetQuest();
        actionIndex = loadOnInit ? GameManagerBehaviour.GetInstance().GetSaveManager().GetSavedActionIndex() : 0;

        Debug.Log(currQuest.id + " " + actionIndex);
    }

    public void SetCurrActionOnScene()
    {
        if (currQuest != null)
        {
            ActionEntity currAction = currQuest.actions[actionIndex];

            switch (currAction.type)
            {
                case ActionType.Dialog:
                    GameManagerBehaviour.GetInstance().GetDialogManager().StartDialogAction();
                    break;
                case ActionType.MiniGame:
                    GameManagerBehaviour.GetInstance().GetMiniGameManager().StartMiniGameAction();
                    break;
                case ActionType.Final:
                    GameManagerBehaviour.GetInstance().GetGameFieldManager().SetGameFieldState(GameFieldState.Final);
                    break;
            }

        }
    }

    public int GetActionIndex()
    {
        return actionIndex;
    }

    public void OnActionFinish()
    {
        if (actionIndex < currQuest.actions.Length - 1)
        {
            actionIndex += 1;
            SetCurrActionOnScene();
        }
        else
        {
            int index = GameManagerBehaviour.GetInstance().GetQuestManager().SetNextQuest();

            if (index > 0)
            {
                Load(false);
                SetCurrActionOnScene();
            }
            else
            {
                Debug.Log("End of storyline");
            }
        }

        GameManagerBehaviour.GetInstance().GetSaveManager().SavePlayer();
    }

    public ActionEntity GetCurrentAction()
    {
        return currQuest.actions[actionIndex];
    }
            
}
