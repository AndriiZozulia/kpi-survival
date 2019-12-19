using System;
using UnityEngine;
using UnityEngine.UI;



public class DecisionHandler : MonoBehaviour
{
    public DialogAction dialog;
    Text text;

    RatingPoint _rating;
    uint _ratingValue;

    public uint Value
    {
        set
        {
            _ratingValue = value;
        }
    }

    public RatingPoint rating
    {
        set
        {
            _rating = value;
        }
    }

    bool down;

    private void Start()
    {
        down = false;
        text = GetComponent<Text>();
    }

    void OnMouseDown()
    {
        down = true;
    }

    void OnMouseExit()
    {
        text.color -= new Color(100, 100, 100);
        down = false;
    }

    private void OnMouseEnter()
    {
        text.color += new Color(100, 100, 100);
    }

    void OnMouseUp()
    {
        if (!down)
        {
            return;
        }

        if (dialog)
        {
            RatingManager.GetInstance().Add(_rating, _ratingValue);
            dialog.UpdateReplica();
        }
        else
        {
            throw new NullReferenceException();
        }
    }
}
