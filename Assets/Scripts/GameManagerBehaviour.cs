using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    bool updated = false;
    void Update()
    {
        if (updated)
        {
            return;
        }

        updated = true;
        GameManager.GetInstance().StartGame();    
    }
}
