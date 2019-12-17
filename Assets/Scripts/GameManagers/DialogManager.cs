using UnityEngine;
using UnityEngine.UI;
using Entity;

public class DialogManager
{
    private static DialogManager Instance;

    public static DialogManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new DialogManager();
        }

        return Instance;
    }

    public void StartDialogAction(string dialogID, string texture)
    {
        GameObject dialogBttn = FindUtil.FindIncludingInactive("DialogButton");
        if (dialogBttn)
        {
            dialogBttn.GetComponent<ActionButtonDialog>().SetDialog(dialogID);
            dialogBttn.GetComponent<Image>().sprite = Resources.Load<Sprite>(texture);
            dialogBttn.SetActive(true);
        }
        else
        {
            Debug.Log("dialogBttn == null");
        }
    }

    public void OnFinish()
    {
        GameManager.GetInstance().GetStoryControlerManager().OnActionFinish();
    }
}
