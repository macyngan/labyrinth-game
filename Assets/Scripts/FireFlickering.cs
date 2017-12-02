using UnityEngine;
using System.Collections;

public class FireFlickering : MonoBehaviour {

    [SerializeField]
    private float flickerSpeed = 3f;

    [SerializeField]
    private float flickerIntensity = 2f;

    private Light fireLight;
    private float flicker;
    private float startLightIntensity;
    private Vector3 startPosition;

    private void Start() {
        flicker = 100f;
        fireLight = GetComponent<Light>();
        startLightIntensity = fireLight.intensity;
        startPosition = transform.localPosition;
    }


    private void Update() {
        fireLight.intensity = startLightIntensity + flickerIntensity * Mathf.PerlinNoise(flicker + Time.time * flickerSpeed, flicker + Time.time * flickerSpeed);
        float x = Mathf.PerlinNoise(flicker + 0 + Time.time * flickerSpeed, flicker + 1 + Time.time * flickerSpeed);
        float y = Mathf.PerlinNoise(flicker + 1 + Time.time * flickerSpeed, flicker + 1 + Time.time * flickerSpeed);
        transform.localPosition = new Vector3(startPosition.x + x, startPosition.y + y, startPosition.z);
    }
}
