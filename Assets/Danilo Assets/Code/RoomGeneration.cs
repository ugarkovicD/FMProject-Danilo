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
    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
        Invoke("Spawn",0.1f);
    }

    void Update()
    {
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
    void Spawn()
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
