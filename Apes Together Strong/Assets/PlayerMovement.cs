using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public int sprint = 1;
    public bool sprinting = false;
    public float stamina = 300;
    public float maxStamina = 300;

    Vector2 movement;

    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

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
            else if (stamina > 0)
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
