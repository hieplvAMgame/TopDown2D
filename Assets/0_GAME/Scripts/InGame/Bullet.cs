using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Speed
    // H??ng b?n
    Rigidbody2D rb;
    [SerializeField] float _speed;
    [SerializeField] Vector2 _dirShoot;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Setup(float moveSpeed, Vector2 direction)
    {
        _speed = moveSpeed;
        _dirShoot = direction;
        Invoke(nameof(DestroyBullet), 5f);
    }
    private void FixedUpdate()
    {
        rb.AddForce(_dirShoot * _speed, ForceMode2D.Impulse);
    }
    void DestroyBullet()
    {
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag(GAME_TAG.Wall)|| collision.transform.CompareTag(GAME_TAG.Enemy))
        {
            DestroyBullet();
        }
    }
}
