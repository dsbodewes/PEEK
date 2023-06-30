using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public AudioSource JsSound;
    public GameObject JsFlash;
    public GameObject LoseUI;

    private void OnTriggerEnter(Collider JsCollider)
    {
        if (JsCollider.gameObject.tag == "Player")
        {
            ScareJump();
        }
    }

    IEnumerator JsEnd()
    {
        yield return new WaitForSeconds(1.46f);
        JsFlash.SetActive(false);
        Lose();
    }
    
    private void ScareJump()
    {
        JsSound.Play();
        JsFlash.SetActive(true);
        StartCoroutine(JsEnd());
    }

    private void Lose()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        LoseUI.SetActive(true);
    }
}
