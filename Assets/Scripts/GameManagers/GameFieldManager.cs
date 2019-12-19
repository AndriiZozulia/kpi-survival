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
    static GameFieldManager Instance;

    QuestEntity currQuest;
    GameFieldState currState;

    GameObject UI;
    GameObject Dialog;
    GameObject MiniGame;
    GameObject Background;

    public static GameFieldManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new GameFieldManager();
            Instance.Load();
        }
        return Instance;
    }

    public void Load()
    {
        currQuest = QuestManager.GetInstance().GetQuest();
        currState = GameFieldState.Quest;
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

    void HidePrevious()
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

    void SetShowUI(bool show)
    {
        if (!UI)
        {
            UI = FindUtil.FindIncludingInactive("UI");
        }

        UI.SetActive(show);
    }

    void SetShowDialog(bool show)
    {
        if (!Dialog)
        {
            Dialog = DialogManager.GetInstance().GetDialogAction();
        }

        Dialog.SetActive(show);
    }

    void SetShowMiniGame(bool show)
    {
        MiniGame.SetActive(show);
    }
}
