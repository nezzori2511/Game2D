using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerParameter playerParameter;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
   
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;
    public int currentweapon ;
   
    public Transform keyFollowPoint;
    public Key followingKey;
    private float Subtractionspeed;
    public float effectivetimecurrent = Mathf.Infinity;
    public bool checktime = false;
    public float effectivetime;
    public Speed speedadd;
    private float SubtractionEffectspeed;
    public static float efftimeitem;
    [SerializeField] private GameObject item;
    private void Awake()
    {
        playerParameter = GetComponent<PlayerParameter>();
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void ChangeWeapon()
    {
        if (currentweapon == 0)
        {
            currentweapon = 1;
            anim.SetLayerWeight(0, 0);
            anim.SetLayerWeight(1, 1);

        }
        else if (currentweapon == 1)
        {
            currentweapon = 2;
            anim.SetLayerWeight(1, 0);
            anim.SetLayerWeight(2, 1);
           /* currentweapon -= 1;
            anim.SetLayerWeight(currentweapon + 1, 0);
            anim.SetLayerWeight(currentweapon, 1);*/
        }
        else if (currentweapon == 2)
        {
            currentweapon = 0;
            anim.SetLayerWeight(2, 0);
            anim.SetLayerWeight(0, 1);
           /* currentweapon -= 2;
            anim.SetLayerWeight(currentweapon + 2, 0);
            anim.SetLayerWeight(currentweapon, 1);*/
        }
        /*switch (currentweapon)
        {
            case 0: // đang ở player 0, chuyển sang player 1
                currentweapon = 1;
                anim.SetLayerWeight(0, 0);
                //anim.SetLayerWeight(2, 0);
                anim.SetLayerWeight(1, 1);
                break;
            case 1: // đang ở player 1, chuyển sang player 2
                currentweapon = 2;
                anim.SetLayerWeight(1, 0);
                //anim.SetLayerWeight(0, 0);
                anim.SetLayerWeight(2, 1);
                break;
            case 2: // đang ở player 2, quay lại player 0
                currentweapon = 0;
                //anim.SetLayerWeight(1, 0);
                anim.SetLayerWeight(2, 0);
                anim.SetLayerWeight(0, 1);
                break;
            default:
                break;
        }*/
    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Flip player when moving left-right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        //Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        //Wall jump logic
        if (wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput *playerParameter.speedbasic, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 7;

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCooldown += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.C))
        {
           
            ChangeWeapon();
        }
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
                SustractionSpeed();

            }

        }

    }

    public void AddSpeed(float _value, float _effecttime)
    {
        
        playerParameter.speedbasic = playerParameter.speedbasic + _value;
        Subtractionspeed = _value;
        effectivetimecurrent = 0;
        effectivetime = _effecttime;
        efftimeitem = _effecttime;
        item.SetActive(true);
        checktime = true;
    }
    public void SustractionSpeed()
    {
        playerParameter.speedbasic = playerParameter.speedbasic - Subtractionspeed;
    }
    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCooldown = 0;
        }
    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }
    public void EffectRage(float _value)
    {

        SubtractionEffectspeed = _value;
        playerParameter.speedbasic = playerParameter.speedbasic + _value;
        
    }
    public void SubtractionEffectRage()
    {
        playerParameter.speedbasic = playerParameter.speedbasic - SubtractionEffectspeed;
        
    }
}