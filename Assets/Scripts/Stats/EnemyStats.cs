using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyStats : MonoBehaviour{
    
    public float maxHealth = 200;   // Maximum amount of health
    public float maxMana = 200;
    public float health = 50;	// Current amount of health
    public float mana = 100;
    private Animator _animator;
    private NavMeshAgent _agent;

    public void Start(){
        _animator = transform.GetComponent<Animator>();
        _agent = transform.GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float damage)
    {
        // Make sure damage doesn't go below 0.
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        // Subtract damage from health
        health -= damage;
        DamageTextManager.instance.DamageCreate(transform.position + new Vector3(0,3,0), damage, 11);
        
        if (health <= 0){
            Die();
        }
        else{
            _animator.Play("hit");
            _animator.SetBool("isRunning", false);
            _animator.SetBool("isAttacking", false);
            _agent.ResetPath();
        }
    }

    public void Die(){
        _animator.Play("die");
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