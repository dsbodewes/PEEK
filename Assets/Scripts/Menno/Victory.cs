using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public Collider collision;
    public GameObject VictoryUI;

    void OnTriggerEnter()
    {
        if (collision)
        {
            VictoryUI.gameObject.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
