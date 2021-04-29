using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed = 2;
    public Rigidbody2D rb;
    private Vector2 movement;
    private float currentHealth;
    public ParticleSystem damaged20P;
    public ParticleSystem damaged30P;
    public ParticleSystem damaged40P;
    public SpriteRenderer SpriteRenderer;
    public Sprite HealthFull;
    public Sprite Health20;
    public Sprite Health40;
    public Sprite Health60;
    public Sprite Health80;
    public Sprite Dead;
    public GameObject HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 100;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Add Changes to enemy Health
        if (currenthp == 100)
        {
            healthImage.sprite = HealthFull;
        }
        if (currenthp == 80)
        {
            healthImage.sprite = Health80;
        }
        if (currenthp == 60)
        {
            healthImage.sprite = Health60;
        }
        if (currenthp == 40)
        {
            healthImage.sprite = Health40;
        }
        if (currenthp == 20)
        {
            healthImage.sprite = Health20;
        }
        if (currenthp == 0)
        {
            healthImage.sprite = Dead;
        }
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
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
            Debug.Log("Destroyed Melee Enemy");
        }
    }
}
