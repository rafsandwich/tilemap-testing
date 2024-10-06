using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Attributes)")]
    [SerializeField] float moveSpeed = 50f;

    [Header("Dependencies")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;


    private Vector2 moveDir = Vector2.zero; //where player wishes to move based on input
    private Directions facingDirection = Directions.RIGHT;

    private enum Directions { UP, DOWN, LEFT, RIGHT };



    private void Update()
    {
        GetPlayerInput();
        CalcFacingDirection();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        MovementUpdate();   
    }

    private void GetPlayerInput()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        Debug.Log(moveDir);
    }

    private void MovementUpdate()
    { 
        rb.velocity = moveDir.normalized * moveSpeed * Time.fixedDeltaTime; // normalized fixes speed difference when moving diagonally
    }

    private void CalcFacingDirection()
    {
        if (moveDir.x != 0)
        {
            if (moveDir.x > 0) // moving right
            {
                facingDirection = Directions.RIGHT;
            }
            else if (moveDir.x < 0) // moving left
            {
                facingDirection = Directions.LEFT;
            }
        }

        //Debug.Log(facingDirection);
    }

    private void UpdateAnimation()
    {
        if (facingDirection == Directions.LEFT)
        {
            spriteRenderer.flipX = true;
        }
        else if (facingDirection == Directions.RIGHT)
        {
            spriteRenderer.flipX = false;
        }
    }
}
