using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();
        FlippedSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }
    void FlippedSprite();
    {
        bool playerHorizontalSpeed = Mathf.Abs(myRigidbody.velocity)>Mathf.Epsilon;
        if (playerHorizontalSpeed){
            transform.local.Scale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
}
