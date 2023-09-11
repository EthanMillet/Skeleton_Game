using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Parent : MonoBehaviour
{
    public SpriteRenderer playerrenderer, shieldRenderer;
    public Vector2 PointerPosition { get; set; }

    public Animator animator;

    public float delay;
    private bool parryBlocked;

    public bool isParrying { get; private set; }
    public bool perfectTiming;

    public void ResetisParrying()
    {
        isParrying = false;
    }

    private void Update()
    {
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = (PointerPosition - (Vector2)transform.position).normalized;

        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;


    }

    public void Parry()
    {
        if (parryBlocked)
            return;
        transform.right = (PointerPosition - (Vector2)transform.position).normalized * -1;
        animator.SetTrigger("Parry");
        isParrying = true;
        parryBlocked = true;
        StartCoroutine(DelayParry());
    }

    private IEnumerator DelayParry()
    {
        yield return new WaitForSeconds(delay);
        parryBlocked = false;
    }

}
