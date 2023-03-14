using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bossPanel;
    public GameObject boss;
    public GameObject Bullet;
    public static BossUI instance;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bossPanel.SetActive(true);
        boss.SetActive(true);
        Bullet.SetActive(true);
    }
    public void BossActivator()
    {
        bossPanel.SetActive(true);
        boss.SetActive(true);
        Bullet.SetActive(true);
    }
    void Start()
    {
        
    }

}
