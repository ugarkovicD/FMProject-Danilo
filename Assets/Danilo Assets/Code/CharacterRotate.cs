using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotate : MonoBehaviour
{
    public Camera cameraObject;
    public GameObject Player;
    public Transform Gun;
    public GameObject bullet;
    private float bulletSpeed = 30;
    public float ReloadTime = 2f;
    public float BulletAmmountAR = 30;
    public bool canShootAR;
    // Start is called before the first frame update
    void Start()
    {
        canShootAR = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            canShootAR = false;
        }           
        if (BulletAmmountAR == 0)
        {
            canShootAR = false;
        }
        if (ReloadTime <= 0)
        {
            canShootAR = true;
            ReloadTime = 2f;
            BulletAmmountAR = 30;
        }
        if (canShootAR == false)
        {
            ReloadTime -= 1 * Time.deltaTime;
        }
        cameraObject.transform.position = new Vector3(transform.position.x, transform.position.y, cameraObject.transform.position.z);
    }
    void fireBullet(Vector2 direction, float rotationZ)
    {
        if (canShootAR == true)
        {
            GameObject b = Instantiate(bullet) as GameObject;
            b.transform.position = Gun.transform.position;
            b.transform.rotation = Quaternion.Euler(0, 0, rotationZ + 270);
            b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            BulletAmmountAR -= 1;
        }       
    }
    
}
