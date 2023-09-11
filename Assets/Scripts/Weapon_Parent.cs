using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Parent : MonoBehaviour
{
    public SpriteRenderer playerrenderer, weaponRenderer;
    public Vector2 PointerPosition { get; set; }

    public Animator animator;

    public float delay;
    private bool attackBlocked;

    public bool isAttacking { get; private set; }

    public void ResetIsAttacking()
    {
        isAttacking = false;
    }

    private void Update()
    {
        if (isAttacking)
            return;
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = (PointerPosition - (Vector2)transform.position).normalized;

        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        } else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;


        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponRenderer.sortingOrder = playerrenderer.sortingOrder - 1;
        } else
        {
            weaponRenderer.sortingOrder = playerrenderer.sortingOrder + 1;
        }

    }


        public void Attack()
        {
        if (attackBlocked)
            return;

        animator.SetTrigger("Attack");
        isAttacking = true;
        attackBlocked = true;
        StartCoroutine(DelayAttack());
        }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
}
