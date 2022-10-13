using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumPopup;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnerLocation;
    public GameObject[] prefabsToSpawn;
    private GameObject[] prefabsToClone;

}


void Start ()
{
    prefabsToClone = new GameObject(prefabsToSpawn.Length);

    Spawn ();
}


void Spawn ()
{

}
