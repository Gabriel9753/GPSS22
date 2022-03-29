using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.05f;
    public Vector3 offset;
 
    private Vector3 velocity = Vector3.zero;
 
    void Update () {
        Vector3 goalPos = target.position + offset;
        transform.position = Vector3.SmoothDamp (transform.position, goalPos, ref velocity, smoothTime);
    }
}