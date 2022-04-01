using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldManager : MonoBehaviour
{    
    private GameObject newRoom;
    public NavMeshSurface[] surfaces;
    public GameObject[] rooms;
    public GameObject entryRoom;
    private GameObject entrance;
    private int roomCounter= 0;
    // Start is called before the first frame update
    void Start()
    {
        newRoom = Instantiate(entryRoom, position: new Vector3(0,0, 0), Quaternion.identity);
        entrance = GameObject.FindWithTag("Entrance");
        Vector3 position = entrance.transform.position;
        PlayerMovement.Warp(position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CreateRoom(){
        int rand = Random.Range(0, rooms.Length);
        Debug.Log(newRoom.transform.position + " " + newRoom.name+" "+ gameObject.name);
        Vector3 curPosition = newRoom.transform.position;
        Destroy(newRoom);
        newRoom = Instantiate(rooms[rand], position: new Vector3(curPosition.x, curPosition.y, curPosition.z), Quaternion.identity);
        for (int i = 0; i < surfaces.Length; i++){
            surfaces[i].BuildNavMesh();
        }
        entrance = GameObject.FindWithTag("Entrance");
        Vector3 position = entrance.transform.position;
        roomCounter++;
        PlayerMovement.Warp(position);
    }
}
