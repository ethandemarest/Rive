using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRadio : MonoBehaviour
{
    public AudioVolumeReader avr;
    public float scaleFactor; 
    void Update()
    {
        transform.localScale = new Vector3(1f, 1+ (avr.currentVolA * scaleFactor), 1f);
    }
}