using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadBossCode : MonoBehaviour
{
    public float currentHealth = 500;
    //damage and shooting action
    private float timebtwShots;
    public float startTimeBewShots = 0.3f;
    public Rigidbody2D projectile;
    public float SpinTime;
    public float ammountOfXShots;
    public float damageDone;
    public float timeBeforeSpinAttack = 20;

    public static bool SpinShooting;
    public bool XShooting;

    public ParticleSystem damaged20P;
    public ParticleSystem damaged30P;
    public ParticleSystem damaged40P;
    public ParticleSystem damaged50P;

    public Transform ShootingPoint;
    public Transform ShootingPoint1;
    public Transform ShootingPoint2;
    public Transform ShootingPointFront;
    public Sprite SpiningAttack;
    public Sprite NormalSprite;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 500;
        timebtwShots = startTimeBewShots;
    }

    // Update is called once per frame
    void Update()
    {      
        if (currentHealth <= 1)
        {
            Destroy(this.gameObject);
            Debug.Log("BossDestroyed");
        }
        if (SpinTime >= 0)
        {
            SpinTime -= 1 * Time.deltaTime;          
        }
        if (SpinShooting == true)
        {
            if (startTimeBewShots<= 0)
            {
                ShootSpin();
                transform.Rotate(0, 0, 600 * Time.deltaTime);
                GetComponent<SpriteRenderer>().sprite = SpiningAttack;
            }
        }
        if (SpinShooting == false)
        {
            if (startTimeBewShots <= 0)
            {
                Shoot();
            }           
        }
        timeBeforeSpinAttack -= 1 * Time.deltaTime;
        if (timeBeforeSpinAttack <= 0)
        {
            SpinTime = 10;
            SpinningAttack();
            timeBeforeSpinAttack = 30;           
        }
        if (SpinTime <= 0)
        {
            SpinShooting = false;
            transform.rotation = Quaternion.identity;
            GetComponent<SpriteRenderer>().sprite = NormalSprite;
        }
        startTimeBewShots -= 1 * Time.deltaTime;
    }
    public void SpinningAttack()
    {
        SpinShooting = true;
    }
    public void Shoot()
    {       
        Instantiate(projectile, transform.position, Quaternion.identity);
        Instantiate(projectile, ShootingPointFront.position, Quaternion.identity);
        timebtwShots = startTimeBewShots;
        startTimeBewShots = 0.2f;
    }
    public void ShootSpin()
    {
        Rigidbody2D Bullet;
        Bullet = Instantiate(projectile, ShootingPoint.position, Quaternion.identity)as Rigidbody2D;
        Bullet.AddForce(ShootingPoint.up * 15000 * Time.deltaTime);
        Bullet = Instantiate(projectile, ShootingPoint1.position, Quaternion.identity) as Rigidbody2D;
        Bullet.AddForce(ShootingPoint1.up * 15000 * Time.deltaTime);
        Bullet = Instantiate(projectile, ShootingPoint2.position, Quaternion.identity) as Rigidbody2D;
        Bullet.AddForce(ShootingPoint2.up * 15000* Time.deltaTime);
        timebtwShots = startTimeBewShots;
        startTimeBewShots = 0.1f;
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