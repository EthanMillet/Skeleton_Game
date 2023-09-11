using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Weapon_Parent : MonoBehaviour
{
    public SpriteRenderer playerrenderer, weaponRenderer;
    public GameObject player;

    public void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        transform.right = player.transform.position - transform.position;

        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;


        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponRenderer.sortingOrder = playerrenderer.sortingOrder - 1;
        }
        else
        {
            weaponRenderer.sortingOrder = playerrenderer.sortingOrder + 1;
        }

    }
}
