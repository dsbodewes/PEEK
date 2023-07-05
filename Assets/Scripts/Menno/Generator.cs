using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Generator : MonoBehaviour
{
    bool isGenOn = false;

    //Audio
    public AudioSource GenOnAudio;

    public void Play()
    {
            if (isGenOn == false)
            {
                GenOnAudio.Play();
                isGenOn = true;
            }   
    }
}
