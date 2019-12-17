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
public class Reverse : MonoBehaviour
{
 
    public void CheatOnTeacher(){
     var slide =  ProgressSlider.slider.GetComponent<Slider>();
     var hSlide = HealthSlider.HSlider.GetComponent<Slider>();
       if (hSlide.value > 0) {
              if(TestIndicator.isWatching == true) {
                    slide.value++;
              } else {
                    hSlide.value--;
              }
       } else {
         Time.timeScale = 0;
       }
    }
    void Start(){}
    void Update(){}
}

