using UnityEngine;
using UnityEngine.UI;

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
