using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public static class GameConfig
{
    static List<bool> listGuns; // -> string
    public const string DATA_GUN = "Data_Gun";
    public static void GetDataGun()
    {
        if (!PlayerPrefs.HasKey(DATA_GUN))
        {
            Debug.Log("Create new Data");
            listGuns = new List<bool>()
            {
                true,false,false,false,false
            };
            SaveDataGun();
        }
        else
        {
            listGuns = JsonConvert.DeserializeObject<List<bool>>(PlayerPrefs.GetString(DATA_GUN));
        }
        foreach (var x in listGuns)
            Debug.Log(x);
    }
    public static void SaveDataGun()
    {
        Debug.Log("Save Data");
        string data = JsonConvert.SerializeObject(listGuns);
        PlayerPrefs.SetString(DATA_GUN, data);
    }
    public static void UnlockNewGun(int index)
    {
        listGuns[index] = true;
        SaveDataGun();
    }
    public static int CurrenLevel
    {
        get => PlayerPrefs.GetInt("CurrentLevel", 0);
        set => PlayerPrefs.SetInt("CurrentLevel", value);
    }

    public static int ClearedLevel
    {
        get => PlayerPrefs.GetInt("ClearedLevel", -1);
        set => PlayerPrefs.SetInt("ClearedLevel", value);
    }
}
public struct GAME_TAG
{
    public const string Enemy = "Enemy";
    public const string Player = "Player";
    public const string Bullet = "Bullet";
    public const string Wall = "Wall";
}
