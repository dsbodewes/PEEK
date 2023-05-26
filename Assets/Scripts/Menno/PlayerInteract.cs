using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    public int holdKey = 5;
    public float range = 2;
    float holdTimer;

    int totalGenerators = 0;

    Interaction interaction;

    bool isUsedGen1 = false;
    bool isUsedGen2 = false;
    bool isUsedGen3 = false;
    bool isUsedGen4 = false;
    bool isUsedSwitch = false;
    bool isUsedWell = false;

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

        if (Physics.Raycast(ray, out hit, range))
        {
            //Generator 1
            if (hit.collider.tag == "generator1")
            {
                if (Input.GetKey("e"))
                {
                    holdTimer -= Time.deltaTime;
                    if (holdTimer < 0)
                    {
                        if (isUsedGen1 == false)
                        {
                            Generator1();
                        }
                    }
                }
                else
                    holdTimer = holdKey;
            }

            //Generator 2
            if (hit.collider.tag == "generator2")
            {
                if (Input.GetKey("e"))
                {
                    holdTimer -= Time.deltaTime;
                    if (holdTimer < 0)
                    {
                        if (isUsedGen2 == false)
                        {
                            Generator2();
                        }
                    }
                }
                else
                    holdTimer = holdKey;
            }

            //Generator 3
            if (hit.collider.tag == "generator3")
            {
                if (Input.GetKey("e"))
                {
                    holdTimer -= Time.deltaTime;
                    if (holdTimer < 0)
                    {
                        if (isUsedGen3 == false)
                        {
                            Generator3();
                        }
                    }
                }
                else
                    holdTimer = holdKey;
            }

            //Generator 4
            else if (hit.collider.tag == "generator4")
            {
                if (Input.GetKey("e"))
                {
                    holdTimer -= Time.deltaTime;
                    if (holdTimer < 0)
                    {
                        if (isUsedGen4 == false)
                        {
                            Generator4();
                        }
                    }
                }
                else
                    holdTimer = holdKey;
            }

            //switch
            else if (hit.collider.tag == "switch")
            {
                if (Input.GetKey("e"))
                {
                    holdTimer -= Time.deltaTime;
                    if (holdTimer < 0)
                    {
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
                    holdTimer = holdKey;
            }

            //well
            else if (hit.collider.tag == "well")
            {
                if (Input.GetKey("e"))
                {
                    holdTimer -= Time.deltaTime;
                    if (holdTimer < 0)
                    {
                        if (isUsedWell == false)
                        {
                            well();
                        }
                    }
                }
                else
                    holdTimer = holdKey;
            }

            //object
            else if (hit.collider.tag == "information")
            {
                if (Input.GetKey("e"))
                {
                    interaction.Object();
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
}