using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    Vector3 offset;

    private void Awake()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        offset = target.position - transform.position;
    }
    Vector3 targetPos;
    private void FixedUpdate()
    {
        targetPos = Vector3.Lerp(transform.position, target.position - offset, speed * Time.fixedDeltaTime);
        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);
        transform.position = targetPos;
    }

    // Clamp Pos

    [SerializeField] float minX, maxX, minY, maxY;
}
