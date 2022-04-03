using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageTextManager : MonoBehaviour{
    public GameObject damageText;
    #region Singleton

    public static DamageTextManager instance;
    private Animator _animator;

    void Awake ()
    {
        instance = this;
    }
    #endregion


    public void DamageCreate(Vector3 position, float num, float length){
        GameObject dmgTextToSpawn = damageText;
        TextMeshPro textMesh = dmgTextToSpawn.GetComponent<TextMeshPro>();
        textMesh.text = num.ToString();
        dmgTextToSpawn = Instantiate(dmgTextToSpawn, position, Quaternion.Euler(30, 45, 0));
        StartCoroutine(PositionChange(dmgTextToSpawn, dmgTextToSpawn.transform.localPosition, 1));
        
    }
    
    private IEnumerator PositionChange(GameObject text, Vector3 targetPosition, float duration){
        float rndX = UnityEngine.Random.Range(1,20);
        float rndY = UnityEngine.Random.Range(1,7);
        float rndZ = UnityEngine.Random.Range(1,20);
        Vector3 startPosition = text.transform.localPosition;
        targetPosition = targetPosition + new Vector3(rndX/10, rndY/10, rndZ/10);
        float timer = 0.0f;
        while(timer < duration){
            timer += Time.deltaTime;
            float t = timer / duration;
            //smoother step algorithm
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            text.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }
        Destroy(text);
        yield return null;
    }
}
