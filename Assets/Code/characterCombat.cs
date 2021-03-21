using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCombat : MonoBehaviour
{
    public Transform AttackPoint;
    public Transform AttackPointLeft;
    public float attackRange = 1;
    public LayerMask EnemyLayer;
    public int attackDamage = 1;
    public int HeavyAttackDamage = 3;
    private float timebtwHits;
    public float startTimebtwHits = 0.75f;
    public float startTimebtwHitsHeavy = 1.5f;
    public ParticleSystem damaged3;
    public ParticleSystem damaged1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        timebtwHits = startTimebtwHits;
    }

    // Update is called once per frame
    void Update()
    {
        if (Character.facingRight == true)
        {
            if (timebtwHits <= 0)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Attack();
                    timebtwHits = startTimebtwHits;
                }
            }
        }
        if (Character.facingLeft == true)
        {
            if (timebtwHits <= 0)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    AttackLeft();
                    timebtwHits = startTimebtwHits;
                }
            }
        }

        if (timebtwHits >= 0) 
        {
            timebtwHits -= Time.deltaTime;
        }

        if (Character.facingRight == true)
        {
            if (timebtwHits <= 0)
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    HeavyAttack();
                    timebtwHits = startTimebtwHitsHeavy;
                }
            }
        }     
        if (Character.facingLeft == true)
        {
            if (timebtwHits <= 0)
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    HeavyAttackLeft();
                    timebtwHits = startTimebtwHitsHeavy;
                }
            }
        }      
    }
    void Attack()
    {
        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, EnemyLayer);

        //damage them
        foreach(Collider2D enemy in hitEnemies)
        { 
            enemy.GetComponent<Boss>().TakeDamage(attackDamage);
            Debug.Log("we hit" + enemy.name + 1);
            damaged1.Play();
        }
    }
    void AttackLeft()
    {
        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPointLeft.position, attackRange, EnemyLayer);

        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Boss>().TakeDamage(attackDamage);
            Debug.Log("we hit" + enemy.name + 1);
            damaged1.Play();
        }
    }
    void HeavyAttack()
    {
        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, EnemyLayer);

        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Boss>().TakeDamage(HeavyAttackDamage);
            Debug.Log("we hard hit" + enemy.name + 3 +"damage");
            damaged3.Play();
        }
    }
    void HeavyAttackLeft()
    {
        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPointLeft.position, attackRange, EnemyLayer);

        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Boss>().TakeDamage(HeavyAttackDamage);
            Debug.Log("we hard hit" + enemy.name + 3 + "damage");
            damaged3.Play();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
        Gizmos.DrawWireSphere(AttackPointLeft.position, attackRange);
    }
}
