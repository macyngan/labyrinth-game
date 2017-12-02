using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour {

	[SerializeField]
	private List<GameObject> cameras;
	[SerializeField]
	private Image screenFader;

	private int activeCamera = 1;
	private int nextCamera;

	private float timer;
	private float timerDelay = 8f;

	private float fadeSpeed = 8f;

	void Start () {
		cameras [activeCamera].SetActive (true);
		nextCamera = activeCamera;
	}

	void Update () {

		if (GameManager.gameStarted == true) {
			
			SwitchCamera (0);

		} else {
			CycleCameras ();
		}
	}

	private void SwitchCamera(int cameraIndex) {

		if (cameraIndex != activeCamera) {

			// If the screen fader is less than (almost) full black
			if (screenFader.color.a <= 0.998f) {
				// continue lerping the screen fader towards black
				screenFader.color = Color.Lerp (screenFader.color, Color.black, fadeSpeed * Time.deltaTime);
			} else {

				// set the screen fader to black
				screenFader.color = Color.black;

				// Change active camera
				cameras [activeCamera].SetActive (false);
				activeCamera = cameraIndex;
				cameras [activeCamera].SetActive (true);
			}
		} else {

			// If the screen fader is not close to completely clear
			if (screenFader.color.a >= 0.002f) {
				// continue lerping the screen fader towards clear
				screenFader.color = Color.Lerp(screenFader.color, Color.clear, fadeSpeed * Time.deltaTime);
			} else {
				// set the screen fader to clear
				screenFader.color = Color.clear;
			}
		}
	}

	private void CycleCameras() {
		// Increment a timer to count up to restarting
		timer = timer + Time.deltaTime;

		// If the timer reaches the restart delay
		if(timer >= timerDelay) {
			timer = 0f;
			nextCamera++;

			if (nextCamera > cameras.Count - 1) {
				// reset to the first cinematic camera
				nextCamera = 1;
			}
		}

		SwitchCamera (nextCamera);
	}
}
