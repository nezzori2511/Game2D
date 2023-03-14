using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] private float startingExp;
    
   
    public  float currentExp;
    public static float currentExptext;
    private PlayerParameter playerParameter;
    private void Awake()
    {
        currentExptext = startingExp;
        currentExp = startingExp;
        

    }

    private void Update()
    {
        currentExp = currentExptext;
    }
    public static void AddExp(float value)
    {
        if(currentExptext + value>=10)
        {
            currentExptext = (currentExptext + value) - 10;
            PlayerParameter.levelup();
        }
        else 
        {
            currentExptext = currentExptext + value;
        }
    }
}
