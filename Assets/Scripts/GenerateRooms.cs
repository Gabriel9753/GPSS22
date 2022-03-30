using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenerateRooms : MonoBehaviour{


    void Start(){

    }

    void Update(){
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            SetupWorld.worldManager.CreateRoom();
        }
    }

   
    
}