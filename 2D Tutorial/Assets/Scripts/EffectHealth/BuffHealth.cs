using UnityEngine;

public class BuffHealth : MonoBehaviour
{
    [Header("Attack parameters")]
    [SerializeField] private float attackCooldown;

    //[SerializeField] private float range;
    [SerializeField] private float health;
    private Mana mana;
    /*[Header("Collider parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;*/

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    private PlayerParameter parameter;

    private Animator anim;
    //private Health playerHealth;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        parameter = GetComponent<PlayerParameter>();
        mana = GetComponent<Mana>();
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q) && cooldownTimer > attackCooldown && playerMovement.canAttack()&&parameter.healtheffect==true )
            Attack_Swort();

        cooldownTimer += Time.deltaTime;

    }

    private void Attack_Swort()
    {
        anim.SetTrigger("effecthealth");
        //playerHealth.AddHealth(health);
        //mana.TakeManaHealth(3);
        cooldownTimer = 0;
        
    }

   /* private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }*/
   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }*/

   /* private void DameEnemy()
    {
        *//*if (PlayerInSight())
        {*//*
            // dame player
            playerHealth.TakeDamage(damage);
        //}
    }
*/
   /* public void AddDamage(float value)
    {
        damage = damage + value;
    }*/
}
