using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    //shielding runthrough Ability
    public Transform playerRotation;
    //movement
    public float MoveSpeed = 2;
    public float stoppingDistance = 5;
    public float retreatDistance = 4;
    public Transform playerFollow;
    //shooting
    private float timebtwShots;
    public float startTimeBewShots;
    public GameObject projectile;

    private Rigidbody2D rb;
    public int maxHealth = 100;
    private float currentHealth;

    public ParticleSystem damaged20P;
    public ParticleSystem damaged30P;
    public ParticleSystem damaged40P;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 100;
        rb = this.GetComponent<Rigidbody2D>();
        startTimeBewShots = 2;
        timebtwShots = startTimeBewShots;
        playerFollow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (timebtwShots <= 0)
        {           
            Instantiate(projectile, transform.position, Quaternion.identity);
            timebtwShots = startTimeBewShots;
        }
        else
        {
            timebtwShots -= Time.deltaTime;
        }
    }
    public void TakeDamage(int Damage)
    {
        if (characterCombat.Damage20 == true)
        {
            damaged20P.Play();
        }
        if (characterCombat.Damage40 == true)
        {
            damaged30P.Play();
        }
        if (characterCombat.Damage30 == true)
        {
            damaged40P.Play();
        }
        currentHealth -= Damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            RandomEnemySpawner.NumberOfEnemies -= 1;
            Debug.Log("Ranged Enemy Killed");
        }
    }
}
