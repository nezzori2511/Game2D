using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class ArrowBar : MonoBehaviour
{
    [SerializeField] private Arrow playerArrow;
    [SerializeField] private Image totalarrowBar;
    [SerializeField] private Image currentarrowBar;

    private void Start()
    {
        totalarrowBar.fillAmount = playerArrow.currentArrow / 10;
    }

    private void Update()
    {
        currentarrowBar.fillAmount = playerArrow.currentArrow / 10;
    }
}
