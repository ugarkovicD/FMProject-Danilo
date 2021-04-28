using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    //Level Position change
    public Transform Level1Place;
    public Transform Level2Place;
    public Transform Level3Place;
    public bool Spawnedlvl1;
    public bool Spawnedlvl2;
    public bool Spawnedlvl3;
    public bool Spawnedlvl31;
    //Movement + random
    public Camera cameraObject;
    public float MaxSpeed;
    public static float speed = 7;
    public float distance = 1;
    public float distanceDash = 1;
    public int speedDash = 300;
    public bool dashing;
    public float dashTimer;
    public static bool facingUp;
    public static bool facingDown;
    public static bool facingRight;
    public static bool facingLeft;
    //Passive items and Notches for item ammount
    public bool haveSpace;
    public int NotchesAmmount;
    public bool collidingItem;
    //Slowed
    public static float SlowedTimer = 0;
    public static bool slowed;
    public static float speedSlowed;
    //Reset level
    private GameObject[] TeleportsAndRooms;
    //Sprites with sword, bow and walking
    public Texture WalkingRightSword;
    public Texture WalkingLeftSword;
    public Texture WalkingUpSword;
    public Texture WalkingDownSword;
    //Sprites with Bow
    public Texture WalkingRightBow;
    public Texture WalkingLeftBow;
    public Texture WalkingUpBow;
    public Texture WalkingDownBow;
    //Sprites stationary
    public Sprite StillRightBow;
    public Sprite StillLeftBow;
    public Sprite StillUpBow;
    public Sprite StillDownBow;
    public Sprite StillRightSword;
    public Sprite StillLeftSword;
    public Sprite StillUpSword;
    public Sprite StillDownSword;
    //Set Sprites when moving
    public bool AnimationOn;
    public int colCount;
    public int rowCount;
    public int FPS = 10;
    public int rowNumber = 0;
    public int colNumber = 0;
    public int totalCells;
    private Vector2 offset;
    //checking for weapon holding
    public bool HoldingSword;
    public bool HoldingBow;
    public bool HoldingMinigun;

    public SpriteRenderer spriteRender;


    void Start()
    {
        //animation
        totalCells = colCount * rowCount;

        MaxSpeed = 7;
        haveSpace = true;
        speed = MaxSpeed;
        speedSlowed = 4;       
    }
    // Update is called once per frame
    void Update()
    {
        //Animation
        if (AnimationOn == true)
        {
            SetSpriteAnimation(colCount, rowCount, rowNumber, colNumber, totalCells, FPS);
        }
        if (AnimationOn == false)
        {
            if (HoldingSword == true)
            {
                if (facingLeft == true)
                {
                    spriteRender.sprite = StillLeftSword;
                }
                if (facingRight == true)
                {
                    spriteRender.sprite = StillRightSword;
                }
                if (facingUp == true)
                {
                    spriteRender.sprite = StillUpSword;
                }
                if (facingDown == true)
                {
                    spriteRender.sprite = StillDownSword;
                }
            }            
        }
        
        //random
        TeleportsAndRooms = GameObject.FindGameObjectsWithTag("Room");
        cameraObject.transform.position = new Vector3(transform.position.x, transform.position.y, cameraObject.transform.position.z);

        // teleporting the player into the levels
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
            Invoke("SpawnRoom3", 0.1f);
        }
        if (Spawnedlvl31 == true)
        {
            Invoke("SpawnRoom31", 0.1f);
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
            MaxSpeed += 0.3f;
            speedSlowed += 0.2f;
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
        //Make the teleport work for this room when u kill all enemies
    }
    void SpawnRoom31()
    {
        transform.position = Level3Place.position;
        Spawnedlvl31 = false;
        RoomGeneration.rand = 8;
    }
    public void SetSpriteAnimation(int colCount, int rowCount, int rowNumber, int colNumber, int totalCells, int fps)
    {
        // Calculate index
        int index = (int)(Time.time * fps);
        // Repeat when exhausting all cells
        index = index % totalCells;
        // Size of every cell
        float sizeX = 1.0f / colCount;

        float sizeY = 1.0f / rowCount;
        Vector2 size = new Vector2(sizeX, sizeY);
        // split into horizontal and vertical index
        var uIndex = index % colCount;
        var vIndex = index / colCount;
        // build offset
        float offsetX = (uIndex + colNumber) * size.x;
        float offsetY = (1.0f - size.y) - (vIndex + rowNumber) * size.y;
        Vector2 offset = new Vector2(offsetX, offsetY);
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
        GetComponent<Renderer>().material.SetTextureScale("_MainTex", size);
    
    }
}
