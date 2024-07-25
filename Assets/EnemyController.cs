using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb;
    [SerializeField] Transform target;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        target = InGameManager.Instance.player.transform;
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.localEulerAngles = Vector3.forward * angle;
        rb.velocity = dir.normalized * speed;
    }
}
