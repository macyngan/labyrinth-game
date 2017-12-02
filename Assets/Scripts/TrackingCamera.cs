using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour {

	[SerializeField]
	private float XAmplitude = 5f;
	[SerializeField]
	private float YAmplitude = 5f;
	[SerializeField]
	private float ZAmplitude = 5f;

	[SerializeField]
	private float timePeriod = 5f;

	private Vector3 startPosition;

	void Start () {

		// Store the start position of the camera
		startPosition = transform.localPosition;
	}

	void Update () {

		float theta = Mathf.Sin (Time.timeSinceLevelLoad / timePeriod);

		Vector3 deltaPosition = new Vector3 (XAmplitude, YAmplitude, ZAmplitude) * theta;

		transform.localPosition = startPosition + deltaPosition;
	}
}
