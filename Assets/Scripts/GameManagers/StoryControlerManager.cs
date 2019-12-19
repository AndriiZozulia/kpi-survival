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
    uint actionIndex;

    public void Load()
    {
        currQuest = QuestManager.GetInstance().GetQuest();
        actionIndex = 0;

        Debug.Log(currQuest.id);
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
                Load();
                SetCurrActionOnScene();
            }
            else
            {
                Debug.Log("End of storyline");
            }

            SaveManager.GetInstance().SavePlayer();
        }
    }
            
}
