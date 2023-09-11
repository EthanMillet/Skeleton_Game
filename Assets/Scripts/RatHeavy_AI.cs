using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RatHeavy_AI : MonoBehaviour
{

    private GameObject player;
    public GameObject weapon_Parent;
    public GameObject shield;
    public GameObject weapon;
    public float speed;
    public float distanceToStop;
    public Animator animator;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = (player.transform.position - transform.position).normalized;
        // Physics Calcs

        animator.SetFloat("lastMoveX", direction.x);
        animator.SetFloat("lastMoveY", direction.y);
        direction.Normalize();
        if (distance > distanceToStop)
        {
            Vector2 moveDirection = player.transform.position - transform.position;
            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);
            animator.SetFloat("Speed", moveDirection.sqrMagnitude);
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public void Parried()
    {
        weapon.GetComponent<CircleCollider2D>().enabled = false;
        animator.SetBool("Parried", true);
    }

    private void resetParried()
    {
        animator.SetBool("Parried", true);
    }




    private void ExecuteAttackRightHand()
    {
        weapon.GetComponent<HeavyRat_Weapon>().ShortSlash();
        StartCoroutine(HandAttackDelayRight());
    }


    public void startFight()
    {
        ExecuteAttackRightHand();
    }

    private IEnumerator HandAttackDelayRight()
    {
        yield return new WaitForSeconds(5f);
        ExecuteAttackRightHand();
    }
}
