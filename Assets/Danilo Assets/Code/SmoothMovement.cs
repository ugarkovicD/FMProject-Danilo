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

    // Animation 
    public Animator animator; 

    void Start()
    {
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
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime;

        Vector3 Vertical = new Vector3(Input.GetAxis("Vertical"), 0.0f, 0.0f);
        transform.position = transform.position + Vertical * Time.deltaTime;



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
        if (Input.GetKeyDown(KeyCode.D))
        {            
            facingDown = false;
            facingUp = false;
            facingLeft = false;
            facingRight = true;           
            walkingRight = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {         
            facingDown = false;
            facingUp = false;
            facingLeft = true;
            facingRight = false;
            walkingLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {           
            facingDown = false;
            facingUp = true;
            facingLeft = false;
            facingRight = false;
            walkingUp = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            facingUp = false;
            facingLeft = false;
            facingRight = false;
            facingDown = true;
            walkingDown = true;
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

            walkingRight = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            walkingLeft = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            walkingUp = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            walkingDown = false;
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
            ItemSpawner.SpawnWhenWalkPortal = true;
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
    void SetSpriteAnimation(int colCount, int rowCount, int rowNumber, int colNumber, int totalCells, int fps)
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




