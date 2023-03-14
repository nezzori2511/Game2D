using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameter : MonoBehaviour
{
    // Start is called before the first frame update
    public  float armorbasic;
    public  float damebasic;
    public float speedbasic;
    /*public float armorbasic1;
    public float damebasic1;
    public float speedbasic1;*/
    public int level;
    public static float armorbasictext;
    public static float damebasictext;
    public static float speedbasictext;
    public static  int leveltext;
    public int levelfireball;
    public bool healtheffect;
    public bool invulnerable;
    private PlayerAttackHand playerAttackHand;
    private void Start()
    {
        LoadPlayer();
        armorbasictext = armorbasic;
        damebasictext = damebasic;
        speedbasictext = speedbasic;
        leveltext = level;
        //SavePlayer();



    }
    private void Update()
    {
        level=leveltext;
        armorbasic = armorbasictext;
        damebasic = damebasictext;
        speedbasic = speedbasictext;
        //armorbasictext = armorbasic;
        //damebasictext = damebasic;
        //speedbasictext = speedbasic;
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        damebasic = data.damage;
        speedbasic = data.speed;
        armorbasic = data.armor;
        level = data.level;
        levelfireball = data.levelfireballsave;
        invulnerable = data.invulnerablesave;
        healtheffect = data.healtheffectsave;
        Vector3 position = Vector3.zero; // khởi tạo biến position
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;
    }
    public void Unlockhealtheffect()
    {
        healtheffect = true;
    }
    public void Unlockinvulnerable()
    {
        invulnerable = true;
    }
    public void Updatefireball(int value)
    {
        if (value == 1&&value> levelfireball)
        {
            levelfireball = 1;
        }
        else if (value == 2 && value > levelfireball)
        {
            levelfireball = 2;
        }
        else if(value == 3 && value > levelfireball)
        {
            levelfireball = 3;
        }
    }
    /*private static void UpdateParameter()
    {
        armorbasictext += 0.1f;
        damebasictext += 0.1f;
        speedbasictext += 0.02f;
    }*/
    public static void levelup()
    {
        leveltext += 1;
        armorbasictext += 0.1f;
        damebasictext += 0.1f;
        speedbasictext += 0.02f;
        
    }
    
}
