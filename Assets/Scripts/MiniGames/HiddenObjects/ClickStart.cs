using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickStart : MonoBehaviour
{
    [SerializeField] Text uiInstruction;
    [SerializeField] Text uiContinue;

    private static int clickTimes = 0;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {

        Color instractionColor = uiInstruction.color;
        Color continueColor = uiContinue.color;

        switch (clickTimes)
        {
            case 0:
                clickTimes++;
                HiddenObjectsController.Blink();
                uiInstruction.text = "У вас будет 30 секунд, \n чтобы найти все предметы" +
                    " указанные в правом столбе.\nУдачи!!";
                break;
            default: 
                HiddenObjectsController.Blink();
                gameObject.SetActive(false);
                HiddenObjectsController.StartCount();
                break;
        }
	}
}
