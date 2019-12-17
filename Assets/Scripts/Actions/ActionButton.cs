using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButton : ActionButtonBaseHandler
{
    public string type;
    public override void Action()
    {
        switch (type)
        {
            case "Dialog":
                GameFieldManager.GetInstance().SetGameFieldState(GameFieldState.Dialog);
                break;
            case "MiniGame": break;
        }

        base.Action();
        gameObject.SetActive(false);
    }
}
