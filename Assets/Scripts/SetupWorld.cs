using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class SetupWorld : MonoBehaviour
{
    //public GameObject player;
    public static WorldManager worldManager;
    public GameObject[] enemies;
    public GameObject player;
    public new Camera camera;
    // Start is called before the first frame update
    void Awake(){
//        Debug.Log("First");
        worldManager = gameObject.GetComponent<WorldManager>();
        worldManager.newRoom = Instantiate(worldManager.entryRoom, position: new Vector3(0,0, 0), Quaternion.identity);
        worldManager.entrance = GameObject.FindWithTag("Entrance");
        Transform position = worldManager.entrance.transform;
        Instantiate(player);
        Player.instance.setCamera(camera);

        for (int i = 0; i < enemies.Length; i++)
        {
            Instantiate(enemies[i]);
        }


        Player.instance.transform.position = position.position;
        Player.instance.GetComponent<PlayerMovement>().agent = Player.instance.GetComponent<NavMeshAgent>();
    }
    



}