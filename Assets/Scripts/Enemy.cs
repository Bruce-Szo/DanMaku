using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 100;

    public Sprite projSprite;
    public Sprite destroyedSprite;
    private Projectile proj;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            Projectile proj = collision.gameObject.GetComponent<Projectile>();
            if (proj.isPlayerProj) health -= proj.projDamage;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    // Enemies blow up on being destroyed.
    // Creates an area that will blow up other enemies if their health is low enough.
    void DestroyedAnimation()
    {

    }
}
