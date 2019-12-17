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

public class ProgressSlider : MonoBehaviour
{
    public static GameObject slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("ProgressSlider");
        slider.GetComponent<Slider>().value = 0;
    }

    // Update is called once per frame
    void Update(){}
}
