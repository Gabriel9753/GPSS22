using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
	This component is derived from CharacterStats. It adds two things:
		- Gaining modifiers when equipping items
		- Restarting the game when dying
*/

public class PlayerStats : MonoBehaviour{
    
    public static PlayerStats Instance;
    
    public float maxHealth;			// Maximum amount of health
    public float health;	// Current amount of health
    public float mana;
    public float maxMana;
    // Use this for initialization
    
    

    public void Awake(){
        Instance = this;
    }

    public void Start(){
        maxHealth = 240;
        mana = 100;
        maxMana = 100;
        HealthSystemGUI.Instance.SetHealth(health);
        HealthSystemGUI.Instance.SetMaxHealth(maxHealth);
        HealthSystemGUI.Instance.SetMana(mana);
        HealthSystemGUI.Instance.SetMaxMana(maxMana);
        
        
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
    
    
}