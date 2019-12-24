using UnityEngine;
using UnityEngine.UI;

public class Reverse : MiniGameAction
{
    public static bool isFinished = false;
    public static int score = 0;

    public void CheatOnTeacher()
    {
        var slide = ProgressSlider.slider.GetComponent<Slider>();
        var hSlide = HealthSlider.HSlider.GetComponent<Slider>();
        if (slide.value < 20)
        {
            if (hSlide.value > 0)
            {
                if (TestIndicator.isWatching == true)
                {
                    slide.value++;
                    score++;  //Score number adding
                }
                else
                {
                    hSlide.value--;
                }
            }
            else if (hSlide.value <= 0)
            {
                isFinished = true;
            }
        }
        else if (slide.value == 20)
        {
            isFinished = true;
        }
    }

    public static int gameFinished()
    {
        Time.timeScale = 0;
        return score;

    }
    public new void Start()
    {
        base.Start();

    }
    void Update()
    {
        if (isFinished == true)
        {
            OnFinish(new RatingEntity());
        }
    }
}

