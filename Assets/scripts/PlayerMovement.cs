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

    private Vector3 startScale;
    public Vector3 dashScale;
    public float shrinkDuration;
    public GameObject dashVFX;

    // Called when a script is enabled
    void Start(){
        animator = Player.instance.getAnimator();
        agent = GetComponent<NavMeshAgent>();
        agentSpeed = walkSpeed;

        startScale = transform.localScale;
    }

    // Called once every frame
    void Update(){
        agent.speed = agentSpeed;
        if (!Player.instance.isDashing() && !Player.instance.isAttacking() && !Player.instance.moveAttack()){
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

    public void startDash(){
        dashVFX.SetActive(true);
        StartCoroutine(ScaleToTargetCoroutine(dashScale, shrinkDuration));
    }

    public void endDash(){
        
        StartCoroutine(ScaleToTargetCoroutine(startScale, shrinkDuration));
        dashVFX.SetActive(false);
    }

    public void startDashVFX(){
        
    }

    public void endDashVFX(){
        
    }
    private IEnumerator ScaleToTargetCoroutine(Vector3 targetScale, float duration){
        Vector3 startScale = transform.localScale;
        float timer = 0.0f;
        while(timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            //smoother step algorithm
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }
        yield return null;
    }
}