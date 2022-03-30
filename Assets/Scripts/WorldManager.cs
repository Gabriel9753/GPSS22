using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldManager : MonoBehaviour
{    
    public GameObject newRoom;
    public NavMeshSurface[] surfaces;
    public GameObject[] rooms;
    public GameObject entryRoom;
    private int roomCounter= 0;
    // Start is called before the first frame update
    void Start()
    {
        newRoom = Instantiate(entryRoom, position: new Vector3(0,0, 0), Quaternion.identity);
        Vector3 position = newRoom.transform.Find("entrance").gameObject.transform.position; 
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
        Vector3 newPosition = newRoom.transform.Find("entrance").gameObject.transform.position;
        roomCounter++;
        PlayerMovement.Warp(newPosition);
    }
}
