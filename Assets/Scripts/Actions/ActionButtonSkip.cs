using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonSkip : ActionButtonBaseHandler
{
    public string type;
    public override void Action()
    {
        switch (type)
        {
            case "Dialog":
                DialogManager.GetInstance().OnFinish();
                break;
            case "MiniGame":break;
        }

        base.Action();
    }
}
