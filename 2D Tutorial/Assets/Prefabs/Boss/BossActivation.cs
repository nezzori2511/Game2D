using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public GameObject bossGO;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BossUI.instance.BossActivator();
        bossGO.SetActive(true);
       
    }
    private void Update()
    {
      
    }
    
    /* IEnumerator WaitForBoss ()
     {
         var currentSpeed = PlayerMovement.ins
         PlayerController.instance.speed = 0;
         yield return new WaitForSeconds(3f);
         PlayerController.instance.speed = currentSpeed;

     }*/
}
