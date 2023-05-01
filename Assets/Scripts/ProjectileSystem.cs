using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSystem : MonoBehaviour
{
    public GameObject charProjectile;
    public GameObject enemyProjectile;

    public bool shootTowardsPlayer; // Shots can go towards

    // Basic attack will fire 4 projectiles in a row with small delay.
    public void PlayerBaseShot()
    {
        return;
    }

    // Used for enemies that will shoot projectiles in a circular arc from their current location
    public void CircleShot(Vector2 loc, int bullets, int times)
    {
        return;
    }
}
