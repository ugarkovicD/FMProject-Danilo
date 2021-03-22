using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    public bool inRadius;
    public float bombtimer = 2;
    public float speed;
    private Transform Player;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(Player.position.x, Player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            bombExplode();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        while (collision.name == "Player")
        {
            inRadius = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            inRadius = false;
        }
    }
    public void bombExplode()
    {
        bombtimer -= 1 * Time.deltaTime;
        if (bombtimer < 0 && inRadius == true)
        {
            
        }
    }
}