using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.UI;

public class PlayerStats : MonoBehaviour{
    
    public float maxHealth = 200;   // Maximum amount of health
    public float maxMana = 200;
    public float health = 100;	// Current amount of health
    public float mana = 100;
    private static bool called = false;
    public GameObject healthUI;
    
    
    
    public float baseDamage = 1;
    public float sumDamage = 1;
    
    public float baseCriticalChance = 1;
    public float sumCriticalChance = 1;
    
    public float baseCriticalDamage = 1;
    public float sumCriticalDamage = 1;
    
    public void Start(){
        HealthSystemGUI.Instance.maxHealth = 112;
        HealthSystemGUI.Instance.health = 112;
        HealthSystemGUI.Instance.maxMana = 112;
        HealthSystemGUI.Instance.mana = 112;
        XP_UI.Instance.updateUI();
    }

    public void TakeDamage (float damage)
    {
        // Make sure damage doesn't go below 0.
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        // Subtract damage from health
        health -= damage;
        HealthSystemGUI.Instance.TakeDamage(damage); 
        Debug.Log(transform.name + " takes " + damage + " damage.");
        
        // If we hit 0. Die.
        if (health <= 0){
           //Die();
        }
    }
    
    public void Heal (int amount)
    {
        amount = Mathf.Clamp(amount, 0, int.MaxValue);
        health += amount;
        if (health <= 0){
            health = 100;
        }
        HealthSystemGUI.Instance.HealDamage(amount);
    }

    public void addPlayerDamage(float dmg){
        sumDamage = baseDamage + dmg;
    }
    
    public void addPlayerCriticalChance(float critChance){
        sumCriticalChance = baseCriticalChance + critChance;
    }
    public void addPlayerCriticalDamage(float critDmg){
        sumCriticalDamage = baseCriticalDamage + critDmg;
    }
}