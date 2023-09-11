using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class Mushroom_Bomb : MonoBehaviour
{
    public float damage;
    public float degrees;
    public GameObject explosion;

    public void FixedUpdate()
    {
        transform.Rotate(0, 0, degrees);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {               if (collision.tag == "BombMarker") {
                    Vector2 pos = collision.transform.position;
                    Explosion(pos);
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
        if (collision.tag != "Bullet" && collision.tag != "PlayerBullet" && collision.tag != "Player")
        {
            if (collision.tag != "Enemy")
            {
                if (collision.tag != "Immune")
                {
                    Explosion(transform.position);
                    Destroy(gameObject);
                }
            }
        }
    }
    private void Explosion(Vector2 pos)
    { 
        GameObject spellObject = Instantiate(explosion, pos, Quaternion.identity);
    }

}
