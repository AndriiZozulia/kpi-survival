using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenObjectsManager : MiniGameAction
{
	public static HiddenObjectsManager Instance;
	public int scoreDiff = 0;

    protected new void Start()
    {
        base.Start();
        Instance = this;
    }

    public static HiddenObjectsManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new HiddenObjectsManager();
        }
        return Instance;
    }

    public void OnLoss(int foundObjects)
    {
        scoreDiff += foundObjects;
    }

    public int OnVictory(float timeLeft, int numberOfObjects)
    {
        scoreDiff = (int)(numberOfObjects * (timeLeft / 10 + 1));
        return scoreDiff;
    }
}
