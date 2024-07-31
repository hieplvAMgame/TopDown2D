using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    [SerializeField] Image hpBar;
    int maxHP;
    private void Awake()
    {
        hpBar.fillAmount = 1f;
    }
    public void SetUp(int maxHP) => this.maxHP = maxHP;
    public void SetValue(int currentHp) => hpBar.DOFillAmount((float)currentHp/maxHP, .2f);
}
