using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private float startTimebtwHits = 0.3f;
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
    public Rigidbody2D ArrowPrefab;
    public Text BowAmmoAmmount;

    //Pickups for weapons
    public bool HoveringOnSword;
    public bool HoveringOnBow;
    public Text PickupSwordText;
    public Text PickupBowText;
    public Image Panel;
    public GameObject BowPrefab;
    public GameObject SwordPrefab;

    public GameObject[] Weapons;
    public static bool levelNext;
    public float arrowFroce = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Panel.enabled = false;
        PickupSwordText.enabled = false;
        PickupBowText.enabled = false;
        HaveAmmo = true;
        AmmoAmmount = 7;
        attackDamage = 20;
        Damage20 = true;
        timebtwHits = startTimebtwHits;
        holdingBow = false;
        holdingSword = true;
    }

    // Update is called once per frame
    void Update()
    {
        BowAmmoAmmount.text = AmmoAmmount.ToString();
        if (levelNext == true)
        {
            DestroyWeapons();
        }
        Weapons = GameObject.FindGameObjectsWithTag("Weapon");
        if (HoveringOnSword == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                holdingSword = true;
                holdingBow = false;
                Instantiate(BowPrefab, transform.position, transform.rotation);
                foreach (GameObject r in Weapons)
                {
                    Destroy(r.gameObject);
                }
            }
        }
        if (HoveringOnBow == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                holdingSword = false;
                holdingBow = true;
                Instantiate(SwordPrefab, transform.position, transform.rotation);
                foreach (GameObject r in Weapons)
                {
                    Destroy(r.gameObject);
                }
            }
        }
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
            Damage30 = false;
            Damage40 = false;
        }
        if (attackDamage == 30)
        {
            Damage30 = true;
            Damage20 = false;
            Damage40 = false;
        }
        if (attackDamage == 40)
        {
            Damage20 = false;
            Damage30 = false;
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
                AmmoAmmount = 7;
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
            if (enemy.CompareTag("SadBoss"))
            {
                enemy.GetComponent<SadBossCode>().TakeDamage(attackDamage);
                Debug.Log("we hit" + enemy.name + "Bosskurac");
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
            if (enemy.CompareTag("SadBoss"))
            {
                enemy.GetComponent<SadBossCode>().TakeDamage(attackDamage);
                Debug.Log("we hit" + enemy.name + "Bosskurac");
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
            if (enemy.CompareTag("SadBoss"))
            {
                enemy.GetComponent<SadBossCode>().TakeDamage(attackDamage);
                Debug.Log("we hit SadBoss");
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
            if (enemy.CompareTag("SadBoss"))
            {
                enemy.GetComponent<SadBossCode>().TakeDamage(attackDamage);
                Debug.Log("we hit" + enemy.name + "Bosskurac");
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
            Debug.Log("we hard hit" + enemy.name + 7 + "damage");
        }
    }
    public void BowRight()
    {
        Rigidbody2D arrowInstance;
        arrowInstance = Instantiate(ArrowPrefab, AttackPoint.position, AttackPoint.rotation) as Rigidbody2D;
        arrowInstance.AddForce(AttackPoint.right * 10*Time.deltaTime);
        AmmoAmmount -= 1;
    }
    public void BowLeft()
    {
        Rigidbody2D arrowInstance;
        arrowInstance = Instantiate(ArrowPrefab, AttackPointLeft.position, AttackPointLeft.rotation) as Rigidbody2D;
        arrowInstance.AddForce(AttackPointLeft.right * 10 * Time.deltaTime);
        AmmoAmmount -= 1;
    }
    public void BowUp()
    {
        Rigidbody2D arrowInstance;
        arrowInstance = Instantiate(ArrowPrefab, AttackPointUp.position, AttackPointUp.rotation) as Rigidbody2D;
        arrowInstance.AddForce(AttackPointUp.right * 10 * Time.deltaTime);
        AmmoAmmount -= 1;
    }
    public void BowDown()
    {
        Rigidbody2D arrowInstance;
        arrowInstance = Instantiate(ArrowPrefab, AttackPointDown.position, AttackPointDown.rotation) as Rigidbody2D;
        arrowInstance.AddForce(AttackPointDown.right * 10 * Time.deltaTime);
        AmmoAmmount -= 1;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
        Gizmos.DrawWireSphere(AttackPointLeft.position, attackRange);
        Gizmos.DrawWireSphere(AttackPointUp.position, attackRange);
        Gizmos.DrawWireSphere(AttackPointDown.position, attackRange);
    }
    public void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.name == "BowItemPickup(Clone)")
        {
            HoveringOnBow = true;
            PickupBowText.enabled = true;
            Panel.enabled = true;
        }
        if (collison.name == "SwordItemPickup(Clone)")
        {
            HoveringOnSword = true;
            PickupSwordText.enabled = true;
            Panel.enabled = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collison)
    {
        if (collison.name == "BowItemPickup(Clone)")
        {
            HoveringOnBow = false;
            PickupBowText.enabled = false;
            Panel.enabled = false;
        }
        if (collison.name == "SwordItemPickup(Clone)")
        {
            HoveringOnSword = false;
            PickupSwordText.enabled = false;
            Panel.enabled = false;
        }
    }
    public void DestroyWeapons()
    {       
            foreach (GameObject r in Weapons)
            {
                Destroy(r.gameObject);
            }
            levelNext = false;       
    }
}
