using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    //Raycast
    public float range = 2;

    //Interaction
    Interaction interaction;

    //Timer
    public int holdKey = 5;
    float holdTimer;
    public TimerUI timerUI;
    public GameObject timerHUD;

    // Generator
    int totalGenerators = 0;
    bool isUsedGen1 = false;
    bool isUsedGen2 = false;
    bool isUsedGen3 = false;
    bool isUsedGen4 = false;
    bool isUsedSwitch = false;
    bool isUsedWell = false;

    //Object
    int totalObjects = 0;

    //HUD Text
    public TMP_Text currentObjectiveText;
    public TMP_Text TotalFound;
    public TypewriterUI typewriterUILeft;
    public TypewriterUI typewriterUIRight;

    //Sounds
    public AudioSource GeneratorOn1;
    public AudioSource GeneratorOn2;
    public AudioSource GeneratorOn3;
    public AudioSource GeneratorOn4;
    //public AudioSource GeneratorFix;

    void Start()
    {
        holdTimer = holdKey;
        interaction = GameObject.FindGameObjectWithTag("information").GetComponent<Interaction>();
    }

    void Update()
    {
        //Raycast
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward * range));
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * range));

        holdTimer -= Time.deltaTime;

        if (Physics.Raycast(ray, out hit, range))
        {
            // Generator 1

            if (hit.collider.tag == "generator1")
            {
                if (Input.GetKey("e"))
                {
                    if (isUsedGen1 == false)
                    {
                        timerHUD.gameObject.SetActive(true);
                        timerUI.SetValue();
                        //GeneratorFix.Play();

                        if (holdTimer < 0)
                        {
                            Generator1();
                            timerHUD.gameObject.SetActive(false);
                        }
                    }
                }
                else
                {
                    timerHUD.gameObject.SetActive(false);
                    timerUI.ResetValue();
                    //GeneratorFix.Stop();
                    holdTimer = holdKey;
                }
            }

            // Generator 2

            if (hit.collider.tag == "generator2")
            {
                if (Input.GetKey("e"))
                {
                    if (isUsedGen1 == true)
                    {
                        if (isUsedGen2 == false)
                        {
                            timerHUD.gameObject.SetActive(true);
                            timerUI.SetValue();
                            //GeneratorFix.Play();

                            if (holdTimer < 0)
                            {
                                Generator2();
                                timerHUD.gameObject.SetActive(false);
                            }
                        }
                    }
                }
                else
                {
                    timerHUD.gameObject.SetActive(false);
                    timerUI.ResetValue();
                    //GeneratorFix.Stop();
                    holdTimer = holdKey;
                }
            }

            // Generator 3

            if (hit.collider.tag == "generator3")
            {
                if (Input.GetKey("e"))
                {
                    if (isUsedGen2 == true)
                    {
                        if (isUsedGen3 == false)
                        {
                            timerHUD.gameObject.SetActive(true);
                            timerUI.SetValue();
                            //GeneratorFix.Play();

                            if (holdTimer < 0)
                            {
                                Generator3();
                                timerHUD.gameObject.SetActive(false);
                            }
                        }
                    }
                }
                else
                {
                    timerHUD.gameObject.SetActive(false);
                    timerUI.ResetValue();
                    //GeneratorFix.Stop();
                    holdTimer = holdKey;
                }
            }

            // Generator 4

            if (hit.collider.tag == "generator4")
            {
                if (Input.GetKey("e"))
                {
                    if (isUsedGen3 == true)
                    {
                        if (isUsedGen4 == false)
                        {
                            timerHUD.gameObject.SetActive(true);
                            timerUI.SetValue();
                            //GeneratorFix.Play();

                            if (holdTimer < 0)
                            {
                                Generator4();
                                timerHUD.gameObject.SetActive(false);
                            }
                        }
                    }
                }
                else
                {
                    timerHUD.gameObject.SetActive(false);
                    timerUI.ResetValue();
                    //GeneratorFix.Stop();
                    holdTimer = holdKey;
                }
            }

            // Switch

            if (hit.collider.tag == "switch")
            {
                if (Input.GetKey("e"))
                {
                    if (isUsedGen4 == true)
                    {
                        if (isUsedSwitch == false)
                        {
                            timerHUD.gameObject.SetActive(true);
                            timerUI.SetValue();

                            if (holdTimer < 0)
                            {
                                Switch();
                                timerHUD.gameObject.SetActive(false);
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

            else if (hit.collider.tag == "information")
            {
                if (Input.GetKey("e"))
                {
                    Object();
                }
            }
        }
    }

    void Generator1()
    {
        totalGenerators++;
        GeneratorOn1.Play();
        TotalFound.text = "Total activated: " + totalGenerators + " / 4" ;
        isUsedGen1 = true;
    }
    void Generator2()
    {
        totalGenerators++;
        GeneratorOn2.Play();
        TotalFound.text = "Total activated: " + totalGenerators + " / 4";
        isUsedGen2 = true;
    }
    void Generator3()
    {
        totalGenerators++;
        GeneratorOn3.Play();
        TotalFound.text = "Total activated: " + totalGenerators + " / 4";
        isUsedGen3 = true;
    }
    void Generator4()
    {
        totalGenerators++;
        GeneratorOn4.Play();
        TotalFound.text = "Activate the switch";
        currentObjectiveText.text = "Turn on the lights";
        typewriterUILeft.Type();
        typewriterUIRight.Type();
        isUsedGen4 = true;
    }

    void Switch()
    {
        TotalFound.text = "ESCAPE";
        currentObjectiveText.text = "Escape through the gate";
        typewriterUILeft.Type();
        typewriterUIRight.Type();
        isUsedSwitch = true;
    }

    void well()
    {
        Debug.Log("its a well");
        isUsedWell = true;
    }

    void Object()
    {
        interaction.Object();
        totalObjects++;

        if (totalObjects < 8)
        {
            TotalFound.text = "Total clues found: " + totalObjects + " / 8";
        }
        
        if (totalObjects == 8)
        {
            currentObjectiveText.text = "Fix the generators";
            TotalFound.text = "Total activated: " + totalGenerators + " / 4";
            typewriterUILeft.Type();
            typewriterUIRight.Type();
        }
    }
}