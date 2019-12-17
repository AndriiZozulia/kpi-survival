using UnityEngine;
using Entity;
using UnityEngine.UI;
using System;

public class DialogAction : MonoBehaviour
{
    public string dialogID;
    public Text text;

    private QuestEntity questEntity;
    private DialogEntity dialogEntity;
    private uint replicaIndex;

    public void SetDialog(string newDialogID)
    {
        dialogID = newDialogID;
        Init();
        UpdateText();
    }

    void UpdateText()
    {
        text.text = dialogEntity.replics[replicaIndex].text;
    }

    private void OnMouseUp()
    {
        if (replicaIndex < dialogEntity.replics.Length - 1)
        {
            replicaIndex += 1;
            UpdateText();
        }
        else
        {
            CloseDialog();
        }
    }

    public void CloseDialog()
    {
        gameObject.SetActive(false);
        GameManager.GetInstance().GetDialogManager().OnFinish();
    }

    private void Init()
    {
        replicaIndex = 0;

        questEntity = GameManager.GetInstance().GetQuestManager().GetQuest();
        dialogEntity = questEntity.GetDialogEntity(dialogID);
    }

}