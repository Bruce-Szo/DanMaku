using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 100;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("asdf");
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            Projectile proj = collision.gameObject.GetComponent<Projectile>();
            if (proj.isPlayerProj) health -= proj.projDamage;

            if (health <= 0) Destroy(gameObject);
        }
    }
}
