using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRooms : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public GameObject room;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spawnpoint"))
        {
            Instantiate(room, position: new Vector3(0, -50, 0), Quaternion.identity);
            agent.SetDestination(agent.transform.position);
        }
    }
    
}