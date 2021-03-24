using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public float speed = 7;
    private Vector2 targetPos;
    public float distance = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetPos = new Vector2(transform.position.x + distance, transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetPos = new Vector2(transform.position.x - distance, transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + distance);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - distance);
        }
    }
}
