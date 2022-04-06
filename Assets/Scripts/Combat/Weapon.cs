using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{
    public float weaponDamage = 10;
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Enemy")){
            Debug.Log(Player.instance.getPlayedAnimationName());
            other.GetComponent<EnemyStats>().TakeDamage(weaponDamage);
        }
        if (other.CompareTag("Player")){
            Player.instance.GetComponent<PlayerAttack>().GotHit(weaponDamage);
        }
        
    }
}


