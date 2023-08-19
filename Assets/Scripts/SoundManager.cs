using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioSource> myAudioSources;
    void Start()
    {

    }

    public void playDifferentSounds(List<AudioClip> audios) 
    {
        for (int i = 0; i < audios.Count; i++)
        {
            myAudioSources.Add(this.gameObject.AddComponent<AudioSource>());
            myAudioSources[i].clip = audios[i];
            myAudioSources[i].loop = true;
            myAudioSources[i].Play();

        }
    }
    public void activeSound(int AudioSourceIndice) 
    {
        if (myAudioSources.Count > AudioSourceIndice) 
        {
            myAudioSources[AudioSourceIndice].volume = 0.5f;
        }
    }
    public void desactiveSound(int AudioSourceIndice) 
    {
        if (myAudioSources.Count > AudioSourceIndice)
        {
            myAudioSources[AudioSourceIndice].volume = 0f;
        }
    }
}
