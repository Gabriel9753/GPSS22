using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    
    public float maxHealth;			
    public float health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        
=======
        amount = Mathf.Clamp(amount, 0, int.MaxValue);
        health += amount;
        if (health <= 0){
            health = 100;
        }
        HealthSystemGUI.instance.HealDamage(amount);
    }

    private float calculateXP(){
        if (level == 0){
            return 1;
        }
        else{
            return level * 7;
        }
>>>>>>> Stashed changes
    }
}
