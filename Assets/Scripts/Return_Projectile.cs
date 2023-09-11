using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return_Projectile : MonoBehaviour
{
    public float knockback;
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player" && collision.tag != "Bullet" && collision.tag != "PlayerWeapon" && collision.tag != "PlayerShield" && collision.tag != "PlayerBullet")
        {
            if (collision.tag != "Immune")
            {
                if (collision.GetComponent<EnemyRecieveDamage>() != null)
                {
                    collision.GetComponent<EnemyRecieveDamage>().DealDamage(damage, knockback);
                }
                if (collision.GetComponent<RatKingLeftHand>() != null)
                {
                    collision.GetComponent<RatKingLeftHand>().DealDamage(damage, knockback);
                }
                if (collision.GetComponent<RatKingRightHand>() != null)
                {
                    collision.GetComponent<RatKingRightHand>().DealDamage(damage, knockback);
                }
            }
            Destroy(gameObject);
        }
    }
}
