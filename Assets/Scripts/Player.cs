using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    private Animator _animator;
    #region Singleton

    public static Player instance;

    void Awake ()
    {
        instance = this;
    }

    #endregion

    void Start(){
        _animator = instance.GetComponent<Animator>();
        //playerStats.OnHealthReachedZero += Die;
    }

    //public CharacterCombat playerCombatManager;
    //public PlayerStats playerStats;


    void Die() {
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #region Check animation states from player

    public bool isAttacking(){
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Normal_Attack_1"))
            return true;
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Normal_Attack_2"))
            return true;
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Normal_Attack_3"))
            return true;
        return false;
    }
    
    public bool isRunning(){
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            return true;
        return false;
    }
    
    public bool isRolling(){
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Rolling"))
            return true;
        return false;
    }

    #endregion
    

}
