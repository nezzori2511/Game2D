using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
   
    private Mana mana;
    //private Arrow arrow;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    private PlayerParameter parameter;
    [SerializeField]private GameObject textFireBallCool;
    private TextFireBallCoolDown text;
    public static float damage;
    public static bool triggerskill;
    private void Start()
    {
        damage = (float)(parameter.damebasic * 0.8+parameter.damebasic);
    }
    private void Awake()
    {

        text = new TextFireBallCoolDown();
        parameter = GetComponent<PlayerParameter>();
        //arrow = GetComponent<Arrow>();
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        mana = GetComponent<Mana>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && cooldownTimer > attackCooldown && playerMovement.canAttack()&&parameter.levelfireball>0  )
        {
            
            Attack();
            //textFireBallCool.SetActive(true);
        }
          

        cooldownTimer += Time.deltaTime;
       
        
    }

    public void Cooldown(float value)
    {
        attackCooldown = attackCooldown - value;
    }
   /* public bool check()
    {
        if(cooldownDamageFire<=3)
        {
            
        }
    }*/
    private void Attack()
    {
        if (mana.checkManaFireBall() == true)
        {
            mana.TakeManaFireBall(2);
            anim.SetTrigger("fireball_attack");
            triggerskill = true;
            cooldownTimer = 0;
            //text.changee(true);
            //text.UseSpell();
            fireballs[FindFireball()].transform.position = firePoint.position;
            fireballs[FindFireball()].GetComponent<ProjectileFireBall>().SetDirection(Mathf.Sign(transform.localScale.x));
           
        }

    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
