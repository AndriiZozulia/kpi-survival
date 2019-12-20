
public class ActionButton : ActionButtonBaseHandler
{
    public ActionType type;
    public override void Action()
    {
        switch (type)
        {
            case ActionType.Dialog:
                GameManagerBehaviour.GetInstance().GetGameFieldManager().SetGameFieldState(GameFieldState.Dialog);
                break;
            case ActionType.MiniGame:
                GameManagerBehaviour.GetInstance().GetGameFieldManager().SetGameFieldState(GameFieldState.MiniGame);
                break;
        }

        base.Action();
        gameObject.SetActive(false);
    }
}
