using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] public float effectivetime;
    
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().AddSpeed(speed, effectivetime);
            gameObject.SetActive(false);
           

        }
    }
}
