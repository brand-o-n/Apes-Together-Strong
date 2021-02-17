using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public int sprint = 1;
    public bool sprinting = false;
    public float stamina = 20;
    public float maxStamina = 25;

    public Animator animator;

    Vector2 movement;

    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //Sprint and Stamina
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprinting = false;
        }

        if (sprinting)
        {
            stamina -= Time.fixedDeltaTime;
            if (stamina < 0)
            {
                stamina = 0;
                sprint = 1;
            }
            else if (stamina > 10)
            {
                sprint = 3;
            }
        }
        else
        {
            sprint = 1;
            stamina += Time.fixedDeltaTime;
            if(stamina > maxStamina)
            {
                stamina = maxStamina;
            }
        }
    }

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * sprint * moveSpeed * Time.fixedDeltaTime);
    }
}
