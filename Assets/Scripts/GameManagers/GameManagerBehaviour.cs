using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    static GameManagerBehaviour Instance;

    QuestManager questManager;
    StoryControlerManager storyControler;
    DialogManager dialogManager;
    GameFieldManager gameFieldManager;
    SaveManager saveManager;
    MiniGameManager miniGameManager;
    RatingManager ratingManager;

    bool updated;

    public static GameManagerBehaviour GetInstance()
    {
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

    public SaveManager GetSaveManager()
    {
        return saveManager;
    }

    public MiniGameManager GetMiniGameManager()
    {
        return miniGameManager;
    }

    public RatingManager GetRatingManager()
    {
        return ratingManager;
    }

    private void Init()
    {
        saveManager = SaveManager.GetInstance();
        saveManager.Load(SaveType.Player);

        ratingManager = RatingManager.GetInstance();
        ratingManager.Load();

        questManager = QuestManager.GetInstance();
        questManager.Load();

        dialogManager = DialogManager.GetInstance();
        dialogManager.Load();

        miniGameManager = MiniGameManager.GetInstance();
        miniGameManager.Load();

        storyControler = StoryControlerManager.GetInstance();
        storyControler.Load();

        gameFieldManager = GameFieldManager.GetInstance();
        gameFieldManager.Load();

        updated = false;
    }

    public void StartGame()
    {
        gameFieldManager.SetGameFieldForQuest();
        storyControler.SetCurrActionOnScene();
    }

    void Update()
    {
        if (updated)
        {
            return;
        }

        updated = true;
        GetInstance().StartGame();
    }

    private void Awake()
    {
        Instance = this;
        Instance.Init();
        DontDestroyOnLoad(gameObject);
    }
}
