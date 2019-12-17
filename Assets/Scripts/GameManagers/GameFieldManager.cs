using Entity;
using UnityEngine;
using UnityEngine.UI;

public enum GameFieldState
{
    Dialog,
    Quest,
    MiniGame
}

public class GameFieldManager
{
    private static GameFieldManager Instance;

    private QuestEntity currQuest;
    private GameFieldState currState;

    private GameObject UI;
    private GameObject Dialog;
    private GameObject MiniGame;
    private GameObject Background;

    public static GameFieldManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new GameFieldManager();
            Instance.Init();
        }
        return Instance;
    }

    private void Init()
    {
        Debug.Log("GameFieldManager -> Init()");
        currQuest = QuestManager.GetInstance().GetQuest();
    }

    public void SetGameFieldForQuest()
    {
        Background = FindUtil.FindIncludingInactive("Background");
        if (Background)
        {
            Background.GetComponent<Image>().sprite = Resources.Load<Sprite>(GetInstance().currQuest.background);
            Background.SetActive(true);
        }
    }

    public void SetGameFieldState(GameFieldState state)
    {
        HidePrevious();
        switch (state)
        {
            case GameFieldState.Dialog:
                SetShowDialog(true);
                break;
            case GameFieldState.MiniGame:
                SetShowMiniGame(true);
                break;
            case GameFieldState.Quest:
                SetShowUI(true);
                break;
        }
        currState = state;
    }

    private void HidePrevious()
    {
        switch (currState)
        {
            case GameFieldState.Dialog:
                SetShowDialog(false);
                break;
            case GameFieldState.MiniGame:
                SetShowMiniGame(false);
                break;
            case GameFieldState.Quest:
                SetShowUI(false);
                break;
        }
    }

    private void SetShowUI(bool show)
    {
        if (!UI)
        {
            UI = FindUtil.FindIncludingInactive("UI");
        }

        UI.SetActive(show);
    }

    private void SetShowDialog(bool show)
    {
        if (!Dialog)
        {
            Dialog = DialogManager.GetInstance().GetDialogAction();
        }

        Dialog.SetActive(show);
    }

    private void SetShowMiniGame(bool show)
    {
        MiniGame.SetActive(show);
    }
}
