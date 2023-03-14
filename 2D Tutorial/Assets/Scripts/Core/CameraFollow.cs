using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    public float minX, maxX;
    public float minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x;
            transform.position = temp;

            if (temp.x < minX)
            {
                temp.x = minX;
            }
            if (temp.x > maxX)
            {
                temp.x = maxX;
            }
            transform.position = temp;
        }

        if (player != null)
        {
            Vector3 temp = transform.position;
            temp.y = player.position.y;
            transform.position = temp;

            if (temp.y < minY)
            {
                temp.y = minY;
            }
            if (temp.y > maxY)
            {
                temp.y = maxY;
            }
            transform.position = temp;
        }
    }
}
