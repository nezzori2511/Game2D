using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            //cooldownTimer1 = 0;
            //effectivetimecurrent = 0;*/
            //collision.GetComponent<ItemAddDamageCoolDown>().Check(checktime);
            collision.GetComponent<PlayerParameter>().SavePlayer();
            

           
        }
    }
}
