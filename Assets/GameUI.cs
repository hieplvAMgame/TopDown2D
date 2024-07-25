using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    [SerializeField] Image fillImgFireRate;
    [SerializeField] GameObject panelReloading;
    public void ShowVisualFireRate(float time)
    {
        StartCoroutine(ICountdownFireRate(time));
    }
    IEnumerator ICountdownFireRate(float time)
    {
        float _time = time;
        fillImgFireRate.fillAmount = 1;
        while (_time > 0)
        {
            fillImgFireRate.fillAmount = _time / time;
            yield return new WaitForEndOfFrame();
            _time -= Time.deltaTime;
        }
        fillImgFireRate.fillAmount = 0;
    }
    public void ShowPanelReloading(bool isShow)
    {
        panelReloading.SetActive(isShow);
    }
    private void OnDestroy()
    {
        Instance = null;
    }
}
