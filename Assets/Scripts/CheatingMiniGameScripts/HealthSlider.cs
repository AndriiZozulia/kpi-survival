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

public class HealthSlider : MonoBehaviour
{
    public static GameObject HSlider;
    void Start()
    {
        HSlider = GameObject.Find("HealthSlider");
        HSlider.GetComponent<Slider>().value = 3;
    }
    void Update(){}
}
