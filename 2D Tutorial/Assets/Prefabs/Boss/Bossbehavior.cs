using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Bossbehavior : MonoBehaviour
{
    public Transform[] transforms;
    private float timetotp, countdowntp;
    private float timer;
    public GameObject player;
    public float speed;
    private Animation anm;

    private float distance;



    private void Start()
    {
        var initialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[initialPosition].position;
        countdowntp = timetotp;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        //countdowntp -= Time.deltaTime;
        timer += Time.deltaTime;
        if (timer>2)
        {
            countdowntp = timetotp;
            timer = 0;
            tele();
        }
        Flip();

        
    }
    public void tele()
    {
        var initialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[initialPosition].position;
    }
    public void move()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);



    }
    private void Flip()
    {
        if (transform.position.x < player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }
   
}

