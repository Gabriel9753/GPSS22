using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStats : StateMachineBehaviour{
    public float duration;
    public float cooldown;

    public float damage;
    public float criticalRate;
    public float criticalDamage;

    private String clipName;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        String currentClip = Player.instance.getPlayedAnimationName();
        animator.SetFloat(currentClip, duration);
    }

    public float Damage{
        get => damage;
        set => damage = value;
    }
    

    public float Duration{
        get => duration;
        set => duration = value;
    }
    

    public float Cooldown{
        get => cooldown;
        set => cooldown = value;
    }
    

    public float CriticalDamage{
        get => criticalDamage;
        set => criticalDamage = value;
    }
    

    public float CriticalRate{
        get => criticalRate;
        set => criticalRate = value;
    }
}
