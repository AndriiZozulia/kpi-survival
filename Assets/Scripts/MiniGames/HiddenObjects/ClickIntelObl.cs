using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickIntelObl : MonoBehaviour
{
	public static string nameOfObj;
	public GameObject objNameTxt;
	
    // Start is called before the first frame update
 
	void OnMouseDown()
	{
		HiddenObjectsController.foundObjects++;
        HiddenObjectsController.intelligenceObjects++;
		nameOfObj = gameObject.name;
        gameObject.SetActive(false);
        objNameTxt.SetActive(false);
	}
	
	
}


