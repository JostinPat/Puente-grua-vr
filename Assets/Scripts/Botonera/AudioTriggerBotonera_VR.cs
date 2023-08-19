using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerBotonera_VR : MonoBehaviour
{
    public List<AudioSource> sources;
    bool audioSource_PuenteGrua;


    public GameObject cable;
    bool rotarCable;
    private void Start()
    {

    }
    void Update()
    {
        if (rotarCable) 
        {
            cable.gameObject.transform.Rotate(Vector3.right, 5f);
        }
    }



    public void play_stop_Audio(AudioSource audioSource)
    {
        audioSource_PuenteGrua = !audioSource_PuenteGrua;
        if (audioSource_PuenteGrua)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.UnPause();
            }
        }
        else 
        {
            audioSource.Pause();
        }
    }

    public void rotarCableFunction()
    {
        rotarCable = !rotarCable;
    }
    public void playAudio(AudioSource audioSource)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.UnPause();
        }
    }
    public void pauseAudio(AudioSource audioSource)
    {
        audioSource.Pause();
    }
}
