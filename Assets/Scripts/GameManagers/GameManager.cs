using UnityEngine;

public class GameManager
{
    static GameManager Instance;

    QuestManager questManager;
    StoryControlerManager storyControler;
    DialogManager dialogManager;
    GameFieldManager gameFieldManager;
    SaveManager saveManager;
    MiniGameManager miniGameManager;

    public static GameManager GetInstance()
    {
        if (Instance == null)
        {
            Init();
        }
        else
        {
            Instance.saveManager.Load(SaveType.Player);
            Instance.questManager.Load();
            Instance.dialogManager.Load();
            Instance.miniGameManager.Load();
            Instance.storyControler.Load();
            Instance.gameFieldManager.Load();
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

    public SaveManager GetSaveManager()
    {
        return saveManager;
    }

    public static void Init()
    {
        Instance = new GameManager();
        Instance.saveManager = SaveManager.GetInstance();
        Instance.saveManager.Load(SaveType.Player);
        Instance.questManager = QuestManager.GetInstance();
        Instance.dialogManager = DialogManager.GetInstance();
        Instance.miniGameManager = MiniGameManager.GetInstance();
        Instance.storyControler = StoryControlerManager.GetInstance();
        Instance.gameFieldManager = GameFieldManager.GetInstance();
    }

    public void StartGame()
    {
        gameFieldManager.SetGameFieldForQuest();
        storyControler.SetCurrActionOnScene();
    }
}
