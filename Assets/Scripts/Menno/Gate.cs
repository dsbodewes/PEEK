using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject gateEnemy;

    public void GateEnemy()
    {
        gateEnemy.SetActive(false);
    }
}
