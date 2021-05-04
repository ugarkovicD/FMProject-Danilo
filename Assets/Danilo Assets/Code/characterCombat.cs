using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCombat : MonoBehaviour
{
    public Transform AttackPoint;
    public Transform AttackPointLeft;
    public Transform AttackPointUp;
    public Transform AttackPointDown;
    public float attackRange = 1;
    public LayerMask EnemyLayer;
    public static int attackDamage = 20;
    public int HeavyAttackDamage = 40;
    private float timebtwHits;
    private float startTimebtwHits = 0.25f;
    private float startTimebtwHitsHeavy = 0.6f;
    public static bool Damage20;
    public static bool Damage30;
    public static bool Damage40;
    public bool holdingSword;

    //BOW stuff
    public bool holdingBow;
    public bool HaveAmmo;
    public float ReloadTimer = 2;
    public float AmmoAmmount;
    public GameObject ArrowPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        HaveAmmo = true;
        AmmoAmmount = 10;
        holdingSword = false;
        attackDamage = 20;
        Damage20 = true;
        timebtwHits = startTimebtwHits;
        holdingBow = true;
    }

    // Update is called once per frame
    void Update()
    {
        timebtwHits -= 1 * Time.deltaTime;
        if (Damage20 == true)
        {
            Damage30 = false;
            Damage40 = false;
        }
        if (Damage30 == true)
        {
            Damage20 = false;
            Damage40 = false;
        }
        if (Damage40 == true)
        {
            Damage20 = false;
            Damage30 = false;
        }
        if (attackDamage == 20)
        {
            Damage20 = true;
        }
        if (attackDamage == 30)
        {
            Damage30 = true;
        }
        if (attackDamage == 40)
        {
            Damage40 = true;
        }
        //Attack
        if (holdingSword == true)
        {
            if (SmoothMovement.facingDown == true)
            {
                if (timebtwHits <= 0)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        AttackDown();
                        timebtwHits = startTimebtwHits;
                    }
                }
            }
            if (SmoothMovement.facingUp == true)
            {
                if (timebtwHits <= 0)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        AttackUp();
                        timebtwHits = startTimebtwHits;
                    }
                }
            }       
            if (SmoothMovement.facingRight == true)
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
            if (SmoothMovement.facingLeft == true)
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
            holdingBow = false;
        }
        //Bow Attack
        if (holdingBow == true)
        {
            if (SmoothMovement.facingLeft == true)
            {
                if (HaveAmmo == true)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        BowLeft();
                    }
                }
            }
            if (SmoothMovement.facingRight == true)
            {
                if (HaveAmmo == true)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        BowRight();
                    }
                }
            }
            if (SmoothMovement.facingUp == true)
            {
                if (HaveAmmo == true)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        BowUp();
                    }
                }
            }
            if (SmoothMovement.facingDown == true)
            {
                if (HaveAmmo == true)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        BowDown();
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                HaveAmmo = false;
                ReloadTimer = 2;
            }
            if (AmmoAmmount == 0)
            {
                HaveAmmo = false;
            }
            if (ReloadTimer <= 0)
            {
                ReloadTimer = 2;
                AmmoAmmount = 10;
                HaveAmmo = true;              
            }
            if (HaveAmmo == false)
            {
                ReloadTimer -= 1 * Time.deltaTime;
            }
            holdingSword = false;
        }
    }
    void Attack()
    {
        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, EnemyLayer);

        //damage them
        foreach(Collider2D enemy in hitEnemies)
        {          
            if (enemy.CompareTag("MeleeEnemy"))
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                Debug.Log("we hit" + enemy.name + "kurac");
            }
            if (enemy.CompareTag("RangedEnemy"))
            {
                enemy.GetComponent<RangedEnemy>().TakeDamage(attackDamage);
                Debug.Log("we hit" + enemy.name + "kurac");
            }
            if (enemy.CompareTag("BomberEnemy"))
            {
                enemy.GetComponent<BomberEnemy>().TakeDamage(attackDamage);

            Debug.Log("we hit" + enemy.name +"kurac");
            }
        }
        startTimebtwHits = 0.25f;
    }
    void AttackLeft()
    {
        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPointLeft.position, attackRange, EnemyLayer);

        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("MeleeEnemy"))
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                Debug.Log("we hit" + enemy.name + "kurac");
            }
            if (enemy.CompareTag("RangedEnemy"))
            {
                enemy.GetComponent<RangedEnemy>().TakeDamage(attackDamage);
                Debug.Log("we hit" + enemy.name + "kurac");
            }
            if (enemy.CompareTag("BomberEnemy"))
            {
                enemy.GetComponent<BomberEnemy>().TakeDamage(attackDamage);

                Debug.Log("we hit" + enemy.name + "kurac");
            }
        }
    }
    void AttackUp()
    {
        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPointUp.position, attackRange, EnemyLayer);

        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("MeleeEnemy"))
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                Debug.Log("we hit" + enemy.name + "kurac");
            }
            if (enemy.CompareTag("RangedEnemy"))
            {
                enemy.GetComponent<RangedEnemy>().TakeDamage(attackDamage);
                Debug.Log("we hit" + enemy.name + "kurac");
            }
            if (enemy.CompareTag("BomberEnemy"))
            {
                enemy.GetComponent<BomberEnemy>().TakeDamage(attackDamage);

                Debug.Log("we hit" + enemy.name + "kurac");
            }
        }
    }
    void AttackDown()
    {
        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPointDown.position, attackRange, EnemyLayer);

        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("MeleeEnemy"))
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                Debug.Log("we hit" + enemy.name + attackDamage);
            }
            if (enemy.CompareTag("RangedEnemy"))
            {
                enemy.GetComponent<RangedEnemy>().TakeDamage(attackDamage);
                Debug.Log("we hit" + enemy.name + attackDamage);
            }
            if (enemy.CompareTag("BomberEnemy"))
            {
                enemy.GetComponent<BomberEnemy>().TakeDamage(attackDamage);
                Debug.Log("we hit" + enemy.name + attackDamage);
            }
        }
    }
    void HeavyAttack()
    {
        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, EnemyLayer);

        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<RangedEnemy>().TakeDamage(HeavyAttackDamage);
            Debug.Log("we hard hit" + enemy.name + 3 +"damage");
        }
    }
    void HeavyAttackLeft()
    {
        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPointLeft.position, attackRange, EnemyLayer);

        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<RangedEnemy>().TakeDamage(HeavyAttackDamage);
            Debug.Log("we hard hit" + enemy.name + 3 + "damage");
        }
    }
    public void BowRight()
    {
        GameObject Arrow = Instantiate(ArrowPrefab, AttackPoint.position, AttackPoint.rotation);
        Rigidbody2D rb = ArrowPrefab.GetComponent<Rigidbody2D>();
        rb.AddForce(AttackPoint.up * 2000);
        AmmoAmmount -= 1;
    }
    public void BowLeft()
    {
        GameObject Arrow = Instantiate(ArrowPrefab, AttackPointLeft.position, AttackPointLeft.rotation);
        Rigidbody2D rb = ArrowPrefab.GetComponent<Rigidbody2D>();
        rb.AddForce(AttackPointLeft.up * 2000);
        AmmoAmmount -= 1;
    }
    public void BowUp()
    {
        GameObject Arrow = Instantiate(ArrowPrefab, AttackPointUp.position, AttackPointUp.rotation);
        Rigidbody2D rb = ArrowPrefab.GetComponent<Rigidbody2D>();
        rb.AddForce(AttackPointUp.up * 2000);
        AmmoAmmount -= 1;
    }
    public void BowDown()
    {
        GameObject Arrow = Instantiate(ArrowPrefab, AttackPointDown.position, AttackPointDown.rotation);
        Rigidbody2D rb = ArrowPrefab.GetComponent<Rigidbody2D>();
        rb.AddForce(AttackPointDown.up * 2000);
        AmmoAmmount -= 1;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
        Gizmos.DrawWireSphere(AttackPointLeft.position, attackRange);
        Gizmos.DrawWireSphere(AttackPointUp.position, attackRange);
        Gizmos.DrawWireSphere(AttackPointDown.position, attackRange);
    }
}
