using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    public GameObject[] rooms;
    public int rand;
    public static bool PlayerWentToOtherRoom;
    private bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        PlayerWentToOtherRoom = false;
        spawned = false;
        Invoke("Spawn",0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (spawned == false)
        {
                rand = Random.Range(0, rooms.Length);            
                Instantiate(rooms[rand],transform.position,Quaternion.identity); 
                spawned = true;
                Debug.Log("SPAWNED A ROOM");            
        }
    }
}
