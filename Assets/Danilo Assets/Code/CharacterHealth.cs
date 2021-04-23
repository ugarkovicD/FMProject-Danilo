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
    public Image healthImage;

    // Start is called before the first frame update
    void Start()
    {
        maxHp = 10;
        currenthp = 10;
        healthImage.sprite = health5;
    }
    // Update is called once per frame
    void Update()
    {
        if (currenthp >= maxHp)
        {
            currenthp = maxHp;
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
            SceneManager.LoadScene("TestScene");
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
    }
}
