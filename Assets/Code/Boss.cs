using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //shielding runthrough Ability
    public GameObject shield;
    public Transform playerRotation;
    //movement
    public float MoveSpeed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform playerFollow;
    //shooting
    private float timebtwShots;
    public float startTimeBewShots;
    public GameObject projectile;
    //Health
    public float MaxHealth;
    public float currentHealth;
    //Patterns and powers
    public bool doingPatterns;
    public bool healing;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        healing = false;
        doingPatterns = false;
        currentHealth = MaxHealth;
        startTimeBewShots = 2;
        timebtwShots = startTimeBewShots;
        playerFollow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (doingPatterns == false && healing == false)
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
        if (currentHealth >= MaxHealth)
        {
            currentHealth = MaxHealth;
        }
    }
    void shieldingRunthrough()
    {
        Vector3 direction = playerRotation.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        shield.GetComponent<BoxCollider2D>().isTrigger = false;
        shield.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy died");
    }
}
