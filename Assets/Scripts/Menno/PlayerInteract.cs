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
    public float holdTimer;
    public TimerUI timerUI;
    public GameObject timerHUD;

    //Generator
    public Generator currentGen;
    Dictionary<Generator, bool> activatedGenerators = new Dictionary<Generator, bool>();

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
    public GameObject InstructionUI;

    //Gate
    public Gate gate;

    //Enemy
    public GameObject enemy;

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
                InstructionUI.SetActive(true);
                if (Input.GetKey("e"))
                {
                    if (totalObjects == 8) // Check if totalObjects is 8
                    {
                        timerHUD.gameObject.SetActive(true);
                        timerUI.SetValue();
                        if (holdTimer < 0)
                        {
                            Generator();
                            timerHUD.gameObject.SetActive(false);
                        }
                    }
                }
                else
                {
                    timerHUD.gameObject.SetActive(false);
                    timerUI.ResetValue();
                    holdTimer = holdKey;
                    currentGen = null;
                }
            }

            // Switch
            if (hit.collider.tag == "switch")
            {
                InstructionUI.SetActive(true);
                if (Input.GetKey("e"))
                {
                    if (isUsedSwitch == false)
                    {
                        timerHUD.gameObject.SetActive(true);
                        timerUI.SetValue();

                        if (holdTimer < 0)
                        {
                            timerHUD.gameObject.SetActive(false);
                            enemy.gameObject.SetActive(false);
                            Event_SwitchOn.Invoke();
                            gate.GateEnemy();
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
                InstructionUI.SetActive(true);
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
                InstructionUI.SetActive(true);
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
        else
        {
            InstructionUI.SetActive(false);
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
        if (!activatedGenerators.ContainsKey(currentGen))
        {
            if (totalObjects == 8)
            {
                currentGen.Play();
                activatedGenerators.Add(currentGen, true);
                topRightText.text = "Total activated: " + activatedGenerators.Count + " / 4";
            }


            if (activatedGenerators.Count == 4)
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
        if (!currentInfo.isInteracted) // Check if the object is already interacted
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
                topRightText.text = "Total activated: " + activatedGenerators.Count + " / 4";
                typewriterUILeft.Type();
                typewriterUIRight.Type();
            }
        }
    }
}
