using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//ilyi says hello
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;

    private string groundTag = "Ground";

    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animator;

    private RaycastHit hit;
    public int maxDistance = 70;
    private Vector3 destination;

    // Called when a script is enabled
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Called once every frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                if (hit.collider.CompareTag(groundTag))
                {
                    animator.SetBool("isRunning", true);
                    destination = agent.destination;
                    agent.SetDestination(hit.point);
                }
            }
        }
        
        if (Vector3.Distance(destination, transform.position) < 1f)
        {
            animator.SetBool("isRunning", false);
        }
    }
}