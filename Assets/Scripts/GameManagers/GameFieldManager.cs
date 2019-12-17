using Entity;
using UnityEngine;
using UnityEngine.UI;

public class GameFieldManager
{
    private static GameFieldManager Instance;

    public static GameFieldManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new GameFieldManager();
            Instance.Init();
        }
        return Instance;
    }

    private QuestEntity currQuest;

    private void Init()
    {
        currQuest = GameManager.GetInstance().GetQuestManager().GetQuest();
    }

    public static void SetGameFieldForQuest()
    {
        GetInstance().Init();
        GameObject background = FindUtil.FindIncludingInactive("Background");
        if (background)
        {
            background.GetComponent<Image>().sprite = Resources.Load<Sprite>(GetInstance().currQuest.background);
            background.SetActive(true);
        }
    }
}
