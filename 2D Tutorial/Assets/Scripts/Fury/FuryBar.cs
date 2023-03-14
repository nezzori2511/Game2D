using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FuryBar : MonoBehaviour
{
    [SerializeField] private Fury playerFury;
    [SerializeField] private Image totalfuryBar;
    [SerializeField] private Image currentfuryBar;

    private void Start()
    {
        totalfuryBar.fillAmount = playerFury.currentFury / 10;
    }

    private void Update()
    {
        currentfuryBar.fillAmount = playerFury.currentFury / 10;
    }
}
