using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class InGameManager : MonoBehaviour
{
    [SerializeField] CameraFollower cameraFollower;
    public static InGameManager Instance;

    [SerializeField] List<LevelData> datas = new List<LevelData>();


    [SerializeField] public PlayerPhysics player;

    TimerExtension timer = new TimerExtension();
    bool isPlayerAlive => player.hp.IsAlive;

    [SerializeField] TMP_Text txtTimer;

    LevelData currentLevelData;


    int totalEnemy;
    [ShowInInspector]
    public int TotalEnemy
    {
        get => currentNumEnemy;
        set
        {
            if (value <= 0)
            {
                currentNumEnemy = 0;
                if (timer.GetTime() > 0) GameWin();
            }
            else
                currentNumEnemy = value;
        }
    }
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
    public void GameWin()
    {
        Debug.Log("Game Win");
    }
    public void StartGame()
    {
        timer.StartCountDown();
    }
    bool isGameWin = false;
    LevelManager levelManager;
    int currentNumEnemy;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        GameConfig.GetDataGun();
        //currentLevelData = datas[GameConfig.CurrenLevel];
        //totalEnemy = currentLevelData.totalEnemy;
        //txtTimer.text = currentLevelData.timePlay.ToString();
        // Prepare: Data 1p30s
        timer.InitTimer(this, /*currentLevelData.timePlay*/600, UpdateUI, GameOver);
        levelManager = Instantiate(Resources.Load("Level0"), transform).GetComponent<LevelManager>();
        levelManager.SetCameraBound(ref cameraFollower);
        currentNumEnemy = levelManager.GetTotalEnemies();
        StartGame();
    }
     int indexGun;
    [Button("Unlock new gun")]
    public void UnLockGun() => GameConfig.UnlockNewGun(indexGun);

    private void Update()
    {
    }
    //public void OnKillenemy()
    //{
    //    currentNumEnemy--;
    //    if (currentNumEnemy <= 0) GameWin();
    //}
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