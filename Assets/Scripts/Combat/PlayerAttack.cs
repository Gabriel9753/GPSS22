using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour
{
    //Fields
    public GameObject rArm;

    //For later initializing
    public GameObject weapon;
    private BoxCollider _boxCollider;

    private Camera camera;
    private RaycastHit hit;
    public int maxDistance = 70;
    public LayerMask moveMask;
    public NavMeshAgent agent;
    private Vector3 destination;

    public GameObject projectile;
    private float projectileSpeed = 15;
    
    // Called when a script is enabled
    void Start()
    {
        //Get collider from held weapon
        _boxCollider = weapon.GetComponent<BoxCollider>();
        camera = Player.instance.getCamera();
    }
    
    // Called once every frame
    void Update()
    {
        //Right click for attack animation and not running
        if (Input.GetMouseButtonDown(1) && !Player.instance.isRunning()){
            Player.instance.GetComponent<PlayerCombo>().NormalAttack();
        }

        
            //When running other attack animation
        if (Input.GetMouseButtonDown(1) && Player.instance.isRunning()){
            //Dash Attack
        }
        
        //Shoot Fireball
        if (Input.GetKeyDown("w")){
            Vector2 positionOnScreen = camera.WorldToViewportPoint (transform.position);
            Vector2 mouseOnScreen = camera.ScreenToViewportPoint(Input.mousePosition);
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
            transform.rotation =  Quaternion.Euler (new Vector3(0f,transform.rotation.y-angle-45,0f));
            
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, maxDistance, moveMask)){
//                print("ray");
                destination = hit.point;
                InstantiateProjectile(weapon.transform);
            }
        }
        
    }


    void InstantiateProjectile(Transform origin){
        Vector2 positionOnScreen = camera.WorldToViewportPoint (transform.position);
        Vector2 mouseOnScreen = camera.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        var projectileObj = Instantiate(projectile, origin.position, Quaternion.Euler (new Vector3(0f,transform.position.y-angle+225,0f))) as GameObject;
      //  print("proj position: " +projectileObj.transform.position +" desti: "+destination);
        projectileObj.GetComponent<Rigidbody>().velocity = (new Vector3(destination.x,origin.position.y,destination.z) - origin.position).normalized * projectileSpeed;

    }
    public void startAttack()
    {
        _boxCollider.enabled = true;
    }

    public void endAttack()
    {
        _boxCollider.enabled = false;
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
