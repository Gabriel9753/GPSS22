using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetupWorld : MonoBehaviour
{
    //public GameObject player;
    public static WorldManager worldManager;
    public GameObject[] enemies;
    public GameObject player;
    public GameObject UI;
    public new Camera camera;
    public static GameObject newRoom;
    // Start is called before the first frame update
    void Awake(){
        //Instantiate(camera);
        
       // Instantiate(player);
        for (int i = 0; i < enemies.Length; i++)
        {
            Instantiate(enemies[i]);
        }
        Debug.Log("Setup");
        Instantiate(player);
        Player.instance.GetComponent<PlayerMovement>().setCamera(camera);
        worldManager = gameObject.GetComponent<WorldManager>();
    }
    
    
    
}
