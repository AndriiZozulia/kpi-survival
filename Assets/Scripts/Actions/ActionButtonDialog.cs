using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonDialog : ActionButtonBaseHandler
{
    public override void Action()
    {
        GameFieldManager.GetInstance().SetGameFieldState(GameFieldState.Dialog);

        base.Action();
        gameObject.SetActive(false);
    }
}
