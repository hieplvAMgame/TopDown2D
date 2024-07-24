using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerAction
{
    public delegate void OnPlayerReceiveDamage(Vector3 pos);
    public delegate void OnPlayerDie();

    public static OnPlayerReceiveDamage onReceiveDamage;
    public static OnPlayerDie onDie;
}
