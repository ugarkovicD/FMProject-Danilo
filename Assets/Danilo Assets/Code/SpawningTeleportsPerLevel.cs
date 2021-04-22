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
    // Update is called once per frame
    void Update()
    {
        if (RoomGeneration.Room1 == true)
        {
            Invoke("SpawnTeleportRoom1",0.1f);
        }
        if (RoomGeneration.Room2 == true)
        {
            Invoke("SpawnTeleportRoom2", 0.1f);
        }
        if (RoomGeneration.Room3 == true)
        {
            Invoke("SpawnTeleportRoom3", 0.1f);
        }
        if (RoomGeneration.Room4 == true)
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
        if (RoomGeneration.EnemiesDead == true)
        {
            Instantiate(teleportPrefab,Teleport1.position, Teleport1.rotation);
            Instantiate(teleportPrefab,Teleport2.position, Teleport2.rotation);
        }
    }
    void SpawnTeleportRoom2()
    {
        if (RoomGeneration.EnemiesDead == true)
        {
            Instantiate(teleportPrefab, Teleport3.position, Teleport3.rotation);
            Instantiate(teleportPrefab, Teleport4.position, Teleport4.rotation);
        }
    }
    void SpawnTeleportRoom3()
    {
        if (RoomGeneration.EnemiesDead == true)
        {
            Instantiate(teleportPrefab, Teleport3.position, Teleport3.rotation);
            Instantiate(teleportPrefab, Teleport4.position, Teleport4.rotation);
        }
    }
    void SpawnTeleportRoom4()
    {
        if (RoomGeneration.EnemiesDead == true)
        {
            Instantiate(teleportPrefab, Teleport5.position, Teleport5.rotation);
        }
    }
    void SpawnTeleportRoom5()
    {

    }
}
