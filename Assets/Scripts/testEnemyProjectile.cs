using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEnemyProjectile : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.tag != "Bullet" && collision.tag != "PlayerBullet")
        {
            if (collision.tag != "Enemy")
            {
                if (collision.tag != "Immune")
                {
                if(collision.tag == "Player")
                {
                    PlayerStat.playerStats.DealDamage(damage);
                }
                Destroy(gameObject);   
                }
            }
        }
    }
}
