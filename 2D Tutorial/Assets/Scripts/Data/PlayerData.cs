using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public float armor;
    public float speed;
    public float damage;
    public int level;
    public int levelfireballsave;
    public bool healtheffectsave;
    public bool invulnerablesave;
    public float[] position;
    public PlayerData(PlayerParameter player)
    {
        levelfireballsave = player.levelfireball;
        healtheffectsave = player.healtheffect;
        invulnerablesave = player.invulnerable;
        armor = player.armorbasic;
        speed = player.speedbasic;
        damage = player.damebasic;
        level = player.level;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

}
