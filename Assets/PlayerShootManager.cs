using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootManager : MonoBehaviour
{
    PlayerController controller;
    public Gun currentGun;

    public GameObject bulletPrefab;
    // Setup khi spawn Gun ->ref
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        currentGun.Setup(5, 5, 1, 5, 10, this);
    }
    private void Update()
    {
        if (!inShooting)
            Shoot();
    }
    public bool inShooting = false;
    Bullet bulletClone;
    public void Shoot()
    {
        if (controller.IsShooting)
        {
            if(currentGun.currentBullet<=0)
            {
                controller.IsShooting = false;
                inShooting = false;
                return;
            }
            inShooting = true;
            bulletClone = Instantiate(bulletPrefab, currentGun.shootingPoint.position, Quaternion.identity).GetComponent<Bullet>(); // pooling sau
            //GameObject o = ObjectPooling.Instance.GetObjectFromPool(bulletPrefab);
            //bulletClone = o.GetComponent<Bullet>();
            //bulletClone.gameObject.SetActive(true);
            bulletClone.Setup(currentGun.GetSpeed(), currentGun.shootingPoint.up);
            currentGun.Shoot(() =>
            {
                controller.IsShooting = false;
                inShooting = false;
            });
            // Spawn bullet <- pooling => GetBulletData()
            // bullet.Setup()
        }
    }
}
