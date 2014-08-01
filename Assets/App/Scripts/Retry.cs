using UnityEngine;
using System.Collections;

public class Retry : MonoBehaviour
{
	void OnGUI()
	{
		if ( GUI.Button( new Rect(100, 100, 100, 20), "retry" ) )
		{
			Application.LoadLevel ("Main");
		}
	}
}
