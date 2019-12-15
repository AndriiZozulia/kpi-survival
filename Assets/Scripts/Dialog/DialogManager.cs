using UnityEngine;
using Entity;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public string questID;
    public Text text;

    private QuestEntity questEntity;
    private uint replicaIndex;

    private void Awake()
    {
        replicaIndex = 0;

        if (questID.Equals(""))
        {
            questEntity = GameManager.GetInstance().GetQuestManager().GetCurrQuest();
        }
        else
        {
            questEntity = GameManager.GetInstance().GetQuestManager().GetQuest(questID);
        }

        Debug.Log("DialogManager Awake()");
    }

    public void SetDialog()
    {
        text.text = questEntity.dialog[replicaIndex].text;
    }

    private void OnMouseUp()
    {
        if (replicaIndex < questEntity.dialog.Length - 1)
        {
            replicaIndex += 1;
            SetDialog();
        }
        else
        {
            CloseDialog();
        }
    }

    public void CloseDialog()
    {
        gameObject.SetActive(false);
    }
}
