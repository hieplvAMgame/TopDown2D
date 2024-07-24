using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HpSystem
{
    public int maxHP;
    public int currentHp;
    public bool IsAlive
    {
        get
        {
            if (currentHp > 0)
                return true;
            else return false;
        }
    }
    public int GetCurrentHp() => currentHp;
    public void Init(int _maxHp)
    {
        maxHP = _maxHp;
        currentHp = maxHP;
    }
    public HpSystem Revive()
    {
        currentHp = maxHP;
        return this;
    }
    public HpSystem AddHp(int value, Action onAddHp = null)
    {
        if (!IsAlive) return this;
        currentHp += value;
        if (currentHp > maxHP) currentHp = maxHP;
        onAddHp?.Invoke();
        return this;
    }
    public HpSystem MinusHp(int value,Action onMinusHp = null, Action onDie = null)
    {
        currentHp -= value;
        onMinusHp?.Invoke();
        if (currentHp <= 0)
        {
            currentHp = 0;
            onDie?.Invoke();
        }
        return this;
    }
}
