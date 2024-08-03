using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePopup<T> : MonoBehaviour where T : GamePopup<T>
{
    public static GamePopup<T> Instance;

    [SerializeField] GameObject content;
    [SerializeField] Type_Move_Popup typeMove;
    [SerializeField] float duration;
    private float x = 1500, y = 2500;
    bool isShow = false;
    protected virtual void Awake()
    {
        AnimateOpen();
    }
    [Button("Open")]
    void AnimateOpen(Action onComplete = null)
    {
        switch (typeMove)
        {
            case Type_Move_Popup.SlideFromTop:
                transform.localPosition = Vector3.up * y;
                transform.DOLocalMoveY(0, duration)
                    .OnComplete(() =>
                    {
                        transform.localPosition = Vector3.zero;
                        onComplete?.Invoke();
                    }).SetUpdate(false);
                break;
            case Type_Move_Popup.SlideFromBottom:
                transform.localPosition = Vector3.down * y;
                transform.DOLocalMoveY(0, duration)
                    .OnComplete(() =>
                    {
                        transform.localPosition = Vector3.zero;
                        onComplete?.Invoke();
                    }).SetUpdate(false);
                break;
            case Type_Move_Popup.SlideFromRight:
                transform.localPosition = Vector3.right * x;
                transform.DOLocalMoveX(0, duration)
                    .OnComplete(() =>
                    {
                        transform.localPosition = Vector3.zero;
                        onComplete?.Invoke();
                    }).SetUpdate(false);
                break;
            case Type_Move_Popup.SlideFromLeft:
                transform.localPosition = Vector3.left * x;
                transform.DOLocalMoveX(0, duration)
                    .OnComplete(() =>
                    {
                        transform.localPosition = Vector3.zero;
                        onComplete?.Invoke();
                    }).SetUpdate(false);
                break;
            case Type_Move_Popup.Scale:
                transform.localScale = Vector3.one * .1f;
                transform.DOScale(1, duration)
                    .OnComplete(() =>
                    {
                        transform.localScale = Vector3.one;
                        onComplete?.Invoke();
                    }).SetUpdate(false);
                break;

                isShow = true;
        }
    }
    [Button("Close")]
    void AnimateClose(Action onComplete = null)
    {
        switch (typeMove)
        {
            case Type_Move_Popup.SlideFromTop:
                transform.DOLocalMoveY(y, duration)
                    .OnComplete(() =>
                    {
                        transform.localPosition = Vector3.up * y;
                        onComplete?.Invoke();
                    }).SetUpdate(false);
                break;
            case Type_Move_Popup.SlideFromBottom:
                transform.DOLocalMoveY(-y, duration)
                    .OnComplete(() =>
                    {
                        transform.localPosition = Vector3.down * y;
                        onComplete?.Invoke();
                    }).SetUpdate(false);
                break;
            case Type_Move_Popup.SlideFromRight:
                transform.DOLocalMoveX(x, duration)
                    .OnComplete(() =>
                    {
                        transform.localPosition = Vector3.right * x;
                        onComplete?.Invoke();
                    }).SetUpdate(false);
                break;
            case Type_Move_Popup.SlideFromLeft:
                transform.DOLocalMoveX(-x, duration)
                    .OnComplete(() =>
                    {
                        transform.localPosition = Vector3.left * x;
                        onComplete?.Invoke();
                    }).SetUpdate(false);
                break;
            case Type_Move_Popup.Scale:
                transform.DOScale(.1f, duration)
                    .OnComplete(() =>
                    {
                        transform.localScale = Vector3.one * .1f;
                        onComplete?.Invoke();
                    }).SetUpdate(false);
                break;
        }
    }
}

public enum Type_Move_Popup
{
    SlideFromTop,
    SlideFromBottom,
    SlideFromLeft,
    SlideFromRight,
    Scale,
}


