using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSystem : MonoBehaviour
{
    public GameObject projectilePrefab; //Projectile prefab
    public GameObject player;

    public bool stillShooting = false;
    public bool shootAgain = false;

    // Basic attack will fire 3 projectiles in a row with small delay.
    public void PlayerBaseShot(Sprite projectileSprite, float projectileSpeed)
    {
        if (stillShooting)
        {
            shootAgain = true;
            return;
        }

        Projectile proj = projectilePrefab.transform.GetComponent<Projectile>();

        proj.angle = 0;
        proj.speed = projectileSpeed;
        proj.isPlayerProj = true;
        proj.projSprite = projectileSprite;
        proj.projDamage = 10;

        proj.SetSortingOrder(1);

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
        stillShooting = true;
        while (stillShooting)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject playerShotLeft = ObjectPool.SharedInstance.GetPooledObject();
                if (playerShotLeft != null)
                {
                    playerShotLeft.transform.position = new Vector3(player.transform.position.x + 0.20f, player.transform.position.y + 0.40f, 0f);
                    playerShotLeft.SetActive(true);
                }

                GameObject playerShotRight = ObjectPool.SharedInstance.GetPooledObject();
                if (playerShotRight != null)
                {
                    playerShotRight.transform.position = new Vector3(player.transform.position.x + (-0.20f), player.transform.position.y + 0.40f, 0f);
                    playerShotRight.SetActive(true);
                }

                //Instantiate(projectilePrefab, new Vector3(player.transform.position.x + 0.20f, player.transform.position.y + 0.40f, 0f), Quaternion.identity);
                //Instantiate(projectilePrefab, new Vector3(player.transform.position.x + (-0.20f), player.transform.position.y + 0.40f, 0f), Quaternion.identity);
                yield return new WaitForSeconds(0.08f);
            }
            stillShooting = false;
            if (shootAgain)
            {
                shootAgain = false;
                stillShooting = true;
            }
            else
            {
                stillShooting = false;
                shootAgain = false;
            }
        }
    }
}
