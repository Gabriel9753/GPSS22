using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour{
    private Animator _animator;
    private NavMeshAgent _agent;
    private new Camera camera;
    
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

    public bool isHit(){
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("playerHit"))
            return true;
        return false;
    }

    public String GetSpeedMultiplierName(){
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Normal_Attack_1"))
            return "Normal1";
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Normal_Attack_2"))
            return "Normal2";
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Normal_Attack_3"))
            return "Normal3";
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("RunAttack"))
            return "run Attack";
        
        //ADD NEW ATTACK OR ABILITY HERE
        
        return "";
    }
    
    public String GetAnimationName(){
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Normal_Attack_1"))
            return "Normal_Attack_1";
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Normal_Attack_2"))
            return "Normal_Attack_2";
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Normal_Attack_3"))
            return "Normal_Attack_3";
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("RunAttack"))
            return "RunAttack";
        
        //ADD NEW ATTACK OR ABILITY HERE
        
        return "";
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

    public void PlayerToMouseRotation(){
        Vector2 positionOnScreen = camera.WorldToViewportPoint (transform.position);
        Vector2 mouseOnScreen = camera.ScreenToViewportPoint(Input.mousePosition);
        float angle =  Mathf.Atan2(positionOnScreen.y - mouseOnScreen.y, positionOnScreen.x - mouseOnScreen.x) * Mathf.Rad2Deg;
        transform.rotation =  Quaternion.Euler (new Vector3(0f,transform.rotation.y-angle-45,0f));
    }
}
