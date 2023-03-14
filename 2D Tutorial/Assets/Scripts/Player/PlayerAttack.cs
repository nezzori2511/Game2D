using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private GameObject item;
    private Mana mana;
    private Arrow arrow;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    public float effectivetimecurrent = Mathf.Infinity;
    public bool checktime = false;
    public static float effectivetime = 5.0f;
    
    private float Subtractionvalue;
    public PlayerParameter playerParameter;
    private Projectile projectile;
   
    public static float damage;
    private void Start()
    {
        damage = (float)(playerParameter.damebasic * 0.8);
        //projectile.Start(damage);
    }
    private void Awake()
    {
        playerParameter = GetComponent<PlayerParameter>();
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        arrow = GetComponent<Arrow>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.G) && cooldownTimer > attackCooldown && playerMovement.canAttack()&& playerMovement.currentweapon == 2)
            Attack();

        cooldownTimer += Time.deltaTime;
        if (checktime == true)
        {
            //item.checkitem = true;
            //item.Check(checktime);
            effectivetimecurrent += Time.deltaTime;
            if (effectivetimecurrent > effectivetime)
            {
                item.SetActive(false);
                checktime = false;
                effectivetimecurrent = 0;
                SubtractionCoolDown();

            }

        }
    }

    public void Cooldown(float value)
    {
        checktime = true;
        effectivetimecurrent = 0;
        Subtractionvalue = value;
        attackCooldown = attackCooldown - value;
        item.SetActive(true);
    }

    private void Attack()
    {
        if(arrow.checkArrow()==true)
        {
            anim.SetTrigger("attack");
            cooldownTimer = 0;

            fireballs[FindFireball()].transform.position = firePoint.position;
            fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
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
    public void SubtractionCoolDown()
    {

        attackCooldown = attackCooldown + Subtractionvalue;
    }
}