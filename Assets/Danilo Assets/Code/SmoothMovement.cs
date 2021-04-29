using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public bool walkingRight;
    public bool walkingLeft;
    public bool walkingDown;
    public bool walkingUp;

    public SpriteRenderer spriteRender;

    //UI
    public Text HPIncreasedText;
    public Text DamageIncreasedText;
    public Text SpeedIncreasedText;
    public Image Panel;
    public float PopupTextTimer = 3;
    public bool HPTextYes;
    public bool DamageTextYes;
    public bool SpeedTextYes;
    public bool PanelYes;

    void Start()
    {
        //animation
        totalCells = colCount * rowCount;
        AnimationOn = false;
        HoldingSword = true;

        MaxSpeed = 7;
        haveSpace = true;
        speed = MaxSpeed;
        speedSlowed = 4;
        slowed = false;
        Panel.enabled = false;
        HPIncreasedText.enabled = false;
        DamageIncreasedText.enabled = false;
        SpeedIncreasedText.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        //UI
        if (HPTextYes == true)
        {
            PopupTextTimer -= 1 * Time.deltaTime;
        }
        if (DamageTextYes == true)
        {
            PopupTextTimer -= 1 * Time.deltaTime;
        }
        if (SpeedTextYes == true) 
        {
            PopupTextTimer -= 1 * Time.deltaTime;
        }
        if (PopupTextTimer <= 0)
        {
            HPIncreasedText.enabled = false;
            DamageIncreasedText.enabled = false;
            SpeedIncreasedText.enabled = false;
            Panel.enabled = false;
        }
        //Animation
        if (AnimationOn == true)
        {
            SetSpriteAnimation(colCount, rowCount, colNumber, rowNumber, totalCells, FPS);
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
        //moving
        //SET SPRITESHEETS FOR WALKING
        if (Input.GetKey(KeyCode.D))
        {            
            facingDown = false;
            facingUp = false;
            facingLeft = false;
            facingRight = true;
            //AnimationOn = true;
            walkingRight = true;
        }
        if (Input.GetKey(KeyCode.A))
        {         
            facingDown = false;
            facingUp = false;
            facingLeft = true;
            facingRight = false;
            //AnimationOn = true;
            walkingLeft = true;
            //GetComponent<Renderer>().material.mainTexture = WalkingLeftSword;
        }
        if (Input.GetKey(KeyCode.W))
        {           
            facingDown = false;
            facingUp = true;
            facingLeft = false;
            facingRight = false;
            //AnimationOn = true;
            walkingUp = true;
            //GetComponent<Renderer>().material.mainTexture = WalkingUpSword;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            facingUp = false;
            facingLeft = false;
            facingRight = false;
            facingDown = true;
            //AnimationOn = true;
            walkingDown = true;
            //GetComponent<Renderer>().material.mainTexture = WalkingDownSword;
        }
        if (walkingRight == true)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (walkingLeft == true)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (walkingUp == true)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (walkingDown == true)
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            AnimationOn = false;
            walkingRight = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            walkingLeft = false;
            AnimationOn = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            walkingUp = false;
            AnimationOn = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            walkingDown = false;
            AnimationOn = false;
        }       
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //damage
        if (collision.name == "DamageItemUPG(Clone)")
        {
            Destroy(collision.gameObject);
            if (characterCombat.attackDamage == 20)
            {
                characterCombat.attackDamage = 30;
            }
            if (characterCombat.attackDamage == 30)
            {
                characterCombat.attackDamage = 40;
            }
            DamageIncreasedText.enabled = true;
            Panel.enabled = true;
            PanelYes = true;
            DamageTextYes = true;
            PopupTextTimer = 3;
        }
        //speed
        if (collision.name == "SpeedItemUPG(Clone)")
        {
            Destroy(collision.gameObject);
            MaxSpeed += 0.3f;
            speedSlowed += 0.2f;
            SpeedIncreasedText.enabled = true;
            Panel.enabled = true;
            SpeedTextYes = true;
            PanelYes = true;
            PopupTextTimer = 3;
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
        if (collision.name == "HealthItemUPG(Clone)")
        {
            Destroy(collision.gameObject);
            CharacterHealth.maxHp += 1;
            Panel.enabled = true;
            HPTextYes = true;
            PanelYes = true;
            HPIncreasedText.enabled = true;
            PopupTextTimer = 3;
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
