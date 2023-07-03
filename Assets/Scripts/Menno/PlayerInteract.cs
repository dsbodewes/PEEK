using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    //Raycast
    public float range = 2;

    //Timer
    public int holdKey = 7;
    float holdTimer;
    public TimerUI timerUI;
    public GameObject timerHUD;

    //Generator
    public Generator currentGen;
    int totalGen = 0;

    //Switch
    bool isUsedSwitch = false;
    public UnityEvent Event_SwitchOn;

    //Well
    bool isUsedWell = false;
    public GameObject ObjectWell;
    public GameObject BucketWell;

    //Object
    public Information currentInfo;
    int totalObjects = 0;

    //HUD Text
    public TMP_Text topLeftText;
    public TMP_Text topRightText;
    public TypewriterUI typewriterUILeft;
    public TypewriterUI typewriterUIRight;

    //Gate
    public Gate gate;

    void Start()
    {
        holdTimer = holdKey;

        Event_SwitchOn = new UnityEvent();
        Event_SwitchOn.AddListener(Switch);
    }

    void Update()
    {
        //Timer
        holdTimer -= Time.deltaTime;

        //Raycast
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward * range));
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * range));

        if (Physics.Raycast(ray, out hit, range))
        {
            //Information
            Information information = hit.collider.GetComponent<Information>();
            currentInfo = information;

            //Generator
            Generator gen = hit.collider.GetComponent<Generator>();
            currentGen = gen;

            if (currentGen != null)
            {
                if (Input.GetKey("e"))
                {
                    timerHUD.gameObject.SetActive(true);
                    timerUI.SetValue();
                    if (holdTimer < 0)
                    {
                        Generator();
                        timerHUD.gameObject.SetActive(false);
                    }
                }
                else
                {
                    timerHUD.gameObject.SetActive(false);
                    timerUI.ResetValue();
                    holdTimer = holdKey;
                    currentGen.Stop();
                    currentGen = null;
                }
            }

            // Switch
            if (hit.collider.tag == "switch")
            {
                if (Input.GetKey("e"))
                {
                    if (totalGen >= 4)
                    {
                        if (isUsedSwitch == false)
                        {
                            timerHUD.gameObject.SetActive(true);
                            timerUI.SetValue();

                            if (holdTimer < 0)
                            {
                                timerHUD.gameObject.SetActive(false);
                                Event_SwitchOn.Invoke();
                                gate.GateEnemy();
                            }
                        }
                    }
                }
                else
                {
                    timerHUD.gameObject.SetActive(false);
                    timerUI.ResetValue();
                    holdTimer = holdKey;
                }
            }

            // Well
            if (hit.collider.tag == "well")
            {
                if (Input.GetKey("e"))
                {
                    if (isUsedWell == false)
                    {
                        timerHUD.gameObject.SetActive(true);

                        if (holdTimer < 0)
                        {
                            timerHUD.gameObject.SetActive(false);
                             well();
                        }
                    }
                }
                else
                {
                    timerHUD.gameObject.SetActive(false);
                    timerUI.ResetValue();
                    holdTimer = holdKey;
                }
            }

            // Object
            else if (currentInfo != null)
            {
                if (Input.GetKeyDown("e"))
                {
                    Object();
                }
                else
                {
                    currentInfo = null;
                }
            }
        }
    }

    //Methods
    void Switch()
    {
        if (isUsedSwitch == false)
        {
            topRightText.text = "ESCAPE";
            topLeftText.text = "Escape through the gate";
            typewriterUILeft.Type();
            typewriterUIRight.Type();
            isUsedSwitch = true;
        }
    }

    void well()
    {
        ObjectWell.SetActive(true);
        BucketWell.SetActive(true);
        isUsedWell = true;
    }

    void Generator()
    {
        if (totalObjects == 8)
        {
            currentGen.Play();
            totalGen++;

            if (totalGen < 4)
            {
                topRightText.text = "Total activated: " + totalGen + " / 4";
            }
            if (totalGen == 4)
            {
                topRightText.text = "Activate the switch";
                topLeftText.text = "Turn on the lights";
                typewriterUILeft.Type();
                typewriterUIRight.Type();
            }
        }
    }

    void Object()
    {
        currentInfo.Interaction();
        totalObjects++;

        if (totalObjects < 8)
        {
            topRightText.text = "Total clues found: " + totalObjects + " / 8";
        }
        if (totalObjects == 8)
        {
            topLeftText.text = "Fix the generators";
            topRightText.text = "Total activated: " + totalGen + " / 4";
            typewriterUILeft.Type();
            typewriterUIRight.Type();
        }
    }
}