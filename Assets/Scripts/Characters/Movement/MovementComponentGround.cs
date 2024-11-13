using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponentGround : MonoBehaviour
{
    public float speed;
    public float horizontalSpeedModifierMultiplicative;
    public float verticalSpeedModifierMultiplicative;
    public float horizontalSpeedModifierAdditive;
    public float verticalSpeedModifierAdditive;

    public int maxJumpCharges;
    public int currentJumpCharges;
    [SerializeField] private float jumpPower;
    
    public float jumpModifier;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float maxFallSpeed;

    
    public Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public bool facingRight;


    void Start()
    {
        //rb = characterGameObject.GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (currentJumpCharges > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower * jumpModifier);
            currentJumpCharges--;
        }
        
    }

    public void JumpCancel()
    {
        if (rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0f);
        }
    }

    public void Move(float horizontal)
    {
        //rb.AddForce(new Vector2(horizontal * speed, 0f), ForceMode2D.Impulse);
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        Flip(horizontal);
    }

    void Update()
    {
        if (IsGrounded() && rb.velocity.y <= 0)
        {
            currentJumpCharges = maxJumpCharges;
        }
    }
    //character.GetComponent<BoxCollider2D>()

    private void FixedUpdate()
    {

    }

    public void ApplyGravity()
    {
        //if (isDashing == false)
        //{
            //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - fallSpeed);
            rb.AddForce(new Vector2(0, -fallSpeed));
        //}
        
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Flip(float horizontal)
    {
        if (facingRight && horizontal < 0f || facingRight && horizontal >= 0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x = -1f;
            transform.localScale = localScale;
        }
    }
}
