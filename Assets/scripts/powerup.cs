using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
     
     public float multiplier = 1.4f;
     public float duration = 4f;

     public GameObject pickupEffect;


     void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
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

        player.transform.localScale /= multiplier;
        Destroy(gameObject);
    }

}