using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    [SerializeField] Camera cameraMain;
    [SerializeField] Joystick joystick;
    [SerializeField] float offsetAngleSprite = 90;

    PlayerPhysics playerPhysics;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPhysics = GetComponent<PlayerPhysics>();
    }
    Vector2 _dirMove;
    Vector3 joyPos;

    Vector3 _dirRot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        _dirMove = new Vector2(x, y).normalized;

        float joyX = joystick.Horizontal;
        float joyY = joystick.Vertical;

        _dirRot = new Vector3(joyX, joyY, 0).normalized;
        float angle = Mathf.Atan2(joyY, joyX) * Mathf.Rad2Deg - offsetAngleSprite;
        if (angle < 0)
            angle += 360;
        if (_dirRot.sqrMagnitude != 0)
            transform.eulerAngles = new Vector3(0, 0, angle);

        if (Input.GetKeyDown(KeyCode.Space) && !IsShooting)
            IsShooting = true;

    }
    public bool IsShooting = false;
    private void FixedUpdate()
    {
        if (playerPhysics.hp.IsAlive)
            rb.velocity = _dirMove * moveSpeed;
        else
            rb.velocity = Vector2.zero;
    }
}
