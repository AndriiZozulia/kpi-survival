
public class ActionButtonSave : ActionButtonBaseHandler
{
    public ResetProgress reset;
    public override void Action()
    {
        if (reset.Reseted())
        {
            GameManagerBehaviour.GetInstance().GetSaveManager().CreatePlayerSave();
        }
    }
}
