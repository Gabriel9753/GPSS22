using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    //Fields
    public GameObject rArm;

    //For later initializing
    public GameObject weapon;
    private BoxCollider _boxCollider;
    
    // Called when a script is enabled
    void Start()
    {
        //Get collider from held weapon
        _boxCollider = weapon.GetComponent<BoxCollider>();
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
    }


    public void startAttack()
    {
        _boxCollider.enabled = true;
    }

    public void endAttack()
    {
        _boxCollider.enabled = false;
    }


}
