using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class PlayerMovement:MonoBehaviour{
    private Camera camera;
    public NavMeshAgent agent;
    private RaycastHit hit;
    public static Animator animator;
    public int maxDistance = 70;
    private Vector3 destination;
    public LayerMask moveMask;
    
    public float dashSpeed = 13.0f;
    public float dashDistance = 10.0f;
    public float walkSpeed = 8.0f;
    public float agentSpeed = 0;

    // Called when a script is enabled
    void Start(){
        animator = Player.instance.getAnimator();
        agent = GetComponent<NavMeshAgent>();
        agentSpeed = walkSpeed;
    }

    // Called once every frame
    void Update(){
        agent.speed = agentSpeed;
        if (!Player.instance.isDashing() && !Player.instance.isAttacking()){
            if (Input.GetMouseButton(0)){
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, maxDistance, moveMask)){
                    if (Vector3.Distance(hit.point, transform.position) < 0.3f){
                        animator.SetBool("isRunning", false);destination = transform.position;agent.ResetPath();return;}
                    agentSpeed = walkSpeed;
                    animator.SetBool("isRunning", true);
                    agent.SetDestination(hit.point);
                    destination = agent.destination;
                }
            }
            //Dashing
            if (Input.GetKeyDown("space")){
                float alpha = (float)((transform.rotation.eulerAngles.y % 360) * Math.PI)/180;
                Vector3 forward = new Vector3((float)Math.Sin(alpha), 0, (float)Math.Cos(alpha));
                Vector3 newDestination = transform.position + forward * (dashDistance);
                agent.SetDestination(newDestination);
                destination = agent.destination;
                agentSpeed = dashSpeed;
                animator.Play("Dash");
                animator.SetBool("isRunning", false);
            }

        }
        if (Vector3.Distance(destination, transform.position) == 0){
            agent.ResetPath();
            agentSpeed = walkSpeed;
            animator.SetBool("isRunning", false);
        }
        if (Player.instance.standAttack()){
            agent.ResetPath();
        }

        if (Player.instance.moveAttack()){
            agentSpeed = 5;
        }
    }

    public void Warp(Vector3 newPosition){
        agent.Warp(newPosition);
        animator.SetBool("isRunning", false);
    }

    public void setCamera(Camera camera){
        this.camera = camera;
    }

    public void setSpeed(float speed){
        agentSpeed = speed;
    }
}