using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TestIndicator : MonoBehaviour
{
float time = 3.0f;
public static bool isWatching = true;
private bool isRunning = false;
public  GameObject testIndi;

    // Start is called before the first frame update
    void Start()
    {
        testIndi = GameObject.Find("TestIndicator");
    }

    // Update is called once per frame
    void Update()
    {
           Wrapper();
    }

public void Wrapper(){
        if(isRunning == false){
            StartCoroutine(instTestIndicator());
        }
 }

IEnumerator instTestIndicator () {
        isRunning = true;
        if(TimerText.seconds < 50) {
            var random = new System.Random();
            var b = random.Next(2);
                if(b == 1){
                    isWatching = true;
                    testIndi.GetComponent<Image>().color = Color.blue;
                } else {
                    isWatching = false;
                    testIndi.GetComponent<Image>().color = Color.red;
            }
        yield return new WaitForSeconds(1.5f);
        } 
        isRunning = false;
}
}




