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
            SpawnTeleportRoom1();
        }
        if (RoomGeneration.Room2 == true)
        {
            SpawnTeleportRoom2();
        }
        if (RoomGeneration.Room3 == true)
        {
            SpawnTeleportRoom3();
        }
        if (RoomGeneration.Room4 == true)
        {
            SpawnTeleportRoom4();
        }
        if (RoomGeneration.Room5 == true)
        {
            SpawnTeleportRoom5();
        }
        if (RoomGeneration.Room6 == true)
        {
            SpawnTeleportRoom6();
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

    }
    void SpawnTeleportRoom3()
    {

    }
    void SpawnTeleportRoom4()
    {

    }
    void SpawnTeleportRoom5()
    {

    }
    void SpawnTeleportRoom6()
    {

    }
}
