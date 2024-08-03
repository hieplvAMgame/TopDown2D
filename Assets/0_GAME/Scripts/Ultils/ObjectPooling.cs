using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : PersistentSingleton<ObjectPooling>
{
    public int sizePool;
    [SerializeField] List<GameObject> objectsToPool = new List<GameObject>();
    Dictionary<GameObject,List<GameObject>> pools = new Dictionary<GameObject,List<GameObject>>();
    protected override void Awake()
    {
        base.Awake();
        CreatePool();
    }
    public void CreatePool()
    {
        foreach(var x in objectsToPool)
        {
            if (!pools.ContainsKey(x))
            {
                pools.Add(x, new List<GameObject>());
            }
            for (int i = 0; i < sizePool; i++)
            {
                GameObject o = Instantiate(x, transform);
                o.gameObject.SetActive(false);
                pools[x].Add(o);
            }
        }
    }
    public GameObject GetObjectFromPool(GameObject key)
    {
        if (pools.ContainsKey(key))
        {
            foreach(var x in pools[key])
            {
                if(!x.activeInHierarchy) return x;
            }
            GameObject o = Instantiate(key, transform);
            pools[key].Add(o);
            o.gameObject.SetActive(false);
            return o;
        }
        else
        {
            throw new System.Exception($"Pool doesnt have {key}");
        }
    }
}
