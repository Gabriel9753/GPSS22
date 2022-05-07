using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.PlayerLoop;
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
        levelText.GetComponent<Text>().text = "- Level " + level + " -";
        currentXP = overflowXP;
        maxXP = calculateMaxXP();
        xpBar.GetComponent<Slider>().maxValue = calculateMaxXP();
        xpBar.GetComponent<Slider>().value = currentXP;
        LevelUpUpgradesUI.Instance.ActivateUI();
    }

    public void setCurrentXP(float amount){
        currentXP = amount;
        updateUI();
    }

    public void updateUI(){
        if (checkLevelUp()){
            levelUp();
        }
        else{
            xpBar.GetComponent<Slider>().maxValue = calculateMaxXP();
            xpBar.GetComponent<Slider>().value = currentXP;
            levelText.GetComponent<Text>().text = "- Level " + level + " -";
        }
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
            //print(timer);
            yield return null;
        }

        xpText.enabled = false;
        yield return null;
    }

    public void selectedUpgradeAfterLevelUp(){
        updateUI();
    }
}
