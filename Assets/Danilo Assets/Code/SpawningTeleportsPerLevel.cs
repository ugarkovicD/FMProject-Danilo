using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningTeleportsPerLevel : MonoBehaviour
{
    // Set each teleport in each level and make them instantiate when the player kills all the enemies
    public Transform Teleport1;
    public Transform Teleport2;
    public Transform Teleport3;
    public Transform Teleport4;
    public Transform Teleport5;
    public GameObject teleportPrefab;
    public bool Room1Called;
    public bool Room2Called;
    public bool Room3Called;
    public bool Room4Called;
    void Start()
    {
        Room4Called = false;
        Room3Called = false;
        Room2Called = false;
        Room1Called = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (RoomGeneration.EnemiesDead == false)
        {
            Room4Called = false;
            Room3Called = false;
            Room2Called = false;
            Room1Called = false;
        }
        if (RoomGeneration.rand == 6)
        {
            Invoke("SpawnTeleportRoom1", 0.1f);
        }
        if (RoomGeneration.rand == 7)
        {
            Invoke("SpawnTeleportRoom2", 0.1f);

        }
        if (RoomGeneration.rand == 8)
        {
            Invoke("SpawnTeleportRoom3", 0.1f);

        }
        if (RoomGeneration.rand == 9)
        {
            Invoke("SpawnTeleportRoom4", 0.1f);

        }
        if (RoomGeneration.Room5 == true)
        {
            Invoke("SpawnTeleportRoom5", 0.1f);
        }
   
    }
    void SpawnTeleportRoom1()
    {
        if (Room1Called == false)
        {
            if (RoomGeneration.EnemiesDead == true)
            {
                Instantiate(teleportPrefab, Teleport1.position, Teleport1.rotation);
                Instantiate(teleportPrefab, Teleport2.position, Teleport2.rotation);
                Room1Called = true;
                Debug.Log("Spawned Teleport1");
            }
        }      
    }
    void SpawnTeleportRoom2()
    {
        if (Room2Called == false)
        {
            if (RoomGeneration.EnemiesDead == true)
            {
                Instantiate(teleportPrefab, Teleport3.position, Teleport3.rotation);
                Instantiate(teleportPrefab, Teleport4.position, Teleport4.rotation);
                Room2Called = true;
                Debug.Log("Spawned Teleport2");
            }
        }       
    }
    void SpawnTeleportRoom3()
    {
        if (Room3Called == false)
        {
            if (RoomGeneration.EnemiesDead == true)
            {
                Instantiate(teleportPrefab, Teleport3.position, Teleport3.rotation);
                Instantiate(teleportPrefab, Teleport4.position, Teleport4.rotation);
                Room3Called = true;
                Debug.Log("Spawned Teleport3");
            }
        }       
    }
    void SpawnTeleportRoom4()
    {
        if (Room4Called == false)
        {
            if (RoomGeneration.EnemiesDead == true)
            {
                Instantiate(teleportPrefab, Teleport5.position, Teleport5.rotation);
                Room4Called = true;
                Debug.Log("Spawned Teleport4");
            }
        }       
    }
    void SpawnTeleportRoom5()
    {
        Debug.Log("Spawned Teleport5");
    }
}
