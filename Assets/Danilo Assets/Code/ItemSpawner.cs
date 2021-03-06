using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> Spawnpool;
    public GameObject SpawnArea;
    public bool spawned;
    public static bool SpawnWhenWalkPortal;
    private GameObject[] Items;
    // Start is called before the first frame update
    void Start()
    {
        spawnObjects();
    }

    // Update is called once per frame
    void Update()
    {
        Items = GameObject.FindGameObjectsWithTag("PassiveItem");
        if (SpawnWhenWalkPortal == true)
        {
            spawned = false;
            Invoke("spawnObjects", 0.1f);
            SpawnWhenWalkPortal = false;
            foreach (GameObject r in Items)
            {
                Destroy(r.gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            spawnObjects();
        }
    }
    public void spawnObjects()
    {
        if (spawned == false)
        {
            int randomEnemy = 0;
            GameObject toSpawn;
            MeshCollider c = SpawnArea.GetComponent<MeshCollider>();

            float screenX, screenY;
            Vector2 pos;
            for (int i = 0; i < numberToSpawn; i++)
            {
                randomEnemy = Random.Range(0, Spawnpool.Count);
                toSpawn = Spawnpool[randomEnemy];

                screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
                screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
                pos = new Vector2(screenX, screenY);
                Instantiate(toSpawn, pos, toSpawn.transform.rotation);
            }
            spawned = true;
            SpawnWhenWalkPortal = false;
        }        
    }
}

