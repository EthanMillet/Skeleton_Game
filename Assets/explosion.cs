using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float damage;

    public void Start()
    {
        StartCoroutine(ending());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            PlayerStat.playerStats.DealDamage(damage);
        }
    }

    IEnumerator ending()
    {
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }
}
