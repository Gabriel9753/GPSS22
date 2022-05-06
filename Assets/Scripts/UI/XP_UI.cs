using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class XP_UI : MonoBehaviour
{
    public int level;
    public float currentXP;
    public float maxXP;
    
    public GameObject xpBar;
    public Text levelText;
    public Text xpText;

    #region Singleton
    public static XP_UI Instance;
    //==============================================================
    // Awake
    //==============================================================
    void Awake()
    {
        Instance = this;
        xpBar.GetComponent<Slider>().minValue = 0;
    }
    #endregion

    private float calculateMaxXP(){
        float max_XP = 25 * level + 100;
        return max_XP;
    }

    private bool checkLevelUp(){
        if (currentXP > maxXP){
            return true;
        }
        return false;
    }

    private void levelUp(){
        float overflowXP = currentXP - maxXP;
        level++;
        currentXP = overflowXP;
        updateUI();
    }

    public void setCurrentXP(float amount){
        currentXP = amount;
        updateUI();
    }

    public void updateUI(){
        levelText.GetComponent<Text>().text = "- Level " + level + " -";
        xpBar.GetComponent<Slider>().maxValue = calculateMaxXP();
        if (checkLevelUp()){
            levelUp();
        }
        xpBar.GetComponent<Slider>().value = currentXP;
    }

    public void addXP(float amount){
        currentXP += amount;
        xpText.GetComponent<Text>().text = "+ " + amount + " XP";
        StartCoroutine(routineXPText(3f));
        updateUI();
    }

    private IEnumerator routineXPText(float duration){
        xpText.enabled = true;
        float timer = 0.0f;
        while(timer < duration){
            timer += Time.deltaTime;
            float t = timer / duration;
            yield return null;
        }

        xpText.enabled = false;
        yield return null;
    }
}
