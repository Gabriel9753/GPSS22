using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    
    //Stats
    public float health = 100.0f;


    private Animator animator;
    
    public GameObject rArm;
    private BoxCollider weaponCollider;

    // Called when a script is enabled
    void Start()
    {

        weaponCollider = rArm.GetComponentInChildren<BoxCollider>();
        animator = GetComponent<Animator>();
    }

    // Called once every frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && this.name == "Player"){animator.SetBool("isNormalAttack", true);}
        else {animator.SetBool("isNormalAttack", false);}

        if (Weapon.isOtherPlayerHit)
        {
            GameObject enemy = Weapon.getHitObject();
            if (enemy)
            {
                doDamage(enemy);
            }
            Weapon.setHitObjectNull();
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    void doDamage(GameObject target)
    {
        float enemiesHealth = target.GetComponent<PlayerAttack>().getHealth();
        target.GetComponent<PlayerAttack>().setHealth(enemiesHealth-5);
        target.GetComponent<PlayerAttack>().animator.Play("Hit", 0, 0.0f);
        Debug.Log(target.GetComponent<PlayerAttack>().getHealth());
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
    
    //Getter and Setter
    public float getHealth()
    {
        return health;
    }

    public void setHealth(float health)
    {
        this.health = health;
    }



}
