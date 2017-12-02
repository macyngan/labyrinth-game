using UnityEngine;
using System.Collections;

public class BoardInput : MonoBehaviour {
    
    public float mouseSensitivity = 0.2f;

    private float h;
    private float v;

    void OnEnable() {

        // Any time this script is enabled, reset all input so the board stays even.
        Input.ResetInputAxes();
        h = 0;
        v = 0;

    }

    void Update() {

        h += mouseSensitivity * Input.GetAxis("Mouse X");
        v += mouseSensitivity * Input.GetAxis("Mouse Y");

        h = Mathf.Clamp(h, -15f, 15f);
        v = Mathf.Clamp(v, -15f, 15f);
        
        transform.localEulerAngles = new Vector3(-v, transform.localEulerAngles.y, h);

    }

}
