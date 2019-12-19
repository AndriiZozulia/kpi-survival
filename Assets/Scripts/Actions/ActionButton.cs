
public class ActionButton : ActionButtonBaseHandler
{
    public ActionType type;
    public override void Action()
    {
        switch (type)
        {
            case ActionType.Dialog:
                GameFieldManager.GetInstance().SetGameFieldState(GameFieldState.Dialog);
                break;
            case ActionType.MiniGame:
                GameFieldManager.GetInstance().SetGameFieldState(GameFieldState.MiniGame);
                break;
        }

        base.Action();
        gameObject.SetActive(false);
    }
}
