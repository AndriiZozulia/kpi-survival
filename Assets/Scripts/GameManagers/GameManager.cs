public class GameManager
{
    private static GameManager Instance;
    private QuestManager _questManager;

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
        return _questManager;
    }

    public static void Init()
    {
        Instance = new GameManager
        {
            _questManager = QuestManager.GetInstance()
        };
    }
}
