﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnMouseDown()
	{
		HiddenObjectsManager.GetInstance().OnFinish(HiddenObjectsManager.GetInstance().GetPoints());
        
	}
}
