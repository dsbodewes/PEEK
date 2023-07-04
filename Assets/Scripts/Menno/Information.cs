using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Information : MonoBehaviour
{
    public GameObject informationUI;
    public GameObject player;

    public float maxDistance = 3;

    public bool isInteracted { get; private set; }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log("The distance is:" + distance);

        if (distance > maxDistance)
        {
            informationUI.SetActive(false);
        }
    }
    public void Interaction()
    {
        informationUI.SetActive(true);
        isInteracted = true;
    }
}
