using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
     
     public float multiplier = 1.4f;
     public float duration = 4f;
     public float durationTillRespawn = 5.0f;
     AudioSource myAudio;

     public GameObject pickupEffect;


     void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
        myAudio = GetComponent<AudioSource>();
        Invoke("playAudio", 12.0f);
           StartCoroutine (Pickup(other));
        }
    }  

    IEnumerator Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        player.transform.localScale *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(durationTillRespawn);

        player.transform.localScale /= multiplier;
        
    }
    void playAudio()
    {
        myAudio.Play();
    }

}