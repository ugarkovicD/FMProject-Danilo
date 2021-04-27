using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberEnemy : MonoBehaviour
{
    //shielding runthrough Ability
    public Transform playerRotation;
    //movement
    public float MoveSpeed = 2;
    public float stoppingDistance = 5;
    public float retreatDistance = 4;
    public Transform playerFollow;
    //shooting
    public GameObject projectile;
    public int startWait;
    public bool stop;
    public float spawnmostWait = 6;
    public float spawnleastWait =3;
    private float spawnWait;

    private Rigidbody2D rb;
    public int maxHealth = 100;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 100;
        StartCoroutine(waitSpawn());
        rb = this.GetComponent<Rigidbody2D>();
        playerFollow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnleastWait, spawnmostWait);
        if (Vector2.Distance(transform.position, playerFollow.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerFollow.position, MoveSpeed * Time.deltaTime); ;
        }
        else if (Vector2.Distance(transform.position, playerFollow.position) < stoppingDistance && Vector2.Distance(transform.position, playerFollow.position) > stoppingDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, playerFollow.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerFollow.position, -MoveSpeed * Time.deltaTime);
        }
    }
    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            RandomEnemySpawner.NumberOfEnemies -= 1;
            Debug.Log("Destroyed Bomber Enemy");
        }
    }
    IEnumerator waitSpawn()
    {
        yield return new WaitForSeconds(startWait);
        while (!stop)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
