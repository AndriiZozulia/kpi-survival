using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
	public static string nameOfObj;
	public GameObject objNameTxt;
	
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
		HiddenObjectsController.foundObjects++;
		nameOfObj = gameObject.name;
        gameObject.SetActive(false);
        objNameTxt.SetActive(false);
	}
	
	
}
