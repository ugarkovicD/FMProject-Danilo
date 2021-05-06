using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomGeneration : MonoBehaviour
{
    public GameObject[] rooms;
    public static int rand;
    public static bool spawned;
    public Vector3 SpawnPoint;
    public static bool EnemiesDead;
    public Transform SpawnPoint2;

    public Text levelText;
    public int levelNumber;

    //Checking Which room is Spawned
    public static bool Room1;
    public static bool Room2;
    public static bool Room3;
    public static bool Room4;
    public static bool Room5;

    public static bool SpawnWhenWalkPortal;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWhenWalkPortal = false;
        spawned = false;
        Spawn();
    }

    void Update()
    {
        levelText.text = levelNumber.ToString();
        if (SpawnWhenWalkPortal == true)
        {
            Invoke("Spawn",0.1f);
            spawned = false;
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
        if (RandomEnemySpawner.NumberOfEnemies <= 0)
        {
            EnemiesDead = true;
        }
        if (RandomEnemySpawner.NumberOfEnemies >= 1)
        {
            EnemiesDead = false;
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
             SpawnWhenWalkPortal = false;
             rand = Random.Range(0, rooms.Length);
             Instantiate(rooms[rand],SpawnPoint2.position,Quaternion.identity);
             spawned = true;
             Debug.Log("SPAWNED A ROOM");
             CharacterHealth.currenthp += 3;
             Debug.Log("Health + 3");
             levelNumber += 1;
        }
    }
}
