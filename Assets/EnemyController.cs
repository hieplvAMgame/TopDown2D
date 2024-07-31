using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform target;// transform of player
    [SerializeField] Navigate nav;

    HpSystem hp = new HpSystem();
    [SerializeField] HpUI hpUI;
    public int maxHP;
    private void Awake()
    {
        hp.Init(maxHP);
        hpUI.SetUp(maxHP);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GAME_TAG.Player))
        {
            Debug.Log(gameObject.name + $"Set Target {collision.gameObject.name}");
            nav.target = collision.gameObject.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(GAME_TAG.Player))
        {
            nav.target = null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GAME_TAG.Bullet))
        {
            collision.gameObject.SetActive(false);
            hp.MinusHp(1,
                () =>
                {
                    hpUI.SetValue(hp.GetCurrentHp());
                },
                () =>
                {
                    // TODO: show vfx;
                    InGameManager.Instance.TotalEnemy--;
                    gameObject.SetActive(false);
                });
        }
    }
}
