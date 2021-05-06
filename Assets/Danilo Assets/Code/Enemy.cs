using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    public float speed = 2;
    public Rigidbody2D rb;
    private Vector2 movement;
    private float currentHealth;
    public ParticleSystem damaged20P;
    public ParticleSystem damaged30P;
    public ParticleSystem damaged40P;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentHealth = 100;
        rb = this.GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            RandomEnemySpawner.NumberOfEnemies -= 1;
            Debug.Log("Destroyed Melee Enemy");
        }
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterHealth.currenthp -= 1;
            Debug.Log("Health = " + CharacterHealth.currenthp);
        }
        if (other.name == "arrow(Clone)")
        {
            Debug.Log("ArrowHit Melee");
            currentHealth -= 50;
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
        
    }
}
