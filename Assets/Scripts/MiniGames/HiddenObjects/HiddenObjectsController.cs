using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenObjectsController : MonoBehaviour
{
	[SerializeField] private Text uiTimer;
	[SerializeField] private Text uiScore;
	[SerializeField] private float mainTimer;
	

    private static int numberOfObjects=6;
    public static int foundObjects = 0;
    private static bool canCount = false;
    private static bool gameFinished = false;
	private static float timer;
    private static GameObject topEyelid;
    private static GameObject botEyelid;
    private static GameObject continueTxt;
    private static GameObject instructionTxt;
    

    // Start is called before the first frame update
    void Start()
    {
        Blink();

        timer = mainTimer;
    }

    // Update is called once per frame
    void Update()
    {
		UpdateTimer();
		CheckTimer();
        CheckVictory();

    }

    public static  void StartCount(){
		canCount = true;
	}
		
	void UpdateTimer()
	{
		if (timer >=0.0f && canCount)
		{

			timer -= Time.deltaTime;
			uiTimer.text = ((int)timer).ToString();
		} 
	}
	
	void CheckTimer(){
		if (timer <= 0.0f && !gameFinished){
            OnLoss();
            gameFinished = true;
		}
	}

    private void CheckVictory()
    {
        if (foundObjects == numberOfObjects && !gameFinished)
        {
            int score = HiddenObjectsManager.GetInstance().OnVictory(timer, numberOfObjects);

            uiScore.text = "Your score: " + score;
            GameObject.Find("ScoreBttn").GetComponent<Animation>().Play("ScoreAppearence");
            canCount = false;
            gameFinished = true;
            
        }
    }

    private void OnLoss()
    {
        HiddenObjectsManager.GetInstance().OnLoss(foundObjects);
       
        uiScore.text = "Your score: " + foundObjects;
        GameObject.Find("ScoreBttn").GetComponent<Animation>().Play("ScoreAppearence");
    }

    public static void Blink()
    {
        topEyelid = GameObject.Find("TopEyelid");
        botEyelid = GameObject.Find("BotEyelid");

        botEyelid.GetComponent<Animation>().Play("BlinkBot");
        topEyelid.GetComponent<Animation>().Play("BlinkTop");
    }

    public static void TextFadeIn()
    {
        instructionTxt = GameObject.Find("Instruction");
        continueTxt = GameObject.Find("Continue");
        instructionTxt.GetComponent<Animation>().Play("InstructionFadeIn");
        continueTxt.GetComponent<Animation>().Play("ContinueFadeIn");
    }
}
