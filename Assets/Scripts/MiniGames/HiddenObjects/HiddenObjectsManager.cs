using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenObjectsManager : MiniGameAction
{
	public static HiddenObjectsManager Instance;
	public int  respectPoints;
    public int intelligencePoints;

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

    public void OnLoss(int respectObjects, int intelligenceObjects)
    {
        respectPoints = respectObjects;
        intelligencePoints = intelligenceObjects;
    }

    public void OnVictory(float timeLeft, int respectObjects, int intelligenceObjects)
    {
        respectPoints = (int)(respectObjects * (timeLeft / 10 + 1));
        intelligencePoints = (int)(intelligenceObjects * (timeLeft / 10 + 1));
    }

    public RatingEntity GetPoints()
    {
        return new RatingEntity(intelligencePoints, respectPoints);
    }
}
