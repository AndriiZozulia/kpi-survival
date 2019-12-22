using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TestIndicator : MonoBehaviour
{
public static bool isWatching = true;
private bool isRunning = false;

Texture2D Looking;
Texture2D NotLooking;
public  GameObject testIndi;

    // Start is called before the first frame update
    void Start()
    {
        testIndi = GameObject.Find("TestIndicator");
        Looking = Resources.Load("UI/MiniGames/CheatingMiniGameUIElevents/TeacherLooking") as Texture2D;
        NotLooking= Resources.Load("UI/MiniGames/CheatingMiniGameUIElevents/TeacherNotLooking") as Texture2D;
    }

    // Update is called once per frame
    void Update(){
        Wrapper();
    }

public void Wrapper(){
        if(isRunning == false){
            StartCoroutine(instTestIndicator());
        }
 }

IEnumerator instTestIndicator () {
        var exr = testIndi.GetComponent<RawImage>();
        isRunning = true;
        if(TimerText.seconds < 20) {
            var random = new System.Random();
            var b = random.Next(2);
                if(b == 1){
                    isWatching = true;
                    exr.texture = NotLooking;
                } else {
                    isWatching = false;
                    exr.texture = Looking;
            }
        yield return new WaitForSeconds(1.5f);
        } else {
                Reverse.isFinished = true;
        }
        isRunning = false;
}
}




