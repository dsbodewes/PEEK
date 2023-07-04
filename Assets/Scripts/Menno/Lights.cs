using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public GameObject Light;

    public void Start()
    {
        PlayerInteract pi = FindObjectOfType<PlayerInteract>();
    
        pi.Event_SwitchOn.AddListener(LightsOn);
    }
    public void LightsOn()
    {
        Light.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
    }
}
