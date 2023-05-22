using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float holdKey = 5f;
    float holdTimer;

    public float range = 5;

    public Canvas information;
    // Start is called before the first frame update
    void Start()
    {
        holdTimer = holdKey;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * range));

        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            //Generator
            if (hit.collider.tag == "generator")
            {
                if (Input.GetKey("e"))
                {
                    holdTimer -= Time.deltaTime;
                    if (holdTimer < 0)

                        //function
                        Generator();
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

                        //function
                        Switch();
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

                        //function
                        well();
                }
                else
                    holdTimer = holdKey;
            }

            //object
            else if (hit.collider.tag == "object")
            {
                if (Input.GetKey("e"))
                {
                    Object();
                }
            }
        }
    }

    void Generator()
    {
        print("its a generator");
    }

    void Switch()
    {
        print("its a switch");
    }

    public void Object()
    {
        print("its a object");
        information.gameObject.SetActive(true);
    }

    void well()
    {
        print("its a well");
    }
}