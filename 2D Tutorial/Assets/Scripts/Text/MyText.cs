using UnityEngine;
using UnityEngine.UI;

public class MyText : MonoBehaviour
{
    public Arrow arrow;
    public Text textObject;
    public Text textarmor;
    public Text textdame;
    public Text textspeed;
    public Text Level;
    public  PlayerParameter playerParameter;
    //public int newText;

    private void Awake()
    {
        playerParameter = GetComponent<PlayerParameter>();
    }
    void Start()
    {
        
         //= newText;
        textObject.text = "X "+ arrow.currentArrow.ToString();
        textarmor.text = PlayerParameter.armorbasictext.ToString();
        textdame.text = PlayerParameter.damebasictext.ToString();
        textspeed.text = PlayerParameter.speedbasictext.ToString();
        Level.text = PlayerParameter.leveltext.ToString();
    }
    void Update()
    {
        
        //arrow.currentArrow = newText;
        textObject.text = "X " + arrow.currentArrow.ToString();
        textarmor.text = PlayerParameter.armorbasictext.ToString();
        textdame.text = PlayerParameter.damebasictext.ToString();
        textspeed.text = PlayerParameter.speedbasictext.ToString();
        Level.text = "LV " + PlayerParameter.leveltext.ToString();
    }
}