using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fury : MonoBehaviour
{
    [SerializeField] private float startingFury;
    //[SerializeField] private float cooldownFury;
    //private float cooldownTimer = Mathf.Infinity;
    public float currentFury;
    // Start is called before the first frame update
    private void Awake()
    {
        currentFury = startingFury;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddFury(float _value)
    {
        if(currentFury<10)
        {
            currentFury = currentFury + _value;
            if(currentFury>10)
            {
                currentFury = 10;
            }
        }

       



    }
    public bool checkFury()
    {
        if (currentFury ==10 )
        {

            return true;
        }
        else
        {

            return false;
        }
    }
    public void TakeFury()
    {
        if (checkFury() == true)
        {

            

            currentFury = currentFury - 10;
            
           



        }


    }
}
