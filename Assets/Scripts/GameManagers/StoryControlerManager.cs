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
        currQuest = QuestManager.GetInstance().GetQuest();
        actionIndex = loadOnInit ? SaveManager.GetInstance().GetSavedActionIndex() : 0;

        Debug.Log(currQuest.id + " " + actionIndex);
    }

    public void SetCurrActionOnScene()
    {
        if (currQuest != null)
        {
            ActionEntity currAction = currQuest.actions[actionIndex];

            switch(currAction.type)
            {
                case ActionType.Dialog:
                    DialogManager.GetInstance().StartDialogAction(currAction.id, currAction.texture);
                    break;
                case ActionType.MiniGame:
                    MiniGameManager.GetInstance().StartMiniGameAction(currAction.id, currAction.texture);
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
            int index = QuestManager.GetInstance().SetNextQuest();

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

        SaveManager.GetInstance().SavePlayer();
    }
            
}
