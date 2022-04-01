using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetupWorld : MonoBehaviour
{
    //public GameObject player;
    public static WorldManager worldManager;
    public GameObject health;
    public GameObject[] enemies;
    public GameObject player;
    public new Camera camera;
    // Start is called before the first frame update
    void Awake(){
        worldManager = gameObject.GetComponent<WorldManager>();
        //Instantiate(camera);
        //Instantiate(camera);
        Instantiate(health);
        for (int i = 0; i < enemies.Length; i++)
        {
            Instantiate(enemies[i]);
        }
        Instantiate(player);
        Player.instance.GetComponent<PlayerMovement>().setCamera(camera);
        
    }

    
    
}
