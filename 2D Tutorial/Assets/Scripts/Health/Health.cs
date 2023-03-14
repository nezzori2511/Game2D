using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    private Mana mana;
    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberofFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    public bool invulnerable;
    private float armor;
    private Exp exp;
    private void Start()
    {
        
        //armor = exp.currentExp;
        //armor = (float)(PlayerParameter.damebasictext*0.4);
        invulnerable = false;
    }

    private void Awake()
    {
        mana = GetComponent<Mana>();
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

    }

    public void TakeDamage(float _damage )
    {
        if (invulnerable) return;
     
        
        
       
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if(currentHealth > 0)
        {
            // player hurt
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());

        }
        else
        {
            
            // player dead
            if (!dead)
            {
              
                foreach (Behaviour component in components)
                    component.enabled = false;

                anim.SetBool("grounded", true);
                anim.SetTrigger("die");

                dead = true;
                Exp.AddExp(5);
                Invoke("alive", 10);
                
            }
            
        }
    }


    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }   // item hp
    public void AddHealthSkill(float _value)
    {
        if(mana.checkManaHealth()==true)
        {
            mana.TakeManaHealth(2);
            currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
           
        }
       
    }

    public void Respawn()   /// check point
    {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("Idle");
        StartCoroutine(Invunerability());

        foreach (Behaviour component in components)
            component.enabled = true;

    }   // checkpoint

    private IEnumerator Invunerability()    // chuyen mau khi dinh dame
    {
        invulnerable = true;
        // main do khi bi damage
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for(int i = 0; i < numberofFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberofFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    void alive()
    {
        currentHealth = Mathf.Clamp(currentHealth + 100, 0, startingHealth);
        gameObject.SetActive(true);
        dead = false;
    }    
    
}
