using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInWay : MonoBehaviour
{
 private void Awake(){
  ShowSolid();
 }

 public void ShowTransparent(){
     gameObject.SetActive(false);
     //transperantBody.SetActive(true);
 }

 public void ShowSolid(){
     gameObject.SetActive(true);
     //transperantBody.SetActive(false);
 }
}
