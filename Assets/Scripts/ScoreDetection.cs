using UnityEngine;
using System.Collections;

public class ScoreDetection : MonoBehaviour {

    public static bool scored = false;
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Goal Zone")) {
            scored = true;
        }
    }
}
