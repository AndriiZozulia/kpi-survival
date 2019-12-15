﻿using UnityEngine;

public class ActionButtonBaseHandler : MonoBehaviour
{
    private SceneLoader _sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        _sceneLoader = GetComponent<SceneLoader>();    
    }

    virtual public void Action()
    {
        //Must be overrided
    }

    protected void OnMouseDown()
    {
        Debug.Log("ActionButtonBaseHandler -> OnMouseDown()");
        // Do some action and load scene
        Action();
        if (_sceneLoader)
        {
            _sceneLoader.LoadScene();
        }
    }
}