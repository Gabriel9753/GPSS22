using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

    // Called when a script is enabled
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Called once every frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("isNormalAttack", true);
        }
        else
        {
            animator.SetBool("isNormalAttack", false);
        }
        
    }
}
