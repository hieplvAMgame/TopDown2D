using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSingleton<T> : MonoBehaviour where T: Component
{
    private static T _singleton;
    public static T Instance => _singleton;

    private void Awake()
    {
        if (_singleton == null)
        {
            _singleton = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }
    }

}
