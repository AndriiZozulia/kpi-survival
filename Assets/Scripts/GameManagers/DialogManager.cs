using UnityEngine;
using UnityEngine.UI;

public class DialogManager
{
    private static DialogManager Instance;

    public static DialogManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new DialogManager();
            Instance.Init();
        }

        return Instance;
    }

    private GameObject dialogAction;
    private GameObject dialogBttn;

    private void Init()
    {
        dialogBttn = FindUtil.FindIncludingInactive("DialogButton");
        dialogAction = FindUtil.FindIncludingInactive("Dialog");
    }

    public void StartDialogAction(string dialogID, string texture)
    {
        if (dialogBttn)
        {
            dialogBttn.GetComponent<Image>().sprite = Resources.Load<Sprite>(texture);
            dialogBttn.SetActive(true);
        }
        else
        {
            Debug.Log("dialogBttn == null");
        }

        if (dialogAction)
        {
            dialogAction.GetComponent<DialogAction>().SetDialog(dialogID);
        }
        else
        {
            Debug.Log("dialogAction == null");
        }
    }

    public GameObject GetDialogAction()
    {
        if (!dialogAction)
        {
            Init();
        }

        return dialogAction;
    }

    public void OnFinish()
    {
        GameFieldManager.GetInstance().SetGameFieldState(GameFieldState.Quest);
        StoryControlerManager.GetInstance().OnActionFinish();
    }
}
