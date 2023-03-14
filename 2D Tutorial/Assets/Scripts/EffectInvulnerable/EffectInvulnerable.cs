using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EffectInvulnerable : MonoBehaviour
{
    [SerializeField] public float attackCooldown;
    [SerializeField] public float effectivetime;
    private Mana mana;
    //public float timeLeft;
    public float effectivetimecurrent = Mathf.Infinity;
    private float cooldownTimer = Mathf.Infinity;
    //private int timecurrent=5;
    // Start is called before the first frame update
    private Animator anim;
    //private Health playerHealth;
    private Health health;
    private PlayerMovement playerMovement;
    private SpriteRenderer spriteRend;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberofFlashes;
    public bool checkskill;
    
    private void Awake()
    {
        mana = GetComponent<Mana>();
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        health = GetComponent<Health>();
        spriteRend = GetComponent<SpriteRenderer>();
        //textInvulnerable = GetComponent<TextInvulnerable>();
    }
 
    private void Update()
    {
        if (Input.GetKey(KeyCode.X) && cooldownTimer > attackCooldown )
        {
            
            Attack_Swort();
            //textInvulnerable.time();

        }

       
        if (health.invulnerable==true)
        {
            effectivetimecurrent += Time.deltaTime;
            if(effectivetimecurrent>effectivetime)
            {

                health.invulnerable = false;
                effectivetimecurrent = 0;
                spriteRend.color = Color.white;
                Physics2D.IgnoreLayerCollision(10, 11, false);
            }
            //Countdown();
        }
        cooldownTimer += Time.deltaTime;
    }
 
    public void checkk(bool check)
    {
        checkskill = check;
    }
    private void Attack_Swort()
    {
        
        //anim.SetTrigger("effecthealth");
       
        if(mana.checkMana() == true)
        {
            mana.TakeMana(2);
            Physics2D.IgnoreLayerCollision(10, 11, true);

            spriteRend.color = new Color(255, 255, 0, 221);

            health.invulnerable = true;
            effectivetimecurrent = 0;
            //timeLeft = 5.0f;
            //mana.TakeMana(2);
            cooldownTimer = 0;
        }
       






    }
   /* IEnumerator Countdown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timeLeft--;
            
        }
     
        // Thực hiện hành động khi hết thời gian ở đây
    }*/
    /*private IEnumerator Invunerability()    // chuyen mau khi dinh dame
    {
        health.invulnerable = true;
        // main do khi bi damage
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberofFlashes; i++)
        {
            spriteRend.color = new Color(255, 255, 0, 221);
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 2));
        }
        *//*Physics2D.IgnoreLayerCollision(10, 11, false);
        health.invulnerable = false;*//*
    }*/
}
