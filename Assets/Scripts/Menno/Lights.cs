using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public GameObject Light;
    //public PlayerInteract pi;
    public void Start()
    {
        LightsOn();
        //Find gameobject with PlayerInteract....
        PlayerInteract pi = GetComponent<PlayerInteract>();

        pi.Event_SwitchOn.AddListener(LightsOn);
    }
    public void LightsOn()
    {
        Light.SetActive(true);
    }
}
