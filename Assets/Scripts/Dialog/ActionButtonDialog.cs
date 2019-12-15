using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonDialog : ActionButtonBaseHandler
{
    public DialogManager dialogObject;

    public override void Action()
    {
        if (dialogObject)
        {
            dialogObject.gameObject.SetActive(true);
            dialogObject.SetDialog();
        }

        base.Action();

        gameObject.SetActive(false);
    }
}
