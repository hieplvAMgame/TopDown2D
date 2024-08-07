using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : PersistentSingleton<GameUIManager>
{
    [Header("Ingame UI")]
    [SerializeField] public InGameUI ingameUI;
    [SerializeField] Button btnStart;

    [SerializeField] GameObject outGameUI;
    [SerializeField] public LoadingPanel loadingPanel;

    protected override void Awake()
    {
        base.Awake();
        AddListenerButton();
    }
    public void ShowUI(bool isIngame)
    {
        ingameUI.gameObject.SetActive(isIngame);
        outGameUI.SetActive(!isIngame);
    }
    private void AddListenerButton()
    {
        btnStart.onClick.AddListener(() =>
        {
            InGameManager.Instance.GameStart();
            ShowButtonStart(false);
        });
    }
    public void ShowButtonStart(bool isShow) => btnStart.gameObject.SetActive(isShow);

}
