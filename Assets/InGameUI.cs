using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField] GameWinPopup winPopup;

    public void ShowGameWinPopup()
    {
        winPopup.gameObject.SetActive(true);
    }
}
