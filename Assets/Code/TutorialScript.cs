using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public Text HowToWalk;
    //public Image HowToAttack;
    //public Image HowToSwapWeapon;

    // Start is called before the first frame update
    void Start()
    {
        HowToWalk.enabled = true;
        //HowToAttack.enabled = false;
        //HowToSwapWeapon.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "DoorTrigger")
        {
            Destroy(other.gameObject);
            HowToWalk.enabled = false;
        }

        if (other.name == "R2Trigger")
        {
            
        }
    }
}
