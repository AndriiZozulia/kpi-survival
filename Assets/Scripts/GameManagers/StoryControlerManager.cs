using Entity;
using UnityEngine;

public class StoryControlerManager
{
    private static StoryControlerManager Instance;

    public static StoryControlerManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new StoryControlerManager();
            Instance.Init();
        }
        return Instance;
    }

    private QuestEntity currQuest;
    private uint actionIndex;

    private void Init()
    {
        Debug.Log("StoryControlerManager -> Init()");
        currQuest = QuestManager.GetInstance().GetQuest();
        actionIndex = 0;
    }

    public void StartStory()
    {
        SetCurrActionOnScene();
    }

    private void SetCurrActionOnScene()
    {
        if (currQuest != null)
        {
            ActionEntity currAction = currQuest.actions[actionIndex];
            if (currAction.type.Equals("Dialog"))
            {
                DialogManager.GetInstance().StartDialogAction(currAction.id, currAction.texture);
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
            QuestManager.GetInstance().SetNextQuest();
            Init();
            StartStory();
        }
    }
            
}
