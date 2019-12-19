using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObjectsBehaviour : MonoBehaviour
{
    bool updated = false;
    void Update()
    {
        if (updated)
        {
            return;
        }

        updated = true;
        HiddenObjectsManager.GetInstance().OnStart();
    }
}
