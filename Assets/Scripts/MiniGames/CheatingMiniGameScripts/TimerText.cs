using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    public float timer = 0.0f;
    public static int seconds = 0;
    public GameObject timerText;
    // Start is called before the first frame update
    void Start(){
         timerText = GameObject.Find("TimerText");
    }

    // Update is called once per frame
    void Update(){
         timer += Time.deltaTime;
         seconds = (int)(timer % 60);
         timerText.GetComponent<Text>().text = seconds.ToString();
    }
}
