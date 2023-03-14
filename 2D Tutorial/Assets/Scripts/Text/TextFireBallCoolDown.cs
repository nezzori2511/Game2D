using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextFireBallCoolDown : MonoBehaviour
{
    [SerializeField] private Mana playerMana;
    [SerializeField]
    private Image imageCooldown;
    [SerializeField]
    private TMP_Text textCooldown;
    /* [SerializeField]
     private Image imageEdge;*/
    // Start is called before the first frame update
    
    private bool isCooldown = false;
    private float cooldownTime = 1.0f;
    private float cooldownTimer = 0.0f;
    private Mana mana;
    private PlayerMovement playerMovement;
    private bool chage;
    private void Awake()
    {
        playerMovement=GetComponent<PlayerMovement>();
        mana = GetComponent<Mana>();
    }
    void Start()
    {

        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
        //imageEdge.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.E))
        {*/
        /*if(FireBallAttack.triggerskill==true)
        {
            playerMana.checkFireBall();
            if (Mana.checkmanafireball == true)
            {*/
                
        /*    }
        }*/
        /*if(chage == true)
        {
            UseSpell();
        }*/
            
           
           
        //}
        if (isCooldown)
        {
            ApplyCooldown();
        }
    }
    
    void ApplyCooldown()
    {

        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer < 0.0f)
        {
            changee(true);
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            //imageEdge.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            changee(false);
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;
            //imageEdge.transform.localEulerAngles = new Vector3(0, 0, 360.0f * (cooldownTimer / cooldownTime));
        }
    }
    public void changee(bool check)
    {
        if(check==true)
        {
            UseSpell();
            chage = true;
        }
        else
        {
            chage = false;
        }
    }
    public  void UseSpell()
    {
    /*if(playerMana.currentMana>=2)
    {*/
        
            if (isCooldown)
                {
                    //return false;

                }
                else
                {
                    //imageEdge.gameObject.SetActive(true);
                    isCooldown = true;
                    textCooldown.gameObject.SetActive(true);
                    cooldownTimer = cooldownTime;
                    //return true;
                }

        

    }
}
