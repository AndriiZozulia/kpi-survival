using UnityEngine;
using UnityEngine.UI;
using System;

public class MiniGameManager
{
    static MiniGameManager Instance;

    public static MiniGameManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new MiniGameManager();
            Instance.Load();
        }

        return Instance;
    }

    GameObject miniGameAction;
    GameObject miniGameBttn;

    public void Load()
    {
        miniGameBttn = FindUtil.FindIncludingInactive("MiniGameButton");
        miniGameAction = FindUtil.FindIncludingInactive("MiniGame");
    }

    public void StartMiniGameAction(string miniGameID, string texture, bool skip)
    {
        if (miniGameBttn && !skip)
        {
            miniGameBttn.GetComponent<Image>().sprite = Resources.Load<Sprite>(texture);

            var rect = miniGameBttn.GetComponent<Image>().sprite.rect;
            miniGameBttn.transform.localScale = new Vector3(rect.width / 100.0f, rect.height / 100.0f, 0);

            miniGameBttn.SetActive(!skip);
        }
        else
        {
            throw new NullReferenceException();
        }

        if (miniGameAction)
        {
            var mg = miniGameAction.GetComponent<MiniGameAction>();
            mg.SetMiniGame(miniGameID);

            if (skip)
            {
                mg.StartMiniGame();
            }
        }
        else
        {
            throw new NullReferenceException();
        }
    }

    public GameObject GetMiniGameAction()
    {
        if (!miniGameAction)
        {
            Load();
        }

        return miniGameAction;
    }

    public void OnFinish()
    {
        GameManagerBehaviour.GetInstance().GetGameFieldManager().SetGameFieldState(GameFieldState.Quest);
        GameManagerBehaviour.GetInstance().GetStoryControlerManager().OnActionFinish();
    }
}
