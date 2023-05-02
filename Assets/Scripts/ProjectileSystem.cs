using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSystem : MonoBehaviour
{
    public GameObject projectilePrefab; //Projectile prefab
    public GameObject player;

    // Basic attack will fire 4 projectiles in a row with small delay.
    public void PlayerBaseShot(Sprite projectileSprite, float projectileSpeed)
    {
        projectilePrefab.transform.GetComponent<Projectile>().angle = 0;
        projectilePrefab.transform.GetComponent<Projectile>().speed = projectileSpeed;
        projectilePrefab.transform.GetComponent<Projectile>().projSprite = projectileSprite;

        StartCoroutine(SequentialShots());
    }

    public void EnemyBaseShot(Vector2 enemyLocation, Projectile projectile, int times, float speed)
    {
        return;
    }

    // Used for enemies that will shoot projectiles in a circular arc from their current location
    // From *enemyLocation *enemyProjectile(s) will shoot *bullets in a circular arc (360/bullets
    // IE 4 bullets = one every 90 degrees) *times times.
    public void CircleShot(Vector2 enemyLocation, Projectile enemyProjectile, int bullets, int times)
    {
        return;
    }

    IEnumerator SequentialShots()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(projectilePrefab, new Vector3(player.transform.position.x + 0.20f, player.transform.position.y + 0.34f, 0f), Quaternion.identity);
            Instantiate(projectilePrefab, new Vector3(player.transform.position.x + (-0.20f), player.transform.position.y + 0.34f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(0.08f);
        }
    }
}
