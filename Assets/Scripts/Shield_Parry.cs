using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Shield_Parry : MonoBehaviour
{
    public Shield_Parent shieldParent;
    public BoxCollider2D hitBox;
    public GameObject ReturningShot;
    public GameObject player;
    

    public float minDamage;
    public float maxDamage;
    public float spellForce;

    private Vector3 sender;
    public bool perfectTiming;

    private void PerfectTiming()
    {
        perfectTiming = true;
    }
    private void DisablePerfectTiming()
    {
        perfectTiming = false;
    }

    private void Update()
    {
        if (shieldParent.isParrying)
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
        if (collision.tag == "Bullet")
        {
            if (perfectTiming)
            {
                Debug.Log(collision.gameObject.name);
                Debug.Log("Perfect");

                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 myPosition = transform.position;
                Vector2 direction = (mousePosition - myPosition).normalized;

                GameObject shot = Instantiate(ReturningShot, transform.position, Quaternion.identity);


                Debug.Log(sender);
                shot.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                shot.transform.localScale = new Vector3(8, 8, 1);
                shot.SetActive(true);
                shot.transform.right = direction;


                shot.GetComponent<Rigidbody2D>().velocity = direction * spellForce;
                shot.GetComponent<Return_Projectile>().damage = Random.Range(minDamage, maxDamage);
                DisablePerfectTiming();


            } else
            {
            Debug.Log(collision.gameObject.name);

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPosition = transform.position;
            Vector2 direction = (mousePosition - myPosition).normalized;

            GameObject shot = Instantiate(ReturningShot, transform.position, Quaternion.identity);


            Debug.Log(sender);
            shot.transform.localScale = new Vector3(6, 6, 1);
            shot.SetActive(true);
            shot.transform.right = direction;


            shot.GetComponent<Rigidbody2D>().velocity = direction * spellForce;
            shot.GetComponent<Return_Projectile>().damage = Random.Range(minDamage, maxDamage);
            }


        } else
        {
            return;
        }
    }
}
