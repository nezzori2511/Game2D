using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpellCoolDown : MonoBehaviour
{
    
    [SerializeField]
    private Image imageCooldown;
    [SerializeField]
    private TMP_Text textCooldown;
    /* [SerializeField]
     private Image imageEdge;*/
    // Start is called before the first frame update
    private Health health;
    private bool isCooldown = false;
    private float cooldownTime = 5.0f ;
    private float cooldownTimer = 0.0f;
    private Mana mana;
    private void Awake()
    {
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
        if(Input.GetKey(KeyCode.X))
        {
            UseSpell();
        }
        if(isCooldown)
        {
            ApplyCooldown();
        }
    }
    void ApplyCooldown()
    {   

        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer <0.0f)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            //imageEdge.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;
            //imageEdge.transform.localEulerAngles = new Vector3(0, 0, 360.0f * (cooldownTimer / cooldownTime));
        }
    }
    public void UseSpell()
    {
        //if(mana.checkMana()==true)
        //{
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
        //}
    }
}
