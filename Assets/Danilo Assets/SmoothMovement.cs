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
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
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
}
