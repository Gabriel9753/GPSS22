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
    private static GameObject player;

    // Called when a script is enabled
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = gameObject;
    }

    // Called once every frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, maxDistance, moveMask))
            {
                agent.speed = 9;
                animator.SetBool("isRolling", false);
                animator.SetBool("isRunning", true);
                destination = agent.destination;
                agent.SetDestination(hit.point);
            }
        }

        if (Input.GetKeyDown("space"))
        {
            animator.Play("Rolling");
            animator.SetBool("isRolling", true);
            agent.speed = 5;
        }

        if (Vector3.Distance(destination, transform.position) < 0.1f)
        {
            animator.SetBool("isRunning", false);
        }
    }

    public static void Warp(Vector3 newPosition)
    {
        Debug.Log("Position: "+newPosition);
        agent.Warp(new Vector3(0.7f,0.3f,2.1f));
        animator.SetBool("isRunning", false);
        
    }
}