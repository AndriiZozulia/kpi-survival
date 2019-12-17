public class GameManager
{
    private static GameManager Instance;
    private QuestManager questManager;
    private StoryControlerManager storyControler;
    private DialogManager dialogManager;
    private GameFieldManager gameFieldManager;

    public static GameManager GetInstance()
    {
        if (Instance == null)
        {
            Init();
        }
        return Instance;
    }

    public QuestManager GetQuestManager()
    {
        return questManager;
    }

    public StoryControlerManager GetStoryControlerManager()
    {
        return storyControler;
    }

    public DialogManager GetDialogManager()
    {
        return dialogManager;
    }

    public GameFieldManager GetGameFieldManager()
    {
        return gameFieldManager;
    }

    public static void Init()
    {
        Instance = new GameManager
        {
            questManager = QuestManager.GetInstance(),
            dialogManager = DialogManager.GetInstance(),
            storyControler = StoryControlerManager.GetInstance(),
            gameFieldManager = GameFieldManager.GetInstance()
        };
    }

    public void StartGame()
    {
        GameFieldManager.SetGameFieldForQuest();
        StoryControlerManager.StartStory();
    }
}
