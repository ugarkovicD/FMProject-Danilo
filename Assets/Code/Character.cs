using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    //Health
    public static float currenthp;
    public Sprite health0;
    public Sprite health1;
    public Sprite health2;
    public Sprite health3;
    public Sprite health4;
    public Sprite health5;
    public Image healthImage;

    private float speed = 5;
    public Rigidbody2D rb;

    public static bool facingRight;
    public static bool facingLeft;

    // Start is called before the first frame update
    void Start()
    {
        healthImage.sprite = health5;
        facingRight = true;
        facingLeft = false;
        currenthp = 5;
    }
    // Update is called once per frame
    void Update()
    {
        if (currenthp == 5)
        {
            healthImage.sprite = health5;
        }
        if (currenthp == 4)
        {
            healthImage.sprite = health4;
        }
        if (currenthp == 3)
        {
            healthImage.sprite = health3;
        }
        if (currenthp == 2)
        {
            healthImage.sprite = health2;
        }
        if (currenthp == 1)
        {
            healthImage.sprite = health1;
        }
        if (currenthp == 0)
        {
            healthImage.sprite = health0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            facingRight = true;
            facingLeft = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            facingRight = false;
            facingLeft = true;
        }     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            currenthp -= 1;
            Debug.Log("Health" + currenthp);
        }       
    }
}
