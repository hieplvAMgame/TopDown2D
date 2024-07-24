using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Gun: MonoBehaviour
{
    private int totalBullet;
    private float timeLoading;
    private float fireRate;
    //public float angle = 0;
    private int damage;
    private float speed;

    public int currentBullet;

    public Transform shootingPoint;

    PlayerShootManager shootManagaer;
    public virtual void Setup(int _totalBullet, float _timeLoading, float _fireRate, int _damage, float _speed, PlayerShootManager playerShootManager)
    {
        totalBullet = _totalBullet;
        timeLoading = _timeLoading;
        fireRate = _fireRate;
        damage = _damage;
        speed = _speed;

        shootManagaer = playerShootManager;

        currentBullet = totalBullet;
    }
    bool isReloading = false;
    Coroutine CoShoot = null;
    public virtual void Shoot(Action onComplete = null)
    {
        Debug.Log("SHOOT!");
        currentBullet--;
        if (currentBullet <= 0 && !isReloading) Reload();
        DOVirtual.DelayedCall(fireRate, () =>
        {
            onComplete?.Invoke();
            CoShoot = null;
        });
    }
    public virtual void Reload()
    {
        Debug.Log("RELOAD!");
        isReloading = true;
        DOVirtual.DelayedCall(timeLoading, () =>
        {
            currentBullet = totalBullet;
            isReloading = false;
        });
    }
    IEnumerator IShoot(Action onComplete = null)
    {

        yield return new WaitForSeconds(fireRate);
    }
    public float GetSpeed() => speed;
}

public enum Type_Gun
{
    Pistol,
    Riffle,
    Shotgun
}