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
    
    public static GameObject newRoom;
    //public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
       // Instantiate(player);
        for (int i = 0; i < enemies.Length; i++)
        {
            Instantiate(enemies[i]);
        }
        //Instantiate(world manager);
        worldManager = gameObject.GetComponent<WorldManager>();
        //Instantiate(camera);
        //camera.GetComponent<CameraFollow>().target = player.transform;
        //player.GetComponent<PlayerMovement>().camera = camera;

    }
    
}
