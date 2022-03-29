using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static bool isOtherPlayerHit = false;
    private static GameObject hitObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && isOtherPlayerHit == false)
        {
            isOtherPlayerHit = true;
            hitObject = other.gameObject;
        }
    }

    public static GameObject getHitObject()
    {
        return hitObject;
    }
    public static void setHitObjectNull()
    {
        hitObject = null;
    }
}
