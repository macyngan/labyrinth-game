using UnityEngine;
using System.Collections;

public class Screenshot : MonoBehaviour {
	
	// Update is called once per frame
	void LateUpdate () {

        if (Input.GetKeyDown(KeyCode.P)) {
            ScreenCapture.CaptureScreenshot("Screenshot.png", 2);
        }

	}
}
