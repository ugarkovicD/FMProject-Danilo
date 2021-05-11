using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScriptDestroy : MonoBehaviour
{
   public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MeleeEnemy"))
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("RangedEnemy"))
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("BomberEnemy"))
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("SadBoss"))
        {
            Destroy(this.gameObject);
        }
    }
}
