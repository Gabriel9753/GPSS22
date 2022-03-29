using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject[] otherTeleporters;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Ground")
        {
            GameObject otherT = otherTeleporters[0];
            other.transform.position = otherT.transform.position;
            Debug.Log(other.transform.position);
        }

    }
}
