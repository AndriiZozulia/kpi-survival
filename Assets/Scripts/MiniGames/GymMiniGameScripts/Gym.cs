using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;

public class Gym : MonoBehaviour
{
  Texture2D Up;
  Texture2D Down;
  public static bool isPressed = false;

   async public void makeGym() {
      var exr = Exersize.exersise.GetComponent<RawImage>();
      isPressed = true;
      exr.texture = Up;
      await Task.Delay(500);
      isPressed = false;
      exr.texture = Down;
      Circles.DrawBlue();
    }

    void Start(){
      Up = Resources.Load("UI/MiniGames/GymMiniGameUIElements/SportclubUP") as Texture2D;
      Down= Resources.Load("UI/MiniGames/GymMiniGameUIElements/SportclubDown") as Texture2D;
    }
}
