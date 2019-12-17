using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;
using System;

public class TimerText : MonoBehaviour
{
     public float timer = 0.0f;
     public static int seconds = 0;
    public GameObject timerText;
    // Start is called before the first frame update
    void Start()
    {
         timerText = GameObject.FindWithTag("TimerText");
    }

    // Update is called once per frame
    void Update()
    {
         timer += Time.deltaTime;
         // turn seconds in float to int
         seconds = (int)(timer % 60);
         timerText.GetComponent<Text>().text = seconds.ToString();
    }
}
