using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHand : MonoBehaviour
{
    [Header("Attack parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    private float damage;
    private PlayerParameter playerParameter;
    [Header("Collider parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;
    private Health playerHealth;

    private PlayerMovement playerMovement;

    public int noOfClicks = 0;
    float lastClickedTime = 0;
    public float maxCombeDelay;
    public Fury fury;
    private EffectFury effectFury;
    private Health health;
    public float effectivetimecurrent = Mathf.Infinity;
    public bool checktime = false;
    public float effectivetime = 5.0f;
    private float Subtractionvalue;
    private float SubtractionEffectdame;
    private float SubtractionAttackCoolDown;
    public void Start()
    {
        //damage = playerParameter.damebasic;
    }
    private void Awake()
    {
       
        health = GetComponent<Health>();
        effectFury = GetComponent<EffectFury>();
        playerParameter = GetComponent<PlayerParameter>();
        fury = GetComponent<Fury>();
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        //damage = playerParameter.damebasic;
    }
    private void Update()
    {
        if (Time.time - lastClickedTime > maxCombeDelay)
        {
            noOfClicks = 0;
        }
        if (Input.GetKeyDown(KeyCode.G)&&playerMovement.currentweapon==0 && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            lastClickedTime = Time.time;
            noOfClicks = noOfClicks + 1;
            if (noOfClicks == 1)
            {
                anim.SetBool("attack_hand1", true);
                //Attack_Hand();

                cooldownTimer += Time.deltaTime;
            }
            noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
        }
        if (checktime == true)
        {
            //item.checkitem = true;
            //item.Check(checktime);
            effectivetimecurrent += Time.deltaTime;
            if (effectivetimecurrent > effectivetime)
            {

                checktime = false;
                effectivetimecurrent = 0;
                SubtractionDamage();

            }

        }

    }
    public void return1()
    {
        if (noOfClicks >= 2)
        {
            anim.SetBool("attack_hand2", true);
        }
        else
        {
            anim.SetBool("attack_hand1", false);
            noOfClicks = 0;

        }
    }
    public void return2()
    {
        if (noOfClicks >= 3)
        {
            anim.SetBool("attack_hand3", true);
        }
        else
        {
            anim.SetBool("attack_hand1", false);
            anim.SetBool("attack_hand2", false);
            noOfClicks = 0;

        }
    }
    public void return3()
    {

        anim.SetBool("attack_hand1", false);

        anim.SetBool("attack_hand2", false);
        anim.SetBool("attack_hand3", false);
        noOfClicks = 0;


    }


    /*  private void Attack_Hand()
      {
          anim.SetTrigger("attack_hand1");
          cooldownTimer = 0;
      }*/

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public void DameEnemyHand(float _value)
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(PlayerParameter.damebasictext);

            fury.AddFury(_value);


            if (effectFury.effectrage == true)
            {
                health.AddHealth(1);
            }
           
        }
    }
    public void AddDamage(float value)
    {
        //checktime = checktime1;
        //cooldownTimer1 = 0;
        effectivetimecurrent = 0;
        Subtractionvalue = value;
        PlayerParameter.damebasictext = playerParameter.damebasic + value;
        checktime = true;

        //item.Check(checktime);
    }
    public void EffectRage(float _value, float _valueattackcooldown)
    {

        SubtractionEffectdame = _value;
        PlayerParameter.damebasictext = playerParameter.damebasic + _value;
        SubtractionAttackCoolDown = _valueattackcooldown;
        attackCooldown = attackCooldown - _valueattackcooldown;
    }
    public void SubtractionDamage()
    {
        PlayerParameter.damebasictext = playerParameter.damebasic - Subtractionvalue;
        attackCooldown = attackCooldown - SubtractionAttackCoolDown;
    }
    public void SubtractionEffectRage()
    {
        PlayerParameter.damebasictext = playerParameter.damebasic - SubtractionEffectdame;
    }
}
