using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Generator : MonoBehaviour
{
    int totalGen = 0;
    bool isGenOn = false;

    //Timer
    /*public int holdKey;
    float holdTimer;
    public TimerUI timerUI;
    public GameObject timerHUD;*/

    //Audio
    public AudioSource GenOnAudio;

    //UI
    public TMP_Text topLeftText;
    public TMP_Text topRightText;
    public TypewriterUI typewriterUILeft;
    public TypewriterUI typewriterUIRight;

    private void Start()
    {
        //holdTimer = holdKey;
    }

    private void Update()
    {
        //holdTimer -= Time.deltaTime;
    }

    public void Play()
    {
            if (isGenOn == false)
            {
                GenOnAudio.Play();
               // timerHUD.gameObject.SetActive(false);
                isGenOn = true;
            }   
    }

    public void Stop()
    {
        //timerHUD.gameObject.SetActive(false);
        //timerUI.ResetValue();
    }
}
