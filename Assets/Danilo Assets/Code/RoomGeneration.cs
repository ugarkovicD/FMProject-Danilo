using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    public GameObject[] rooms;
    public int rand;
    private bool spawned;
    public Vector3 SpawnPoint;
    public static bool EnemiesDead;
    public Transform SpawnPoint2;

    //Checking Which room is Spawned
    public static bool Room1;
    public static bool Room2;
    public static bool Room3;
    public static bool Room4;
    public static bool Room5;

    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
        Invoke("Spawn",0.1f);
    }

    void Update()
    {
        if (SmoothMovement.DestroyAndSpawnLevel == true)
        {
            Invoke("Spawn", 0.1f);
        }
        if (rand == 0)
        {
            Room1 = true;
        }
        if (rand == 1)
        {
            Room2 = true;
        }
        if (rand == 2)
        {
            Room3 = true;
        }
        if (rand == 3)
        {
            Room4 = true;
        }
        if (rand == 4)
        {
            Room5 = true;
        }
        if (RandomEnemySpawner.NumberOfEnemies <= 0)
        {
            EnemiesDead = true;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            spawned = false;
            Invoke("Spawn", 0.1f);
        }
    }
    // Update is called once per frame
    public void Spawn()
    {
        if (spawned == false)
        {
             rand = Random.Range(0, rooms.Length);
             Instantiate(rooms[rand],SpawnPoint2.position,Quaternion.identity);
             spawned = true;
             Debug.Log("SPAWNED A ROOM");
        }
    }
}
