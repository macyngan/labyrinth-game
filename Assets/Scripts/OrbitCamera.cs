using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour {

	[SerializeField]
	private Transform target;
	[SerializeField]
	private float rotationSpeed = 10f;

	[SerializeField]
	private float bobPeriod = 2f;
	[SerializeField]
	private float bobAmplitude = 2f;

	private float startY;
	private float bobDistance;


	void Start () {
		
		// Store the start position of the camera
		startY = transform.localPosition.y;
	}
	

	void Update () {

		// Update the vertical camera bob
		bobDistance = Mathf.Sin(Time.timeSinceLevelLoad / bobPeriod) * bobAmplitude;

		transform.position = new Vector3 (transform.localPosition.x, startY + bobDistance, transform.localPosition.z);

		// Update the camera position
		transform.RotateAround(target.position, Vector3.up, rotationSpeed * Time.deltaTime);

		// Update the camera look
		transform.LookAt(target);
	}
}
