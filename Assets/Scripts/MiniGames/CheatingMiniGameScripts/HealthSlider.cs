using UnityEngine;
using UnityEngine.UI;

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
