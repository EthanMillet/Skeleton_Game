using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TestSpell : MonoBehaviour
{

    public GameObject spell;
    public float minDamage;
    public float maxDamage;
    public float spellForce;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            GameObject spellObject = Instantiate(spell, transform.position, Quaternion.identity);
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPosition = transform.position;
            Vector2 direction = (mousePosition - myPosition).normalized;
            spellObject.GetComponent<Rigidbody2D>().velocity = direction * spellForce;
            spellObject.GetComponent<Test_Projectile>().damage = Random.Range(minDamage, maxDamage); 
        }
    }
}
