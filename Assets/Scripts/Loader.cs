﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var saveManager = SaveManager.GetInstance();
        saveManager.LoadSettings();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
