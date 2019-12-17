using UnityEngine;
using UnityEngine.UI;

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

