using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //Right click for attack animation
        if (Input.GetMouseButtonDown(1) && this.name == "Player"){animator.SetBool("isNormalAttack", true);}
        else {animator.SetBool("isNormalAttack", false);}

        }



}
