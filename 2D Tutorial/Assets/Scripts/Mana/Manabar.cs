using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manabar : MonoBehaviour
{
    [SerializeField] private Mana playerMana;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    // Start is called before the first frame update
    private void Start()
    {
        totalhealthBar.fillAmount = playerMana.currentMana / 10;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerMana.currentMana / 10;
    }
}
