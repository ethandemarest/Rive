using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCamera : MonoBehaviour
{
    public float rotateTime;
    public float rotateDistance;
    public float currentRot;
    public AnimationCurve animCurve;
    public AnimationCurve zoomCurve;
    public float zoomTime;

    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        StartCoroutine(Wave(-rotateDistance, rotateDistance));
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0f, currentRot, -currentRot));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Zoom(transform.position, transform.position + new Vector3(0,0,5f)));

        }
    }


    IEnumerator Wave(float start, float end)
    {
        float timeElapsed = 0;

        while (timeElapsed < rotateTime)
        {
            float t = timeElapsed / rotateTime;
            t = animCurve.Evaluate(t);
            currentRot = Mathf.Lerp(start, end, t);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        StartCoroutine(Wave(end, start));
    }

    IEnumerator Zoom(Vector3 start, Vector3 end)
    {
        float timeElapsed = 0;
        Vector3 tempPos = start;

        while (timeElapsed < zoomTime)
        {
            float t = timeElapsed / zoomTime;
            t = zoomCurve.Evaluate(t);
            tempPos = Vector3.Lerp(start, startPos, t);
            transform.position = Vector3.Lerp(tempPos, end, t);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
    }
}
