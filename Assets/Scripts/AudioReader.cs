using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVolumeReader : MonoBehaviour
{
    public AudioSource audioSourceA;
    public AudioSource audioSourceB;
    public AudioSource audioSourceC;
    private float[] samples = new float[1024];
    public float currentVolA; // normalized volume 0–1
    public float currentVolB; // normalized volume 0–1
    public float currentVolC; // normalized volume 0–1

    private void Start()
    {
        // Schedule playback for a future DSP time
        double dspTime = AudioSettings.dspTime + 1.0; // Start 1 second from now
        audioSourceA.PlayScheduled(dspTime);
        audioSourceB.PlayScheduled(dspTime);
        audioSourceC.PlayScheduled(dspTime);
    }
    void Update()
    {
        currentVolA = GetRMSVolumeA();
        currentVolB = GetRMSVolumeB();
        currentVolC = GetRMSVolumeC();
    }

    float GetRMSVolumeA()
    {
        audioSourceA.GetOutputData(samples, 0);

        float sum = 0f;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i];
        }
        return Mathf.Sqrt(sum / samples.Length);
    }
    float GetRMSVolumeB()
    {
        audioSourceB.GetOutputData(samples, 0);

        float sum = 0f;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i];
        }
        return Mathf.Sqrt(sum / samples.Length);
    }
    float GetRMSVolumeC()
    {
        audioSourceC.GetOutputData(samples, 0);

        float sum = 0f;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i];
        }
        return Mathf.Sqrt(sum / samples.Length);
    }
}
