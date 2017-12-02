using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public float rotationsPerMinute;
	
    void Start () {

        // Apply a random rotation at the start of the game.
        transform.Rotate(0, 6.0f * rotationsPerMinute * Random.Range(0f, 100f), 0);

    }

	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 6.0f * rotationsPerMinute * Time.deltaTime, 0);
    }
}
