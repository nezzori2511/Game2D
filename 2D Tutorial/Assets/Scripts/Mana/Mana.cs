using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] private float startingMana;
    [SerializeField]private float cooldownMana;
    private float cooldownTimer = Mathf.Infinity;
    public float currentMana;
    public EffectInvulnerable effectInvulnerable;
    //public bool checkmana;
    public static bool checkmanafireball;
    private void Awake()
    {
        currentMana = startingMana;
        effectInvulnerable = GetComponent<EffectInvulnerable>();

    }
    
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        AddMana();
    }
    public bool checkMana()
    {
        if(currentMana>=4)
        {
            
            return true;
        }
        else
        {
           
            return false;
        }
    }
    public bool checkManaFireBall()
    {
        if (currentMana >= 2)
        {
            //checkmanafireball = true;
            return true;
        }
        else
        {
            //checkmanafireball = false;
            return false;
        }
    }
    /*public void checkFireBall()
    {
        if (currentMana >= 2)
        {
            checkmanafireball = true;
            
        }
        else
        {
            checkmanafireball = false;
            
        }
    }*/
    public bool checkManaHealth()
    {
        if (currentMana >= 2)
        {

            return true;
        }
        else
        {

            return false;
        }
    }
    public void TakeMana(float _mana)
    {
            if(checkMana()==true)
            {
               
                if(currentMana - _mana>=0)
                {
                    
                    currentMana = currentMana - _mana;
                }
                else if(currentMana - _mana<0)
                {
                    currentMana = 0;
                }

                
                
            }
            
           
    }
    public void TakeManaHealth(float _mana)
    {
        if (checkManaHealth() == true)
        {

            if (currentMana - _mana >= 0)
            {

                currentMana = currentMana - _mana;
            }
            else if (currentMana - _mana < 0)
            {
                currentMana = 0;
            }



        }


    }
    public void TakeManaFireBall(float _mana)
    {
        if (checkManaFireBall() == true)
        {

            if (currentMana - _mana >= 0)
            {

                currentMana = currentMana - _mana;
            }
            else if (currentMana - _mana < 0)
            {
                currentMana = 0;
            }



        }


    }

    public void FullMana(int value)  // item hoi mana
    {
        currentMana = Mathf.Clamp(currentMana + value, 0, startingMana);
    }

    public void AddMana()
    {
        if (cooldownTimer >=cooldownMana )
        {
            cooldownTimer = 0;
            currentMana = Mathf.Clamp((float)(currentMana + 0.1) , 0, startingMana);
        }
    }
}
