using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReverseTimer : MonoBehaviour
{
  [SerializeField] private Text reverseTimer;
  [SerializeField] private float mainTimer;

  public static bool isFinished = false;
  private static float timer;

  void Start(){
        timer = mainTimer;
  }

  void Update(){
    UpdateTimer();
    CheckTimer();
  }
  void UpdateTimer()
  {
    if (timer >=0.0f)
    {
      timer -= Time.deltaTime;
      reverseTimer.text = ((int)timer).ToString();
    } 
  }
  void CheckTimer(){
    if (timer <= 0.0f && !isFinished){
      if(!Circles.bluePrinted){
        Circles.DrawRed();
      }
      Circles.bluePrinted = false;
       timer = 4.0f;
    }
  }
}