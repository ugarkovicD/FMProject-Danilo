using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public static float distance = 1;
    public float speedBoostTimer;
    public float HealthIncrease = 2;
    public static bool facingUp;
    public static bool facingDown;
    public static bool facingRight;
    public static bool facingLeft;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            facingDown = false;
            facingUp = false;
            facingLeft = false;
            facingRight = true;            
            transform.Translate(distance, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            facingDown = false;
            facingUp = false;
            facingLeft = true;
            facingRight = false;
            transform.Translate(-distance, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            facingDown = false;
            facingUp = true;
            facingLeft = false;
            facingRight = false;
            transform.Translate(0, distance, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            facingDown = true;
            facingUp = false;
            facingLeft = false;
            facingRight = false;
            transform.Translate(0, -distance, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
       
    } 
}
