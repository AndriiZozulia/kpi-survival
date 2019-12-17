using UnityEngine;
using UnityEngine.UI;
using System;

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

    private static GameObject dialogAction;
    private static GameObject dialogBttn;

    private void Init()
    {
        Debug.Log("DialogManager -> Init()");
        dialogBttn = FindUtil.FindIncludingInactive("DialogButton");
        dialogAction = FindUtil.FindIncludingInactive("Dialog");
    }

    public void StartDialogAction(string dialogID, string texture)
    {
        Init();
        if (dialogBttn)
        {
            dialogBttn.GetComponent<Image>().sprite = Resources.Load<Sprite>(texture);
            dialogBttn.SetActive(true);
        }
        else
        {
            Debug.Log("dialogBttn == null");
            throw new NullReferenceException();
        }

        if (dialogAction)
        {
            dialogAction.GetComponent<DialogAction>().SetDialog(dialogID);
        }
        else
        {
            Debug.Log("dialogAction == null");
            throw new NullReferenceException();
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
