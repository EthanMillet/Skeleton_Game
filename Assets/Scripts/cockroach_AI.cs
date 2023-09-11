using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class cockroach_AI : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public float jumpSpeed;
    public float distanceToStop;
    public Animator animator;
    public float damage;
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

        if (distance <= distanceToStop)
        {
            Vector2 moveDirection = player.transform.position - transform.position;
            animator.SetFloat("Jumping", moveDirection.sqrMagnitude);
            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);
            animator.SetFloat("Speed", moveDirection.sqrMagnitude);
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, jumpSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            return;
        }
        if (collision.tag == "Player")
        {
            PlayerStat.playerStats.DealDamage(damage);

            StartCoroutine(Freeze());
        }

    }

    IEnumerator Freeze()
    {
        Debug.Log("Test");
        float OGSpeed = speed;
        float OGJumpSpeed = jumpSpeed;
        speed = 0;
        jumpSpeed = 0;
        yield return new WaitForSeconds(1.5f);
        speed = OGSpeed;
        jumpSpeed = OGJumpSpeed;

    }
}
