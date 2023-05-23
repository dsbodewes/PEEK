using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public Canvas information;

    public void Object()
    {
        print("its a object");
        information.gameObject.SetActive(true);
    }
}
