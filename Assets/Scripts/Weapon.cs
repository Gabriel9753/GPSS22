using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{
    public float weaponDamage = 10;
    private BoxCollider weaponCollider;

    private void Start(){
        weaponCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Enemy")){
            
        }
        if (other.CompareTag("Player")){
            PlayerStats.Instance.TakeDamage(weaponDamage);
        }
        
    }
    void startAttack()
    {
        weaponCollider.enabled = true;
    }

    void endAttack()
    {
        weaponCollider.enabled = false;
    }
    

}


