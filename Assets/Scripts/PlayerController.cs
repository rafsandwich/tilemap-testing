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


    private Vector2 moveDir = Vector2.zero; //where player wishes to move based on input


    private void Update()
    {
        GetPlayerInput();
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
        rb.velocity = moveDir * moveSpeed * Time.fixedDeltaTime;
    }
}
