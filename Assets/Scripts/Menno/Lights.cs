using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public Material Light;

    public void LightsOn()
    {
       Light.EnableKeyword("_EMISSION");
    }
}
