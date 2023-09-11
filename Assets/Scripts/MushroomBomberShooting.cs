using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MushroomBomberShooting : MonoBehaviour
{
    public GameObject spell;
    public GameObject bombMarker;
    public GameObject player;
    public float minDamage;
    public float maxDamage;
    public float spellForce;
    public float cooldown;
    public float z;

    private Vector2 target;
    private GameObject bomb;
    void Start()
    {
        StartCoroutine(ShootPlayer());
        player = GameObject.Find("Player");
    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(cooldown);
        if (player != null)
        {
            GameObject spellObject = Instantiate(spell, transform.position, Quaternion.identity);
            GameObject marker = Instantiate(bombMarker, player.transform.position, Quaternion.identity);
            spellObject.transform.right = player.transform.position - transform.position;
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.transform.position;
            target = targetPos;
            bomb = spellObject;
            Vector2 direction = (targetPos - myPos).normalized;
            spellObject.GetComponent<Rigidbody2D>().velocity = direction * spellForce;
            spellObject.GetComponent<Mushroom_Bomb>().damage = Random.Range(minDamage, maxDamage);
            StartCoroutine(ShootPlayer());
        }

    }
}
