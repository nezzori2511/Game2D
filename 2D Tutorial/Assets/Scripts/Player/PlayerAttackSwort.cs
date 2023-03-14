using UnityEngine;

public class PlayerAttackSwort : MonoBehaviour
{
    [Header("Attack parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
     private PlayerParameter playerParameter;

    [Header("Collider parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private GameObject texttimeitem;
    private Animator anim;
    private Health playerHealth;

    private PlayerMovement playerMovement;
    public int noOfClicks = 0;
    float lastClickedTime = 0;
    public float maxCombeDelay;
    public float effectivetimecurrent = Mathf.Infinity;
    public bool checktime=false;
    public static float effectivetime =5.0f;
    private float Subtractionvalue;
    private float SubtractionEffectdame;
    private float SubtractionAttackCoolDown;
    private Health health;
    private ItemAddDamageCoolDown item;
    private Fury fury;
    private EffectFury effectFury;
    private float damage;
    //private float cooldownTimer1 = Mathf.Infinity;
    private void Start()
    {
        //damage = (float)(playerParameter.damebasic * 0.3 + playerParameter.damebasic);
    }
    private void Awake()
    {
        playerParameter = GetComponent<PlayerParameter>();
        effectFury = GetComponent<EffectFury>();
        health = GetComponent<Health>();
        fury = GetComponent<Fury>();
        item = GetComponent<ItemAddDamageCoolDown>();
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Time.time - lastClickedTime > maxCombeDelay)
        {
            noOfClicks = 0;
        }
        if (Input.GetKeyDown(KeyCode.G) && cooldownTimer > attackCooldown && playerMovement.canAttack() && playerMovement.currentweapon == 1)
        {
            lastClickedTime = Time.time;
            noOfClicks = noOfClicks + 1;
            if (noOfClicks == 1)
            {
                anim.SetBool("attack_sword_1", true);
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
                texttimeitem.SetActive(false);
                checktime = false;
                effectivetimecurrent = 0;
                SubtractionDamage();

            }

        }
        damage = (float)(playerParameter.damebasic * 0.3 + playerParameter.damebasic);

        //cooldownTimer1 += Time.deltaTime;



    }
    public void returnsword1()
    {
        if (noOfClicks >= 2)
        {
            anim.SetBool("attack_sword_2", true);
        }
        else
        {
            anim.SetBool("attack_sword_1", false);
            noOfClicks = 0;

        }
    }
    public void returnsword2()
    {
        if (noOfClicks >= 3)
        {
            anim.SetBool("attack_sword_3", true);
        }
        else
        {
            anim.SetBool("attack_sword_1", false);
            anim.SetBool("attack_sword_2", false);
            noOfClicks = 0;

        }
    }
    public void returnsword3()
    {

        anim.SetBool("attack_sword_1", false);

        anim.SetBool("attack_sword_2", false);
        anim.SetBool("attack_sword_3", false);
        noOfClicks = 0;


    }

    /*private void Attack_Swort()
    {
        anim.SetTrigger("attackswort");
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

    private void DameEnemySwort(float _value)
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);

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
        damage = damage + value;
        checktime = true;
        texttimeitem.SetActive(true);
        //item.Check(checktime);
    }
    public void EffectRage(float _value,float _valueattackcooldown)
    {
 
        SubtractionEffectdame = _value;
        damage = damage + _value;
        SubtractionAttackCoolDown = _valueattackcooldown;
        attackCooldown = attackCooldown - _valueattackcooldown;
    }
    public void SubtractionDamage()
    {
        damage = damage - Subtractionvalue;
        attackCooldown = attackCooldown - SubtractionAttackCoolDown;
    }
    public void SubtractionEffectRage()
    {
        damage = damage - SubtractionEffectdame;
    }
}
