using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public HpSystem hp;
    public HpUI hpUi;
    private void Awake()
    {
        hp = new HpSystem();
        hp.Init(5);
        hpUi.SetUp(hp.maxHP);
    }
    [Button("Revive")]
    public void Revive()
    {
        hp.Revive();
    }
    void OnReceiveDamage(Vector3 pos)
    {
        PlayerAction.onReceiveDamage?.Invoke(pos);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag(GAME_TAG.Enemy))
    //    {
    //        OnReceiveDamage(collision.contacts[0].point);
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HP"))
        {
            hp.AddHp(2, () =>
            {
                // Vfx
                // Sfx
                // ...
            });
        }
        if (collision.gameObject.CompareTag(GAME_TAG.Enemy))
        {
            hp.MinusHp(1, () =>
            {
                Debug.LogError("Hurt");
                hpUi.SetValue(hp.GetCurrentHp());
                // Vfx
                // Sfx
                // Shake Camera
                // ...
            }, () =>
            {
                Debug.LogError("DIE!");
                InGameManager.Instance.GameOver();
            });
        }
    }


    // TODO: Create HPSystem

    // VfxManager
    // Spawn Vfx t?i pos event g?i v?

    // Bullet
    // HPSystem
    // Demo va cham
    // pooling: Generic Parameter
    // Singleton
}
