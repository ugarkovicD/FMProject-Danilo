using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEnemySpawner : MonoBehaviour
{
    public static int numberToSpawn;
    public List<GameObject> Spawnpool;
    public GameObject SpawnArea;
    public static float NumberOfEnemies;
    public bool Spawned;
    public static bool SpawnWhenWalkPortal;
    public Text EnemiesText;
    // Start is called before the first frame update
    void Start()
    {       
        NumberOfEnemies = 0;
        numberToSpawn = 2;
        spawnObjects();
    }

    // Update is called once per frame
    void Update()
    {

        EnemiesText.text = NumberOfEnemies.ToString();
        if (SpawnWhenWalkPortal == true)
        {
            Spawned = false;
            Invoke("spawnObjects", 0.1f);
            SpawnWhenWalkPortal = false;
        }
       if (Input.GetKeyDown(KeyCode.G))
       {
            spawnObjects();
       }
       // add in when the room spawns, you spawn the enemies as well 
    }
    public void spawnObjects()
    {
        if (Spawned == false)
        {
            NumberOfEnemies += numberToSpawn;
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
            Spawned = true;
            SpawnWhenWalkPortal = false;
            if (numberToSpawn <= 7)
            {
                numberToSpawn += 1;
            }
        }       
    }
}
