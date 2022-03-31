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
    
    public static GameObject newRoom;
    public new Camera camera;
    // Start is called before the first frame update
    void Awake()
    {
       // Instantiate(player);
        for (int i = 0; i < enemies.Length; i++)
        {
            Instantiate(enemies[i]);
        }
        Debug.Log("Setup");
        Instantiate(player);
        Player.instance.GetComponent<PlayerMovement>().setCamera(camera);
        camera.GetComponent<CameraFollow>().target = Player.instance.transform;
        worldManager = gameObject.GetComponent<WorldManager>();
        //Instantiate(camera);
        //camera.GetComponent<CameraFollow>().target = player.transform;
        //player.GetComponent<PlayerMovement>().camera = camera;

    }
    
    
    
}
