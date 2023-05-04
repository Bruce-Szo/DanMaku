using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;

    public Vector2 velo;
    public float speed;
    public float angle;
    public bool isPlayerProj;
    public int projDamage;

    public Sprite projSprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<Transform>().Rotate(new Vector3(0, 0, -angle));
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = projSprite;

        projDamage = 5;
    }

    void FixedUpdate()
    {
        angle *= Mathf.Deg2Rad;
        velo = new Vector2(Mathf.Sin(angle) * speed, Mathf.Cos(angle) * speed);
        rb.velocity = velo;
    }

    public void SetProjectileDamage(int newProjDamage)
    {
        projDamage = newProjDamage;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            if (isPlayerProj)
            {
                return;
            }
        }
        Destroy(gameObject);
    }

    public void SetSortingOrder(int sortingOrder)
    {
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
    }
}
