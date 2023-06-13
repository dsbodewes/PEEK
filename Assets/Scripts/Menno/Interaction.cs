using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public GameObject information;
    public GameObject player;

    public float maxDistance = 3;

    bool isUsedObject = false;

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log("The distance is:" + distance);

        if (distance > maxDistance)
        {
            information.SetActive(false);
        }
    }
    public void Object()
    {
        if (isUsedObject == false)
        {
            isUsedObject = true;
        }

        information.gameObject.SetActive(true);
    }
}
