using UnityEngine;

public class ProjectileHealth : MonoBehaviour
{
    //[SerializeField] private float speed;
    [SerializeField] private float health;
    //private float direction;
    //private bool hit;
    //private float lifetime;

    //private Animator anim;
    //private BoxCollider2D boxCollider;

    private void Awake()
    {
       
    }
    private void Update()
    {
        
    }
    

    public void DamageArrow(float value)
    {
        health = health + value;
    }

   
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}