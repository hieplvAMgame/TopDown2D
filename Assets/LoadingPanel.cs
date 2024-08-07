using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    [SerializeField] Image fadeImg;

    private void Awake()
    {
    }
    public void FadeScreenOut(float duration, Action callback = null)
    {
        fadeImg.gameObject.SetActive(true);
        fadeImg.DOFade(1, duration)
            .SetEase(Ease.OutQuint)
            .OnComplete(() =>
            {
                callback?.Invoke();
            });
    }
    public void FadeScreenIn(float duration, Action callback = null)
    {
        fadeImg.DOFade(0, duration)
            .SetEase(Ease.InQuint)
            .OnComplete(() =>
            {
                callback?.Invoke();
                fadeImg.gameObject.SetActive(false);
            });
    }
    [Button("Loading")]

    public void LoadingScene()
    {
        FadeScreenOut(1, () =>
        {
            FadeScreenIn(1, () =>
            {
                Debug.Log("LOADING COMPLETE!");
            });
        });
    }

}
