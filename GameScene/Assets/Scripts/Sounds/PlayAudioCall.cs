using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioCall : MonoBehaviour
{
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        //audioData.Play(0);
    }

    public void playAudioTrack()
    {
        audioData.Play();
    }
    
    public void stopAudioTrack()
    {
        audioData.Stop();
    }
}
