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

    public void StartDialogAction()
    {
        Load();

        var action = GameManagerBehaviour.GetInstance().GetStoryControlerManager().GetCurrentAction();

        if (action == null)
        {
            throw new NullReferenceException();
        }


        if (!action.skip)
        {
            if (dialogBttn)
            {
                var sprite = Resources.Load<Sprite>(action.texture);

                if (sprite)
                {
                    dialogBttn.GetComponent<Image>().sprite = sprite;

                    var rect = dialogBttn.GetComponent<Image>().sprite.rect;
                    dialogBttn.transform.localScale = new Vector3(rect.width / 100.0f, rect.height / 100.0f, 0);
                    dialogBttn.transform.localPosition = new Vector3(action.x, action.y, 0);
                    dialogBttn.SetActive(!action.skip);
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        if (dialogAction)
        {
            var dialog = dialogAction.GetComponent<DialogAction>();
            dialog.SetDialog(action.id);

            if (action.skip)
            {
                GameManagerBehaviour.GetInstance().GetGameFieldManager().SetGameFieldState(GameFieldState.Dialog);
                dialog.SetBackground();
            }
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
        GameManagerBehaviour.GetInstance().GetGameFieldManager().SetGameFieldState(GameFieldState.Quest);
        GameManagerBehaviour.GetInstance().GetStoryControlerManager().OnActionFinish();
    }
}
