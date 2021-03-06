using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour{
    private Animator _animator;
    private NavMeshAgent _agent;
    private Camera camera;
    
    #region Singleton

    public static Player instance;

    void Awake ()
    {
        instance = this;
        _animator = instance.GetComponent<Animator>();
        _agent = instance.GetComponent<NavMeshAgent>();
    }

    #endregion

    void Start(){
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
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("RunAttack"))
            return true;
        return false;
    }

    public bool standAttack(){
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Normal_Attack_1"))
            return true;
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Normal_Attack_2"))
            return true;
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Normal_Attack_3"))
            return true;
        return false;
    }
    public bool moveAttack(){
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("RunAttack"))
            return true;
        return false;
    }
    
    
    public bool isRunning(){
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            return true;
        return false;
    }
    
    public bool isDashing(){
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Dash"))
            return true;
        return false;
    }

    #endregion
    public void setCamera(Camera camera){
        this.camera = camera;
    }
    
    public Camera getCamera(){
        return this.camera;
    }
    public Animator getAnimator(){
        return _animator;
    }
    
    public NavMeshAgent Agent{
        get => _agent;
        set => _agent = value;
    }
}
