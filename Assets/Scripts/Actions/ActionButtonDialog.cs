using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonDialog : ActionButtonBaseHandler
{
    public DialogAction dialogObject;

    public override void Action()
    {
        if (dialogObject)
        {
            dialogObject.gameObject.SetActive(true);
        }

        base.Action();

        gameObject.SetActive(false);
    }

    public void SetDialog(string dialogID)
    {
        dialogObject.SetDialog(dialogID);
    }
}
