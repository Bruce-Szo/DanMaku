using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float angle;
    public Sprite sprite;

 


    void FixedUpdate()
    {
        GetComponent<Transform>().transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
