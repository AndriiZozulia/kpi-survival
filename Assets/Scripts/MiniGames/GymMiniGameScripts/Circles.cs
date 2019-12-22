using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circles : MiniGameAction
{
    public GameObject firstCrcl;
    public GameObject secondCrcl;
    public GameObject thirdCrcl;
    public GameObject fourthCrcl;
    public static GameObject [] MarkedCircles = new GameObject[4];

    public static int index = 0;
    public static bool bluePrinted = false;
    public static int BlueCircles = 0;

 public new void Start()
    { 
        base.Start();
        MarkedCircles[0] = firstCrcl;
        MarkedCircles[1] = secondCrcl;
        MarkedCircles[2] = thirdCrcl;
        MarkedCircles[3] = fourthCrcl;
    }

   
    void Update(){
        if(!ReverseTimer.isFinished){
            CheckIndex();
        }
    }

    public void CheckIndex(){
        if(index == 4){
            ReverseTimer.isFinished = true;
            GetResult();
        }
    }
    public static void DrawBlue(){
        MarkedCircles[index].GetComponent<Image>().color = Color.blue;
        index++;
        bluePrinted = true;
        BlueCircles++;
    }

    public static void DrawRed(){
        MarkedCircles[index].GetComponent<Image>().color = Color.red;
        index++;
    }

    public void GetResult(){
        OnFinish(new RatingEntity());
    }
}

