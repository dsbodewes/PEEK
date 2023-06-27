using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public AudioSource JsSound;
    public GameObject Player;
    public GameObject JsCam;
    public GameObject JsFlash;
    public Collider JsCollider;

    private void OnTriggerEnter()
    {
        if (JsCollider.gameObject.tag == "Player")
        {
            JsSound.Play();
            JsCam.SetActive(true);
            Player.SetActive(false);
            JsFlash.SetActive(true);
            StartCoroutine(JsEnd());
        }
    }

    IEnumerator JsEnd()
    {
        yield return new WaitForSeconds(1.46f);
        Player.SetActive(true); //Hier ga je dood, dit moet nog verander worden.
        JsCam.SetActive(false); //Deze gaat misscien weg.
        JsFlash.SetActive(false); //Geld ook voor deze.
    }

}
