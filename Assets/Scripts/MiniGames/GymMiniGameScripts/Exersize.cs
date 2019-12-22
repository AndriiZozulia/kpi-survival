using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exersize : MonoBehaviour
{
    public static GameObject exersise;
    void Start()
    {
        exersise = GameObject.Find("Exersize");
        exersise.GetComponent<RawImage>();
    }

}
