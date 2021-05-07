using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadBossCode : MonoBehaviour
{
    public float currentHealth;
    //damage and shooting action
    private float timebtwShots;
    public float startTimeBewShots = 0.3f;
    public Rigidbody2D projectile;
    public float SpinTime;
    public float ammountOfXShots;
    public float damageDone;
    public float timeBeforeSpinAttack = 20;

    public bool SpinShooting;
    public bool XShooting;

    public ParticleSystem damaged20P;
    public ParticleSystem damaged30P;
    public ParticleSystem damaged40P;
    public ParticleSystem damaged50P;

    public Transform ShootingPoint;
    // Start is called before the first frame update
    void Start()
    {
        timebtwShots = startTimeBewShots;
    }

    // Update is called once per frame
    void Update()
    {      
        if (SpinTime >= 0)
        {
            SpinTime -= 1 * Time.deltaTime;          
        }
        if (SpinShooting == true)
        {
            if (startTimeBewShots<= 0)
            {
                ShootSpin();
                transform.Rotate(0, 0, 5000 * Time.deltaTime);
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
        timebtwShots = startTimeBewShots;
        startTimeBewShots = 0.2f;
    }
    public void ShootSpin()
    {
        Rigidbody2D Bullet;
        Bullet = Instantiate(projectile, ShootingPoint.position, Quaternion.identity)as Rigidbody2D;
        Bullet.AddForce(ShootingPoint.up * 5 * Time.deltaTime);
        timebtwShots = startTimeBewShots;
        startTimeBewShots = 0.1f; 
    }
}
