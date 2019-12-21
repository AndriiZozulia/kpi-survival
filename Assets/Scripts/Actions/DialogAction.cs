using UnityEngine;
using Entity;
using UnityEngine.UI;
using System;

public class DialogAction : MonoBehaviour
{
    public string dialogID;
    public Text text;
    public Text decision_1;
    public Text decision_2;
    public Image image;

    bool isDecision;

    QuestEntity questEntity;
    DialogEntity dialogEntity;
    uint replicaIndex;

    public void SetDialog(string newDialogID)
    {
        dialogID = newDialogID;
        Init();

        SetBackground();

        text.gameObject.SetActive(false);
        decision_1.gameObject.SetActive(false);
        decision_2.gameObject.SetActive(false);

        UpdateText();
    }

    public void SetBackground()
    {
        var Background = FindUtil.FindIncludingInactive("Background");
        if (Background)
        {
            Background.GetComponent<Image>().sprite = Resources.Load<Sprite>(dialogEntity.texture);
            Background.SetActive(true);
        }
    }

    void UpdateText()
    {
        var replica = dialogEntity.replics[replicaIndex];

        if (replica != null)
        {
            var sprite = Resources.Load<Sprite>(replica.texture);
            if (sprite)
            {
                image.sprite = sprite;
                var rect = image.sprite.rect;
                image.transform.localScale = new Vector3(rect.width / 100.0f, rect.height / 100.0f, 0);
            }

            if (replica.type.Equals("phrase"))
            {
                isDecision = false;
                text.gameObject.SetActive(true);
                text.text = dialogEntity.replics[replicaIndex].text;
            }

            if (replica.type.Equals("decision"))
            {
                isDecision = true;
                var decisions = replica.text.Split(new char[] {'/'});
                if (decisions.Length == 2)
                {
                    decision_1.gameObject.SetActive(true);
                    decision_2.gameObject.SetActive(true);

                    FillDecision(decision_1.GetComponent<DecisionHandler>(), decision_1, decisions[0]);
                    FillDecision(decision_2.GetComponent<DecisionHandler>(), decision_2, decisions[1]);
                }
                else
                {
                    Debug.Log("Desicion string wrong: " + replica.text);
                    throw new IndexOutOfRangeException();
                }
            }
        }
        else
        {
            throw new NullReferenceException();
        }
    }

    void OnMouseUpAsButton()
    {
        if (isDecision)
        {
            return;
        }

        UpdateReplica();
    }

    public void CloseDialog()
    {
        text.gameObject.SetActive(false);
        decision_1.gameObject.SetActive(false);
        decision_2.gameObject.SetActive(false);

        gameObject.SetActive(false);
        GameManagerBehaviour.GetInstance().GetDialogManager().OnFinish();
    }

    void Init()
    {
        replicaIndex = 0;

        questEntity = GameManagerBehaviour.GetInstance().GetQuestManager().GetQuest();
        dialogEntity = questEntity.GetActionEntity(dialogID, ActionType.Dialog) as DialogEntity;
    }

    public void UpdateReplica()
    {
        if (replicaIndex < dialogEntity.replics.Length - 1)
        {
            text.gameObject.SetActive(false);
            decision_1.gameObject.SetActive(false);
            decision_2.gameObject.SetActive(false);

            replicaIndex += 1;
            UpdateText();
        }
        else
        {
            CloseDialog();
        }
    }

    void FillDecision(DecisionHandler handler, Text textField, string info)
    {

        var decInfo = info.Split(new char[] { '%' });
        var rating = decInfo[1].Split('#');

        switch(rating[0])
        {
            case "F": handler.rating = RatingPoint.Force; break;
            case "I": handler.rating = RatingPoint.Intelligence; break;
        }

        handler.Value = uint.Parse(rating[1]);
       
        textField.text = decInfo[0];
    }

}