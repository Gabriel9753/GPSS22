using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupWorld : MonoBehaviour
{
    //public GameObject player;

    public GameObject[] enemies;

    //public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
       // Instantiate(player);
        for (int i = 0; i < enemies.Length; i++)
        {
            Instantiate(enemies[i]);
        }

        //Instantiate(camera);
        //camera.GetComponent<CameraFollow>().target = player.transform;
        //player.GetComponent<PlayerMovement>().camera = camera;

    }
}
