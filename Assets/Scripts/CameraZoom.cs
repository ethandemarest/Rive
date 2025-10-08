using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public AudioVolumeReader avr;
    public float scaleFactor;
    void Update()
    {
        transform.position = new Vector3(0f, 0f, -20 + (avr.currentVolA * scaleFactor));
    }
}
