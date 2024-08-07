using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameWinPopup : GamePopup<GameWinPopup>
{
    [SerializeField] TMP_Text txtEnemyKilled;
    [SerializeField] TMP_Text txtTimePlay;
    [SerializeField] TMP_Text txtGoldReward;

    [SerializeField] Button btnContinue;
    [SerializeField] Button btnHome;



    protected override void Awake()
    {
        base.Awake();
        AddListenerButton();
    }

    private void AddListenerButton()
    {
        btnContinue.onClick.AddListener(OnClickBtnContinue);
        btnHome.onClick.AddListener(OnClickBtnHome);
    }

    private void OnClickBtnHome()
    {
    }

    private void OnClickBtnContinue()
    {
        AnimateClose();
        GameUIManager.Instance.loadingPanel.FadeScreenOut(1, () =>
        {
            InGameManager.Instance.GamePrepare();
            GameUIManager.Instance.loadingPanel.FadeScreenIn(1);
        });
        
    }

    private void OnEnable()
    {
        SetupUI();

    }
    protected override void OnAnimateComplete()
    {
        base.OnAnimateComplete();
    }
    public void SetupUI()
    {
        txtTimePlay.text = "Time play: " + InGameManager.Instance.GetTimePlay().ConvertSecToMin();
        txtEnemyKilled.text = "Total enemy killed: " + InGameManager.Instance.GetNumberEnemyKilled().ToString();
        txtGoldReward.text = "500";
    }
}
