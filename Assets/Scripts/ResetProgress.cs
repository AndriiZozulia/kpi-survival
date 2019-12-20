﻿using UnityEngine;
using UnityEngine.UI;

public class ResetProgress : MonoBehaviour
{
    public Text intelligence;
    public Text force;

    private bool reseted;
    // Start is called before the first frame update
    void Start()
    {
        reseted = false;
        var rating = GameManagerBehaviour.GetInstance().GetSaveManager().GetRating();
        intelligence.text = rating.intelligence.ToString();
        force.text = rating.force.ToString();
    }

    private void OnMouseUpAsButton()
    {
        reseted = true;
        intelligence.text = "0";
        force.text = "0";
    }

    public bool Reseted()
    {
        return reseted;
    }
}
