using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//ilyi says hello
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public new Camera camera;

    private string groundTag = "Ground";

    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animator;

    private RaycastHit hit;
    public int maxDistance = 70;
    private Vector3 destination;

    public LayerMask moveMask;

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

            if (Physics.Raycast(ray, out hit, maxDistance, moveMask))
            {
                animator.SetBool("isRunning", true);
                destination = agent.destination;
                agent.SetDestination(hit.point);
            }
        }
        
        if (Vector3.Distance(destination, transform.position) < 0.1f)
        {
            animator.SetBool("isRunning", false);
        }
    }
}