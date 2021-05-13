using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBossScript : MonoBehaviour
{  
    public ParticleSystem damaged20P;
    public ParticleSystem damaged30P;
    public ParticleSystem damaged40P;
    public ParticleSystem damaged50P;
    public static float currentHealth = 500;
    public int dashTimes = 100;
    public float waitUntillNextDash = 1;
    public float timebeforeFreeze = 0.7f;
    public float timeFrozen = 0.1f;
    public float dashSpeed = 20000;
    private Vector2 target;
    public Transform playerPosition;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(playerPosition.position.x, playerPosition.position.y);
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 1)
        {
            Destroy(this.gameObject);
        }
        if (dashTimes > 0)
        {
            Vector3 direction = playerPosition.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            waitUntillNextDash -= 1 * Time.deltaTime;
            timebeforeFreeze -= 1 * Time.deltaTime;
            if (waitUntillNextDash <= 0)
            {
                timeFrozen = 0.1f;
                timebeforeFreeze = 0.8f;
                dashTimes -= 1;
                waitUntillNextDash = 1;
                GetComponent<BoxCollider2D>().isTrigger = true;
                rb.AddForce(transform.right * dashSpeed * Time.deltaTime);
            }
            if (waitUntillNextDash >= 0)
            {
                if (timebeforeFreeze <= 0)
                {
                    timeFrozen -= 1 * Time.deltaTime;
                    rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                    if (timeFrozen <= 0)
                    {
                        rb.constraints = RigidbodyConstraints2D.None;
                    }
                }
            }
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
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "arrow(Clone)")
        {
            Debug.Log("ArrowHit SadBoss");
            currentHealth -= 50;
            damaged50P.Play();
        }
    }
}

