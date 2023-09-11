using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Attack : MonoBehaviour
{

    public float damage;
    public float knockback;
    public Weapon_Parent weaponParent;
    public CircleCollider2D hitBox;

    private void Update()
    {
        if (weaponParent.isAttacking)
        {
            hitBox.enabled = true;
        }
        else
        {
            hitBox.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player" && collision.tag != "Bullet")
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

        }
    }
}
