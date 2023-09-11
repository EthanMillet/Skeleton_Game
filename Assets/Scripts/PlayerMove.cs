using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 5;
    public Rigidbody2D rb;
    public Animator animator;

    public float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength, dashCooldown;

    private float dashCounter;
    private float dashCoolCounter;
    public float attackingMoveSpeed;

    private bool isDashing;

    private Vector2 moveDirection;
    private Vector2 pointerInput;

    private Weapon_Parent weaponParent;
    private Shield_Parent shieldParent;

    [SerializeField]
    private InputActionReference movement, attack, pointerPosition, dodgeRoll, parry;

    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
        parry.action.performed += PerformParry;
        dodgeRoll.action.performed += Dodge;
    }

    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
        parry.action.performed -= PerformParry;
        dodgeRoll.action.performed -= Dodge;
    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {
        if (isDashing == false)
        {
            weaponParent.Attack();
        }
            
    }


    private void PerformParry(InputAction.CallbackContext obj)
    {
        if (isDashing == false)
        {
            shieldParent.Parry();
        }
    }

    private void Dodge(InputAction.CallbackContext obj)
    {
        dodgeAction();
    }

    private IEnumerator lowerDodge(Vector2 dashVector)
    {
        yield return new WaitForSeconds(.5f);
        rb.velocity = new Vector2(0, 0);
        rb.velocity = new Vector2(dashVector.x, dashVector.y) * dashSpeed / 4;
    }

    private void dodgeAction()
    {
              if (dashCoolCounter <= 0 && dashCounter <= 0 && moveDirection != Vector2.zero)
            {
                tag = "Immune";
                Vector2 dashVector = moveDirection.normalized;
                animator.SetFloat("rollX", dashVector.x);
                animator.SetFloat("rollY", dashVector.y);
                rb.velocity = new Vector2(dashVector.x, dashVector.y) * dashSpeed;
                StartCoroutine(lowerDodge(dashVector));
                dashCounter = dashLength;
                PlayerStat.playerStats.DashChecker(0);
                isDashing = true;
                animator.SetBool("rolling", true);
            }
    }

    private void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    private void Awake()
    {
     weaponParent = GetComponentInChildren<Weapon_Parent>();
     shieldParent = GetComponentInChildren<Shield_Parent>();
    }

    void Update()
    {
        // Processing Inputs
            ProcessInputs();


        pointerInput = GetPointerInput();
        weaponParent.PointerPosition = pointerInput;
        shieldParent.PointerPosition = pointerInput;

        if (weaponParent.isAttacking)
        {
            activeMoveSpeed = attackingMoveSpeed;
        } else
        {
            activeMoveSpeed = moveSpeed;
        }


        if (shieldParent.isParrying)
        {
            activeMoveSpeed = attackingMoveSpeed;
        }
        else
        {
            activeMoveSpeed = moveSpeed;
        }

        if (dashCounter > 0)
            {
                dashCounter -= Time.deltaTime;
                if (dashCounter <= 0)
                {
                    dashCoolCounter = dashCooldown;
                    isDashing = false;
                    animator.SetBool("rolling", false);
                    tag = "Player";
            }
            }
            if (dashCounter <= 0)
            {
                dashCoolCounter -= Time.deltaTime;
            }
            if (dashCoolCounter <= 0 && dashCounter <= 0) 
            {
            PlayerStat.playerStats.DashChecker(1);
            }
    }
    
    void FixedUpdate()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPosition = transform.position;
        Vector2 direction = (mousePosition - myPosition).normalized;
        // Physics Calcs
        if (isDashing == false)
        {
            Move();
        
        }
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
        animator.SetFloat("lastMoveX", direction.x);
        animator.SetFloat("lastMoveY", direction.y);
       
    }

    void ProcessInputs()
    {
        moveDirection = movement.action.ReadValue<Vector2>();
    }


    void Move()
    {
        rb.MovePosition(rb.position + moveDirection * activeMoveSpeed * Time.deltaTime);

    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}