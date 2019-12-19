﻿using UnityEngine;
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

    public void StartMiniGameAction(string miniGameID, string texture)
    {
        if (miniGameBttn)
        {
            miniGameBttn.GetComponent<Image>().sprite = Resources.Load<Sprite>(texture);
            miniGameBttn.SetActive(true);
        }
        else
        {
            throw new NullReferenceException();
        }

        if (miniGameAction)
        {
            miniGameAction.GetComponent<MiniGameAction>().SetMiniGame(miniGameID);
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
        GameFieldManager.GetInstance().SetGameFieldState(GameFieldState.Quest);
        StoryControlerManager.GetInstance().OnActionFinish();
    }
}
