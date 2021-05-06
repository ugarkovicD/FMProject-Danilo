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
    // Start is called before the first frame update
    void Start()
    {
        timebtwShots = startTimeBewShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpinShooting == true)
        {
            if (timebtwShots<= 0)
            {
                ShootSpin();
            }
        }
        if (SpinShooting == false)
        {
            if (startTimeBewShots <= 0)
            {
                Shoot();
            }
            timeBeforeSpinAttack -= 1 * Time.deltaTime;
        }
        if (timeBeforeSpinAttack <= 0)
        {
            SpinningAttack();
        }
        if (SpinTime <= 0)
        {
            SpinShooting = false;
        }
        startTimeBewShots -= 1 * Time.deltaTime;
    }
    public void SpinningAttack()
    {
        //SetTheBossTorotate And reset when it stops
        SpinTime = 10;
        SpinShooting = true;
        if (SpinTime >= 0)
        {
            transform.Rotate(0, 0, 20 * Time.deltaTime);
            SpinTime -= 1 * Time.deltaTime;
        }
    }
    public void Shoot()
    {       
        Instantiate(projectile, transform.position, Quaternion.identity);
        timebtwShots = startTimeBewShots;
        startTimeBewShots = 0.2f;
    }
    public void ShootSpin()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
        timebtwShots = startTimeBewShots;
        startTimeBewShots = 0.05f;
    }
}
