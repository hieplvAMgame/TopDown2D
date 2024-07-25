using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class GunManager : MonoBehaviour
{
    [SerializeField] List<GunData> guns;

    [SerializeField] TextAsset dataGun;

    [Button("Parse Json")]
    public void ParseJsonData()
    {
        string data = JsonConvert.SerializeObject(guns);
        Debug.Log(data);
    }
    [Button("GetData")]
    public void GetDataGun()=>
        guns = JsonConvert.DeserializeObject<List<GunData>>(dataGun.ToString());
}
