using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public Transform Level1Place;
    public Transform Level2Place;
    public Transform Level3Place;
    public bool Spawnedlvl1;
    public bool Spawnedlvl2;
    public bool Spawnedlvl3;
    public bool Spawnedlvl31;

    public Camera cameraObject;
    public float MaxSpeed;
    public static float speed = 7;
    public float distance = 1;
    public static bool facingUp;
    public static bool facingDown;
    public static bool facingRight;
    public static bool facingLeft;
    public float distanceDash = 200;
    public int speedDash = 20;
    public bool dashing;
    public float dashTimer;
    public bool ArivedOnTarget;
    //Passive items and Notches for item ammount
    public bool haveSpace;
    public int NotchesAmmount;
    public bool collidingItem;
    //Slowed
    public static float SlowedTimer = 0;
    public static bool slowed;
    public static float speedSlowed;

    private GameObject[] TeleportsAndRooms;

    void Start()
    {
        MaxSpeed = 7;
        haveSpace = true;
        speed = MaxSpeed;
        speedSlowed = 4;
        if (RoomGeneration.rand == 0)
        {
            Spawnedlvl2 = true;
        }
        if (RoomGeneration.rand == 1)
        {
            Spawnedlvl3 = true;
        }
        if (RoomGeneration.rand == 2)
        {
            Spawnedlvl31 = true;
        }
        if (RoomGeneration.rand == 3)
        {
            Spawnedlvl1 = true;
        }
        if (Spawnedlvl1 == true)
        {
            Invoke("SpawnRoom1", 0.1f);
        }
        if (Spawnedlvl2 == true)
        {
            Invoke("SpawnRoom2", 0.1f);
        }
        if (Spawnedlvl3 == true)
        {
            SpawnRoom3();
        }
    }
    // Update is called once per frame
    void Update()
    {
        //random
        TeleportsAndRooms = GameObject.FindGameObjectsWithTag("Room");
        cameraObject.transform.position = new Vector3(transform.position.x, transform.position.y, cameraObject.transform.position.z);

        // teleporting the player into the levels
        //FINISH THIS, Remove room gen, it makes it reset constantly
        if (RoomGeneration.rand == 0)
        {
            Spawnedlvl2 = true;
        }
        if (RoomGeneration.rand == 1)
        {
            Spawnedlvl3 = true;
        }
        if (RoomGeneration.rand == 2)
        {
            Spawnedlvl31 = true;
        }
        if (RoomGeneration.rand == 3)
        {
            Spawnedlvl1 = true;
        }
        if (Spawnedlvl1 == true)
        {
            Invoke("SpawnRoom1", 0.1f);
        }
        if (Spawnedlvl2 == true)
        {
            Invoke("SpawnRoom2", 0.1f);
        }
        if (Spawnedlvl3 == true)
        {
            SpawnRoom3();
        }

        //Slow
        if (slowed == true)
        {
            SlowedTimer -= 1 * Time.deltaTime;
            speed = speedSlowed;
        }
        if (SlowedTimer <= 0)
        {
            slowed = false;
            speed = MaxSpeed;
        }

        //walking      
        if (dashing == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                facingDown = false;
                facingUp = false;
                facingLeft = false;
                facingRight = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                facingDown = false;
                facingUp = false;
                facingLeft = true;
                facingRight = false;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                facingDown = false;
                facingUp = true;
                facingLeft = false;
                facingRight = false;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
                facingUp = false;
                facingLeft = false;
                facingRight = false;
                facingDown = true;
            }
        }
        //dashing
        dashTimer -= 1 * Time.deltaTime;

        if (dashTimer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                dashTimer = 4;
                dashing = true;
                if (facingDown == true)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - distanceDash * speedDash * Time.deltaTime);
                }
                if (facingUp == true)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + distanceDash * speedDash *Time.deltaTime);
                }
                if (facingRight == true)
                {
                    transform.position = new Vector2(transform.position.x + distanceDash * speedDash * Time.deltaTime, transform.position.y);
                }
                if (facingLeft == true)
                {
                    transform.position = new Vector2(transform.position.x - distanceDash * speedDash * Time.deltaTime, transform.position.y);
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            dashing = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //damage
        if (collision.name == "DamageItemUPG(Clone)")
        {
            Destroy(collision.gameObject);
            characterCombat.attackDamage += 10;
        }
        //speed
        if (collision.name == "SpeedItemUPG(Clone)")
        {
            Destroy(collision.gameObject);
            MaxSpeed += 1.2f;
            speedSlowed += 1;
        }
        //mana
        if (collision.name == "ManaItemUPG(Clone)")
        {
            Destroy(collision.gameObject);
        }
        //cooldown
        if (collision.name == "CooldownItemUPG(Clone)")
        {
            Destroy(collision.gameObject);
        }
        //Armor
        if (collision.name == "ArmorItemUPG(Clone)")
        {
            Destroy(collision.gameObject);
        }
        if (collision.name == "TeleportPrefab(Clone)")
        {            
            RoomGeneration.SpawnWhenWalkPortal = true;
            RandomEnemySpawner.SpawnWhenWalkPortal = true;
            Destroy(collision.gameObject);
            foreach(GameObject r in TeleportsAndRooms)
            {
                Destroy(r.gameObject);
            }
        }
    }
    void SpawnRoom1()
    {
        transform.position = Level1Place.position;
        Spawnedlvl1 = false;
        RoomGeneration.rand = 9;
    }
    void SpawnRoom2()
    {
        transform.position = Level2Place.position;
        Spawnedlvl2 = false;
        RoomGeneration.rand = 6;
    }
    void SpawnRoom3()
    {
        transform.position = Level3Place.position;
        Spawnedlvl3 = false;
        RoomGeneration.rand = 7;
    }
    void SpawnRoom31()
    {
        transform.position = Level3Place.position;
        Spawnedlvl31 = false;
        RoomGeneration.rand = 8;
    }
}
