using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWalls : MonoBehaviour
{
    public GameObject DestroyableWall;
    public GameObject DestroyableWall2;
    public GameObject DestroyableWall3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RoomGeneration.EnemiesDead == true)
        {
            Destroy(GameObject.FindGameObjectWithTag("DestroyableWall"));
            Destroy(DestroyableWall);
            Destroy(DestroyableWall2);
            Destroy(DestroyableWall3);
        }
    }
}
