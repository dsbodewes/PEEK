using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    public float range = 2;
    float holdTimer;

    public int holdKey = 5;
    int totalGenerators = 0;

    public TimerUI timerUI;
    Interaction interaction;

    bool isUsedGen1 = false;
    bool isUsedGen2 = false;
    bool isUsedGen3 = false;
    bool isUsedGen4 = false;
    bool isUsedSwitch = false;
    bool isUsedWell = false;

    public GameObject timerHUD;

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
                    timerHUD.gameObject.SetActive(true);
                    timerUI.SetValue();

                    if (holdTimer < 0)
                    {
                        timerHUD.gameObject.SetActive(false);

                        if (isUsedGen1 == false)
                        {
                            Generator1();
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

            // Generator 2

            if (hit.collider.tag == "generator2")
            {
                if (Input.GetKey("e"))
                {
                    timerHUD.gameObject.SetActive(true);

                    if (holdTimer < 0)
                    {
                        timerHUD.gameObject.SetActive(false);

                        if (isUsedGen2 == false)
                        {
                            Generator2();
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

            // Generator 3

            if (hit.collider.tag == "generator3")
            {
                if (Input.GetKey("e"))
                {
                    timerHUD.gameObject.SetActive(true);

                    if (holdTimer < 0)
                    {
                        timerHUD.gameObject.SetActive(false);

                        if (isUsedGen3 == false)
                        {
                            Generator3();
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

            // Generator 4

            if (hit.collider.tag == "generator4")
            {
                if (Input.GetKey("e"))
                {
                    timerHUD.gameObject.SetActive(true);

                    if (holdTimer < 0)
                    {
                        timerHUD.gameObject.SetActive(false);

                        if (isUsedGen4 == false)
                        {
                            Generator4();
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

            // Switch

            if (hit.collider.tag == "switch")
            {
                if (Input.GetKey("e"))
                {
                    timerHUD.gameObject.SetActive(true);

                    if (holdTimer < 0)
                    {
                        timerHUD.gameObject.SetActive(false);

                        if (totalGenerators >= 4)
                        {
                            if (isUsedSwitch == false)
                            {
                                Switch();
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
                    timerHUD.gameObject.SetActive(true);

                    if (holdTimer < 0)
                    {
                        timerHUD.gameObject.SetActive(false);

                        if (isUsedWell == false)
                        {
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
        print("Total generators: " + totalGenerators);
        isUsedGen1 = true;
    }
    void Generator2()
    {
        totalGenerators++;
        print("Total generators: " + totalGenerators);
        isUsedGen2 = true;
    }
    void Generator3()
    {
        totalGenerators++;
        print("Total generators: " + totalGenerators);
        isUsedGen3 = true;
    }
    void Generator4()
    {
        totalGenerators++;
        print("Total generators: " + totalGenerators);
        isUsedGen4 = true;
    }

    void Switch()
    {
        print("its a switch");
        isUsedSwitch = true;
    }

    void well()
    {
        print("its a well");
        isUsedWell = true;
    }

    void Object()
    {
        interaction.Object();
    }
}