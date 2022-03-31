using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    private static NavMeshAgent agent;
    private RaycastHit hit;
    private static Animator animator;
    public int maxDistance = 70;
    private Vector3 destination;
    public LayerMask moveMask;
    
    public float rollSpeed = 13.0f;
    public float walkSpeed = 8.0f;

    // Called when a script is enabled
    void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Called once every frame
    void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Rolling"))
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, maxDistance, moveMask))
                {
                    agent.speed = walkSpeed;
                    animator.SetBool("isRolling", false);
                    animator.SetBool("isRunning", true);
                    agent.SetDestination(hit.point);
                    destination = agent.destination;
                }
            }
            //Rolling
            if (Input.GetKeyDown("space"))
            {
                float alpha = (float)((transform.rotation.eulerAngles.y % 360) * Math.PI)/180;
                Vector3 forward = new Vector3((float)Math.Sin(alpha), 0, (float)Math.Cos(alpha));
                Vector3 newDestination = transform.position + forward * (rollSpeed+3.1f);
                agent.SetDestination(newDestination);
                destination = agent.destination;
                agent.speed = rollSpeed;
                animator.Play("Rolling");
                animator.SetBool("isRolling", true);
            }
            if (Vector3.Distance(destination, transform.position) < 0.1f)
            {
                agent.speed = walkSpeed;
                animator.SetBool("isRunning", false);
            }
        }

    }

    public static void Warp(Vector3 newPosition)
    {
        Debug.Log("Position: "+newPosition);
        agent.Warp(new Vector3(0.7f,0.3f,2.1f));
        animator.SetBool("isRunning", false);
        
    }
}