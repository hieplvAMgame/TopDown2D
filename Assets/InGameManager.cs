using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InGameManager : MonoBehaviour
{
    public static InGameManager Instance;

    [SerializeField] public PlayerPhysics player;

    [SerializeField] List<EnemyController> enemies = new List<EnemyController>();
    TimerExtension timer = new TimerExtension();
    bool isPlayerAlive => player.hp.IsAlive;


    [SerializeField] TMP_Text txtTimer;
    public int time;
    public void UpdateUI()
    {
        int _time = timer.GetTime();
        int m = _time / 60;
        int s = _time % 60;
        txtTimer.text = $"{m:00}:{s:00}";
    }
    public void GameOver()
    {

    }
    public void StartGame()
    {
        timer.StartCountDown();
    }
    bool isGameWin = false;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        txtTimer.text = time.ToString();
        // Prepare: Data 1p30s
        timer.InitTimer(this, time, UpdateUI, GameOver);
        StartGame();
    }
}

public class TimerExtension
{
    int timer;
    MonoBehaviour timerMonoBehaviour;
    Action onTimeTick = null;
    Action onTimeUp = null;
    int _t;
    public void InitTimer(MonoBehaviour owner, int timer, Action OnTimeStick = null, Action OnTimerUp = null)
    {
        this.timer = timer;
        timerMonoBehaviour = owner;
        onTimeTick = OnTimeStick;
        onTimeUp = OnTimerUp;
    }

    WaitForSeconds sec = new WaitForSeconds(1);

    public void StartCountDown()
    {
        if (CoCountdown == null)
        {
            CoCountdown = timerMonoBehaviour.StartCoroutine(ICountdown());
        }
    }
    public void StopCountDown()
    {
        timerMonoBehaviour.StopCoroutine(CoCountdown);
        CoCountdown = null;
    }
    public void ResetCountDown()
    {
        _t = timer;
        CoCountdown = null;
    }
    public int GetTime() => _t;
    IEnumerator ICountdown()
    {
        _t = timer;
        while (_t > 0)
        {
            _t -= 1;
            yield return sec;
            onTimeTick?.Invoke();
        }
        onTimeUp?.Invoke();
        timer = 0;
    }
    Coroutine CoCountdown = null;
}