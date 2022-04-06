using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour{
    public float weaponDamage = 10;
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Enemy")){
            PlayerStats stats = Player.instance.GetComponent<PlayerStats>();
            float damage = calculateDamage(
                stats.sumCriticalChance,
                stats.sumCriticalDamage,
                stats.sumDamage
            );
            other.GetComponent<EnemyStats>().TakeDamage(damage);
        }
        if (other.CompareTag("Player")){
            instance.GetComponent<PlayerAttack>().GotHit(weaponDamage);
        }
        
    }

    private float calculateDamage(float critChance, float critDamage, float rawDamage){
        if (critChance > 70){
            critChance = 70;
        }
        if (Random.Range(0.0f, 1.0f) < critChance/100){
            return rawDamage + rawDamage * critDamage / 100;
        }
        else{
            return rawDamage;
        }
    }
}


