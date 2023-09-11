using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Projectile : MonoBehaviour
{
    public float damage;
    public float degrees;
    public float knockback;

    public void FixedUpdate()
    {
        transform.Rotate(0, 0, degrees);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name != "Player" && collision.tag != "Bullet")
        {
            if(collision.GetComponent<EnemyRecieveDamage>() != null)
            {
                collision.GetComponent<EnemyRecieveDamage>().DealDamage(damage, knockback);
            }
            Destroy(gameObject);
        }
    }
}
