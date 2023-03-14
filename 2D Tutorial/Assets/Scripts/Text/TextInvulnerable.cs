using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInvulnerable : MonoBehaviour
{
    private Health health;
     
    private float currentTime = 0f;
    private float starting = 5f;
    [SerializeField] Text countdownText;
    public PlayerMovement playerMovement;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        health = GetComponent<Health>();

    }
    private void Start()
    {

        currentTime = starting;
    }
    private void Update()
    {


        
        
        
        
    }
    public void time()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString();
        if (currentTime <= 0)
        {

            currentTime = 0;
        }
    }
}







