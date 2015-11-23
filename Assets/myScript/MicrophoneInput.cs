using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour
{
    public float sensitivity = 100;
    public float loudness = 0;

    private AudioSource audios;

    void Start()
    {
        audios = GetComponent<AudioSource>() as AudioSource;
        audios.clip = Microphone.Start(null, true, 10, 44100);
        audios.loop = true; // Set the AudioClip to loop
        audios.mute = true; // Mute the sound, we don't want the player to hear it
        while (!(Microphone.GetPosition(Microphone.devices[0]) > 0)) { } // Wait until the recording has started
        audios.Play(); // Play the audio source!
    }

    void Update()
    {
        loudness = GetAveragedVolume() * sensitivity;
    }

    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        audios.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
}