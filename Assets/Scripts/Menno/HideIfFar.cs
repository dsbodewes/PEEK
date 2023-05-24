using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIfFar : MonoBehaviour
{
    public GameObject player;
    public GameObject objectToHide;

    public float maxDistance = 3;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log("The distance is:" + distance);

        if(distance > maxDistance)
        {
            objectToHide.SetActive(false);
        }
    }
}
