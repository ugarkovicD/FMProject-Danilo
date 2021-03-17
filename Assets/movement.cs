using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public static float distance = 1;
    public float speedBoostTimer;
    public float HealthIncrease = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(distance, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-distance, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0, distance, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(0, -distance, 0);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
       
    } 
}
