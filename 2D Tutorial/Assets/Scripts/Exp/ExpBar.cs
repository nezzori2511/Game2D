using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExpBar : MonoBehaviour
{
    [SerializeField] private Exp playerExp;
    [SerializeField] private Image totalexpBar;
    [SerializeField] private Image currentexpBar;
    // Start is called before the first frame update
    private void Start()
    {
        totalexpBar.fillAmount = playerExp.currentExp / 10;
    }

    private void Update()
    {
        currentexpBar.fillAmount = playerExp.currentExp / 10;
    }
}
