using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitOfDoom : MonoBehaviour
{
    public Transform RespawnPosition;

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = RespawnPosition.position;
        other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.transform.rotation = Random.rotation;
    }
}
