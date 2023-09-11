using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightStarting : MonoBehaviour
{

    public GameObject AI;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AI.GetComponent<RatHeavy_AI>().startFight();
            Destroy(gameObject);
        }
    }
}
