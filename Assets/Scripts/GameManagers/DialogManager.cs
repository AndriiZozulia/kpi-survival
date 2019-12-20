using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogManager
{
    static DialogManager Instance;

    public static DialogManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new DialogManager();
            Instance.Load();
        }

        return Instance;
    }

    GameObject dialogAction;
    GameObject dialogBttn;

    public void Load()
    {
        dialogBttn = FindUtil.FindIncludingInactive("DialogButton");
        dialogAction = FindUtil.FindIncludingInactive("Dialog");
    }

    public void StartDialogAction(string dialogID, string texture)
    {
        if (dialogBttn)
        {
            dialogBttn.GetComponent<Image>().sprite = Resources.Load<Sprite>(texture);

            var rect = dialogBttn.GetComponent<Image>().sprite.rect;
            dialogBttn.transform.localScale = new Vector3(rect.width / 100.0f, rect.height / 100.0f, 0);

            dialogBttn.SetActive(true);
        }
        else
        {
            throw new NullReferenceException();
        }

        if (dialogAction)
        {
            dialogAction.GetComponent<DialogAction>().SetDialog(dialogID);
        }
        else
        {
            throw new NullReferenceException();
        }
    }

    public GameObject GetDialogAction()
    {
        if (!dialogAction)
        {
            Load();
        }

        return dialogAction;
    }

    public void OnFinish()
    {
        GameFieldManager.GetInstance().SetGameFieldState(GameFieldState.Quest);
        StoryControlerManager.GetInstance().OnActionFinish();
    }
}
