using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMana : MonoBehaviour
{
    [SerializeField] private int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Mana>().FullMana(value);
            gameObject.SetActive(false);
        }
    }
}
