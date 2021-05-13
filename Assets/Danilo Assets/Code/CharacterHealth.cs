using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
    //Health
    public static float maxHp;
    public static float currenthp;
    public Sprite health0;
    public Sprite health1;
    public Sprite health2;
    public Sprite health3;
    public Sprite health4;
    public Sprite health5;
    public Sprite health6;
    public Sprite health7;
    public Sprite health8;
    public Sprite health9;
    public Sprite health10;
    public Image healthImage;

    // Start is called before the first frame update
    void Start()
    {
        maxHp = 10;
        currenthp = 10;
        healthImage.sprite = health10;
    }
    // Update is called once per frame
    void Update()
    {
        if (maxHp >= 12)
        {
            maxHp = 12;          
        }
        if (currenthp >= maxHp)
        {
            currenthp = maxHp;
        }
        if (currenthp == 11)
        {
            healthImage.sprite = health10;
        }
        if (currenthp == 10)
        {
            healthImage.sprite = health10;
        }
        if (currenthp == 9)
        {
            healthImage.sprite = health9;
        }
        if (currenthp == 8)
        {
            healthImage.sprite = health8;
        }
        if (currenthp == 7)
        {
            healthImage.sprite = health7;
        }
        if (currenthp == 6)
        {
            healthImage.sprite = health6;
        }
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
        if (currenthp <= 0)
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            currenthp -= 1;
            Debug.Log("Health" + currenthp);
        }
        if (collision.name == "HealthItemUPG(Clone)")
        {
            Destroy(collision.gameObject);
            maxHp += 1;
        }
        if (collision.name == "Angry Boss")
        {
            currenthp -= 2;
        }
    }
}
