using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public float speed = 7;
    private Vector2 targetPos;
    public float distance = 1;
    public static bool facingUp;
    public static bool facingDown;
    public static bool facingRight;
    public static bool facingLeft;
    public float distanceDash = 3;
    public int speedDash = 27;
    public bool dashing;
    public float dashTimer;
    public bool ArivedOnTarget;
    //Passive items and Notches for item ammount
    public bool haveSpace;
    public int NotchesAmmount;
    public bool collidingItem;
    //items
    public GameObject itemStrength;
    public GameObject itemSpeed;
    public GameObject itemDashSpeed;
    public GameObject itemCooldown;
    public GameObject itemAttackSpeed;
    public GameObject itemDashLength;
    public GameObject itemHealth;
    public GameObject itemMana;

    void Start()
    {
        haveSpace = true;
    }
    // Update is called once per frame
    void Update()
    {        
        //walking
        if (dashing == false) 
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        if (dashing == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                targetPos = new Vector2(transform.position.x + distance, transform.position.y);
                facingDown = false;
                facingUp = false;
                facingLeft = false;
                facingRight = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                targetPos = new Vector2(transform.position.x - distance, transform.position.y);
                facingDown = false;
                facingUp = false;
                facingLeft = true;
                facingRight = false;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                targetPos = new Vector2(transform.position.x, transform.position.y + distance);
                facingDown = false;
                facingUp = true;
                facingLeft = false;
                facingRight = false;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                targetPos = new Vector2(transform.position.x, transform.position.y - distance); facingDown = true;
                facingUp = false;
                facingLeft = false;
                facingRight = false;
                facingDown = true;
            }
        }        
        //dashing
        dashTimer -= 1 * Time.deltaTime;

        if (dashing == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speedDash * Time.deltaTime);
        }

        if (dashTimer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                dashTimer = 4;
                dashing = true;
                if (facingDown == true)
                {
                    targetPos = new Vector2(transform.position.x, transform.position.y - distanceDash);
                }
                if (facingUp == true)
                {
                    targetPos = new Vector2(transform.position.x, transform.position.y + distanceDash);
                }
                if (facingRight == true)
                {
                    targetPos = new Vector2(transform.position.x + distanceDash, transform.position.y);
                }
                if (facingLeft == true)
                {
                    targetPos = new Vector2(transform.position.x - distanceDash, transform.position.y);
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
        if (collision.name == "Square 16")
        {
            Destroy(collision.gameObject);
        }
    }
}
