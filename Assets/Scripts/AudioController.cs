using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource BGM;
    public void changeBGM(AudioClip music)
    {        
        if (BGM.clip.name == music.name)
        {
            return;
        }
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
    public void stopBGM()
    {
        BGM.Stop();
    }
}
