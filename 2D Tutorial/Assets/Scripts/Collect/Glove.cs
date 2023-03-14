using UnityEngine;

public class Glove : MonoBehaviour
{
    [SerializeField] private float cooldown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerAttack>().Cooldown(cooldown);
            gameObject.SetActive(false);
        }
    }
}
