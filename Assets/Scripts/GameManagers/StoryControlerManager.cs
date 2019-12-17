using Entity;

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
        currQuest = GameManager.GetInstance().GetQuestManager().GetQuest();
        actionIndex = 0;
    }

    public static void StartStory()
    {
        GetInstance().Init();
        GetInstance().SetCurrActionOnScene();
    }

    private void SetCurrActionOnScene()
    {
        if (currQuest != null)
        {
            ActionEntity currAction = currQuest.actions[actionIndex];
            if (currAction.type.Equals("Dialog"))
            {
                GameManager.GetInstance().GetDialogManager().StartDialogAction(currAction.id, currAction.texture);
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
            GameManager.GetInstance().GetQuestManager().SetNextQuest();
            Init();
            StartStory();
        }
    }
            
}
