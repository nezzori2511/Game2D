using UnityEngine;

public class AddDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    
    /* public float effectivetimecurrent = Mathf.Infinity;
     private bool checktime;
     public float effectivetime=5.0f;*/
    //private float cooldownTimer1 = Mathf.Infinity;
    private bool checktime;

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            checktime = true;
            //cooldownTimer1 = 0;
            //effectivetimecurrent = 0;*/
            //collision.GetComponent<ItemAddDamageCoolDown>().Check(checktime);
            collision.GetComponent<PlayerAttackSwort>().AddDamage(damage);
            collision.GetComponent<PlayerAttackHand>().AddDamage(damage);
            
            gameObject.SetActive(false);
        }
    }
    /*private void Update()
    {
        if (checktime == true)
        {
            effectivetimecurrent += Time.deltaTime;
            if (effectivetimecurrent > effectivetime)
            {

                checktime = false;
                effectivetimecurrent = 0;

            }
            //Countdown();
        }
        //cooldownTimer1 += Time.deltaTime;
    }*/
}
