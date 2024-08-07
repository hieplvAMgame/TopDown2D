using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Unity.VisualScripting;

public static class GameConfig
{
    const int MaxLevel = 3;
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
        set => PlayerPrefs.SetInt("CurrentLevel", Mathf.Min(value, MaxLevel));
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
public static class ExtensionMethod
{
    public static string ConvertSecToMin(this int sec)
    {
        int m = sec / 60;
        int s = sec % 60;
        return string.Format($"{m:00}:{s:00}");
    }
}