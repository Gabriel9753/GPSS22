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
        
    }

    // Called once every frame
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = gameObject;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, maxDistance, moveMask))
            {
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
        }

        if (Vector3.Distance(destination, transform.position) < 0.1f)
        {
            animator.SetBool("isRunning", false);
        }
        

    }

    public static void Warp(Vector3 newPosition)
    {
        agent.Warp(newPosition);
        animator.SetBool("isRunning", false);
        
    }
}