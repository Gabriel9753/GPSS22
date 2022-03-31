using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    //Fields
    public GameObject rArm;

    //For later initializing
    private BoxCollider weaponCollider;
    private static Animator _animator;
    
    // Called when a script is enabled
    void Start()
    {
        //Get collider from held weapon
        weaponCollider = rArm.GetComponentInChildren<BoxCollider>();
        _animator = Player.instance.GetComponent<Animator>();
    }
    
    // Called once every frame
    void Update()
    {
        //Right click for attack animation
        if (Input.GetMouseButtonDown(1)){_animator.SetBool("isNormalAttack", true);}
        else {_animator.SetBool("isNormalAttack", false);}

    }

    //Activate collider while attacking
    void startAttack()
    {
        weaponCollider.enabled = true;
    }

    void endAttack()
    {
        weaponCollider.enabled = false;
        Weapon.setHitObjectNull();
        Weapon.isOtherPlayerHit = false;
    }

    public static bool isAttacking(){
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("SlashAttack")){
            return true;
        }

        if (_animator.GetCurrentAnimatorStateInfo(1).IsName("SlashAttack")){
            return true;
        }
        
        return false;
    }



}
