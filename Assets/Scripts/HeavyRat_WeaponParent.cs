using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyRat_WeaponParent : MonoBehaviour
{
    public SpriteRenderer playerrenderer, weaponRenderer;
    public Vector2 PointerPosition { get; set; }
    public GameObject player;

    public void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        transform.right = -((Vector2)player.transform.position - (Vector2)transform.position).normalized;

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
            weaponRenderer.sortingOrder = playerrenderer.sortingOrder + 1;
        }
        else
        {
            weaponRenderer.sortingOrder = playerrenderer.sortingOrder - 1;
        }

    }
}
