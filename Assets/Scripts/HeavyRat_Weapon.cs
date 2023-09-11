using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HeavyRat_Weapon : MonoBehaviour
{

    public GameObject spell;
    public GameObject player;
    public GameObject AI;
    public float minDamage;
    public float maxDamage;
    public float spellForce;
    public float cooldown;

    public Animator animator;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void ShortSlash()
    {

        if (player != null)   
        {
            animator.SetBool("ShortSlash", true);
            StartCoroutine(ShortSlashReset());

        }
    }

    public void shooting()
    {
        GameObject spellObject = Instantiate(spell, transform.position, Quaternion.identity);
        spellObject.transform.right = player.transform.position - transform.position;
        Vector2 myPos = transform.position;
        Vector2 targetPos = player.transform.position;
        Vector2 direction = (targetPos - myPos).normalized;
        spellObject.GetComponent<Rigidbody2D>().velocity = direction * spellForce;
        spellObject.GetComponent<testEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
    }
    IEnumerator ShortSlashReset()
    {
        yield return new WaitForSeconds(0.750f);
        animator.SetBool("ShortSlash", false);
    }

}
