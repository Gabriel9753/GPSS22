using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using static UnityEngine.Random;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private new Camera camera;

    private string groundTag = "Ground";
    
    private UnityEngine.AI.NavMeshAgent agent;
    public GameObject entry_room;
    public GameObject[] rooms;
    private RaycastHit hit;
    private GameObject newRoom;
    public NavMeshSurface[] surfaces;

    // Called when a script is enabled
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        newRoom = Instantiate(entry_room, position: new Vector3(0,0,0), Quaternion.identity);
        agent.Warp(newRoom.transform.Find("entrance").gameObject.transform.position);
    }

    // Called once every frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.CompareTag(groundTag))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            int rand = Random.Range(0, rooms.Length);
            Vector3 curPosition = newRoom.transform.position;   
            Destroy(newRoom);
            newRoom = Instantiate(rooms[rand], position: new Vector3(curPosition.x, curPosition.y, curPosition.z), Quaternion.identity);
            
            for (int i = 0; i < surfaces.Length; i++) 
            {
                surfaces[i].BuildNavMesh();    
            }
            GameObject newEntrance = newRoom.transform.Find("entrance").gameObject;
            agent.Warp(newEntrance.transform.position);
        }
    }
    
}