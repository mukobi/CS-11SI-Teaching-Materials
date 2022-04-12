using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitOfDoom : MonoBehaviour
{
    public Transform RespawnPosition;
    private GameObject MyPrefab;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello World!");
        Destroy(other.gameObject);
    }
}
