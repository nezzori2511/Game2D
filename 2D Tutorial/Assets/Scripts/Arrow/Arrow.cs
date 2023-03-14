using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private int startingArrow;
    public int currentArrow;
    
    //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        currentArrow = startingArrow;
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    
    public bool checkArrow()
    {
        if (currentArrow >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void TakeArrow(int _mana)
    {
        if (checkArrow() == true)
        {

            currentArrow =currentArrow - _mana;
        }
    }
    public void AddArrow(int _value)
    {
        currentArrow = currentArrow + _value;
    }
}
