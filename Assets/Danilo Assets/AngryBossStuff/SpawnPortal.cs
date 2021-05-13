using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPortal : MonoBehaviour
{
    public bool bossdead;
    public GameObject Teleport;
    public Transform TeleportSpot;
    public bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (AngryBossScript.currentHealth <= 1)
        {
            bossdead = true;
        }      
        if (bossdead == true)
        {
            Instantiate(Teleport, TeleportSpot.position, TeleportSpot.rotation);
            bossdead = false;
        }
    }
}
