using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFury : MonoBehaviour
{
    [Header("Attack parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float dame;
  
    [SerializeField] private float speedattack;
    [SerializeField] private float speedadd;
    [SerializeField] public  float effectivetime;
    public static float effectivetimeclone;
    public float effectivetimecurrent = Mathf.Infinity;
    private PlayerAttackSwort playerAttackSwort;
    private PlayerAttackHand playerAttackHand;
    private Fury fury;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    public bool effectrage=false;
    [SerializeField] private GameObject imagecooldown;
    [SerializeField] private GameObject imagecooldownspeed;
    [SerializeField] private GameObject imagecooldownbloodsuck;
    /*  public static bool imagecooldown;
      public static bool imagecooldownspeed;
      public static bool imagecooldownbloodsuck;*/
    // Start is called before the first frame update
    private SpriteRenderer spriteRend;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberofFlashes;
    private void Awake()
    {
        playerAttackHand = GetComponent<PlayerAttackHand>();
        spriteRend = GetComponent<SpriteRenderer>();
        playerAttackSwort = GetComponent<PlayerAttackSwort>();
        playerMovement = GetComponent<PlayerMovement>();
        fury = GetComponent<Fury>();
    }
    void Start()
    {
        effectivetimeclone = effectivetime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Furystate();
        if (effectrage == true)
        {
            effectivetimecurrent += Time.deltaTime;
            if (effectivetimecurrent > effectivetime)
            {

                spriteRend.color = Color.white;
                //Physics2D.IgnoreLayerCollision(10, 11, false);
                effectivetimecurrent = 0;
                imagecooldown.SetActive(false);
                imagecooldownspeed.SetActive(false);
                imagecooldownbloodsuck.SetActive(false);
                /* imagecooldown = true;
                 imagecooldownbloodsuck = true;
                 imagecooldownspeed = true;*/
                effectrage = false;
                playerAttackSwort.SubtractionEffectRage();
                playerAttackHand.SubtractionEffectRage();
                playerMovement.SubtractionEffectRage();
            }
            //Countdown();
        }
        cooldownTimer += Time.deltaTime;
 
    }       
    private void  Furystate()
    {
        if (fury.checkFury() == true)
        {
            fury.TakeFury();
            effectrage = true;
            effectivetimecurrent = 0;
            //timeLeft = 5.0f;
            //mana.TakeMana(2);
            playerAttackSwort.EffectRage(dame, speedattack);
            playerAttackHand.EffectRage(dame/2, speedattack);
            playerMovement.EffectRage(speedadd);
            cooldownTimer = 0;
            //Physics2D.IgnoreLayerCollision(10, 11, true);
            imagecooldown.SetActive(true);
            imagecooldownspeed.SetActive(true);
            imagecooldownbloodsuck.SetActive(true);
            /* imagecooldown = false;
             imagecooldownbloodsuck = false;
             imagecooldownspeed = false;*/
            spriteRend.color = new Color(255, 255, 0, 221);
        }
       

    }
}
