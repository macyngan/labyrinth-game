using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallSounds : MonoBehaviour {

    [SerializeField]
    private AudioSource impactAudioSource;
    [SerializeField]
    private AudioSource rollingAudioSource;
    [SerializeField]
    private List<AudioClip> impactSounds = new List<AudioClip>();

    private Rigidbody ballRigidBody;
    private float velocityMultiplier = 1.2f;


    // Use this for initialization
    void Start () {

        ballRigidBody = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

        // Modulate the amplitude and pitch of the rolling ball sound based on the velocity.
        ModulateSoundVelocity(rollingAudioSource);

        // Modulate the amplitude and pitch of the impact sounds based on the velocity.
        ModulateSoundVelocity(impactAudioSource);

    }

    // If the player collides with another object...
    void OnCollisionEnter(Collision hit) {

        // ...then move the audio source to the location of the hit...
        impactAudioSource.transform.position = hit.contacts[0].point;

        // ...and if there's a significant impact...
        if (hit.relativeVelocity.magnitude > 0.3f) {

            //...play an impact sound...
            impactAudioSource.PlayOneShot(impactSounds[Random.Range(0, impactSounds.Count)]);

        }

    }


    // Modulate the volume and pitch of an AudioSource based on the velocity of a RigidBody
    private void ModulateSoundVelocity(AudioSource audioSource) {

        audioSource.volume = Mathf.Clamp01(ballRigidBody.velocity.magnitude);
        audioSource.pitch = Mathf.Clamp(ballRigidBody.velocity.magnitude * velocityMultiplier, 0.7f, 1.3f);

    }

}
