using UnityEngine;
using System.Collections;

public class ScreenResizer : MonoBehaviour {

	void Start () {
        GetComponent<Camera>().orthographicSize = Screen.height / 2f;        	
	}
	
}
