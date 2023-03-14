using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikehead : EnemyDamage
{
    [Header("SpikeHead Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3 destination;
    private float checkTimer;
    private bool attacking;
    private Vector3[] directions = new Vector3[4];
    private int count = 0;
    private void OnEnable()
    {
        Stop();
    }
    private void Update()
    {
        
        if(attacking )
        {
            count++;
            //di chuyển trap đến điểm tấn công
            transform.Translate(destination * Time.deltaTime * speed);
            
        }
        else
        {
            checkTimer += Time.deltaTime;
            if(checkTimer >checkDelay)
            {
                CheckForPlayer();
            }
        }
        
    }
    private void CheckForPlayer()
    {
        CalculateDirections();

        //Kiểm tra hướng của main 
        for(int i=0;i<directions.Length;i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);
            if(hit.collider!=null &&!attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }
    private void CalculateDirections()
    {
        directions[0] = transform.right * range;//phải
        directions[1] = -transform.right * range;//trái
        directions[2] = transform.up * range;//lên
        directions[3] = -transform.up * range;//xuống
    }
    private void dead()
    {
      
         gameObject.SetActive(false);
        
      
    }
    private void Stop()
    {
        destination = transform.position;//đặt đích đến là vị trí hiện tại
        attacking = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        //dừng spikehead lại khi va vào cái gì đó
        

    }
}
