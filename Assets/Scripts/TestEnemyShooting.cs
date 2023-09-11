using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TestEnemyShooting : MonoBehaviour
{

    public GameObject spell;
    public GameObject player;
    public float minDamage;
    public float maxDamage;
    public float spellForce;
    public float cooldown;

    void Start()
    {
        StartCoroutine(ShootPlayer());
        player = GameObject.Find("Player");
    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(cooldown);
        if(player != null ) 
        {        
            GameObject spellObject = Instantiate(spell, transform.position, Quaternion.identity);
            spellObject.transform.right = player.transform.position - transform.position;
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.transform.position;
            Vector2 direction = (targetPos - myPos).normalized;
            spellObject.GetComponent<Rigidbody2D>().velocity = direction * spellForce;
            spellObject.GetComponent<testEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
            StartCoroutine(ShootPlayer());
        }

    }
}
