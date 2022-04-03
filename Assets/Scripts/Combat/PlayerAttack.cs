using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour{
    //For later initializing
    public GameObject weapon;
    private BoxCollider _boxCollider;
    private Animator _animator;
    private NavMeshAgent _agent;
    
    private Camera camera;
    private RaycastHit hit;
    public int maxDistance = 70;
    public LayerMask moveMask;
    private Vector3 destination;
    public GameObject projectile;
    private float projectileSpeed = 15;
    
    // Called when a script is enabled
    void Start(){
        //Get collider from held weapon
        _boxCollider = weapon.GetComponent<BoxCollider>();
        _animator = Player.instance.getAnimator();
        _agent = GetComponent<NavMeshAgent>();
        camera = Player.instance.getCamera();
    }
    
    // Called once every frame
    void Update(){
        if(Player.instance.standAttack()) 
            _animator.SetBool("isRunToNormal", false);
        
        //Right click for attack animation and not running
        if (Input.GetMouseButtonDown(1) && !Player.instance.isRunning() && !Player.instance.isDashing()){
            if (Player.instance.moveAttack() && _animator){
                if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f){
                    Player.instance.PlayerToMouseRotation();
                    _animator.SetBool("isRunToNormal", true);
                }
            }
            if (!Player.instance.moveAttack()){
                _agent.ResetPath();
                Player.instance.GetComponent<PlayerCombo>().NormalAttack();
            }
        }

        
        //When running -> other attack animation
        if (Input.GetMouseButtonDown(1) && Player.instance.isRunning()){
            //Dash Attack
            if (_agent && _animator){
                Player.instance.PlayerToMouseRotation();
                _agent.ResetPath();
                _animator.Play("RunAttack");
                float alpha = (float)((transform.rotation.eulerAngles.y % 360) * Math.PI)/180;
                Vector3 forward = new Vector3((float)Math.Sin(alpha), 0, (float)Math.Cos(alpha));
                Vector3 newDestination = transform.position + forward * (2.5f);
                _agent.SetDestination(newDestination);
            }
        }
        
        //Shoot Fireball
        if (Input.GetKeyDown("w") && camera){
            _agent.ResetPath();
            Player.instance.PlayerToMouseRotation();
            
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, maxDistance, moveMask)){
                destination = hit.point;
                InstantiateProjectile(weapon.transform);
            }
        }
    }

    void InstantiateProjectile(Transform origin){
        Vector2 positionOnScreen = camera.WorldToViewportPoint (transform.position);
        Vector2 mouseOnScreen = camera.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        var projectileObj = Instantiate(projectile, origin.position, Quaternion.Euler (new Vector3(0f,transform.position.y-angle+225,0f)));
        projectileObj.GetComponent<Rigidbody>().velocity = (new Vector3(destination.x,origin.position.y,destination.z) - origin.position).normalized * projectileSpeed;
    }
    public void startAttack(){
        _boxCollider.enabled = true;
    }

    public void endAttack(){
        _boxCollider.enabled = false;
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
