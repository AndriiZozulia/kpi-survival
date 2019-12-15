using UnityEngine;

public class ButtonTapHandler : MonoBehaviour
{
	public float scaleStep = 0.05f;

    void OnMouseDown()
	{
		transform.localScale += new Vector3(scaleStep, scaleStep, 0);
	}

    void OnMouseUp()
	{
		transform.localScale -= new Vector3(scaleStep, scaleStep, 0);
	}
}
