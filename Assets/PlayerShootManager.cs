using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootManager : MonoBehaviour
{
    PlayerController controller;
    public Gun currentGun;
    [SerializeField] Transform holderGun;
    public GameObject bulletPrefab;
    // Setup khi spawn Gun ->ref
    private void Awake()
    {
        currentGun = GameObject.Instantiate(Resources.Load<GameObject>("0"), holderGun).GetComponent<Gun>();
        controller = GetComponent<PlayerController>();
        currentGun.Setup(10, 1, .2f, 5, 10, this);
        SetFov();
    }
    private void Update()
    {
        if (!InGameManager.Instance.isGameStart) return;
        if (!inShooting)
            Shoot();
    }
    public bool inShooting = false;
    Bullet bulletClone;
    public void Shoot()
    {
        if (controller.IsShooting)
        {
            if (currentGun.currentBullet <= 0)
            {
                controller.IsShooting = false;
                inShooting = false;
                return;
            }
            inShooting = true;
            //bulletClone = Instantiate(bulletPrefab, currentGun.shootingPoint.position, Quaternion.identity).GetComponent<Bullet>(); // pooling sau
            //GameObject o = ObjectPooling.Instance.GetObjectFromPool(bulletPrefab);
            //bulletClone = o.GetComponent<Bullet>();
            //bulletClone.gameObject.SetActive(true);
            //bulletClone.Setup(currentGun.GetSpeed(), currentGun.shootingPoint.up);
            Camera.main.transform.GetComponent<CameraShake.CameraShaker>().ShakePresets.Explosion2D();
            currentGun.Shoot(() =>
            {
                controller.IsShooting = false;
                inShooting = false;
            });
            // Spawn bullet <- pooling => GetBulletData()
            // bullet.Setup()
        }
    }
    [SerializeField] GameObject edgeLeft;
    [SerializeField] GameObject edgeRight;

    public void SetFov()
    {
        if (currentGun.angle <= 0)
        {
            edgeLeft.SetActive(false);
            edgeRight.SetActive(false);
            return;
        }
        edgeLeft.SetActive(true);
        edgeRight.SetActive(true);
        edgeRight.transform.eulerAngles = Vector3.back * currentGun.angle / 2;
        edgeLeft.transform.eulerAngles = Vector3.forward * currentGun.angle / 2;
    }
}
