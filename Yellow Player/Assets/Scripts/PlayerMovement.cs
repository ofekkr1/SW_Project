using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private bool grounded;
    private float horizontalInput;

    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed , body.velocity.y);

        //Flip player when moving left and right
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(-(float)0.5, (float)0.5, (float)0.5);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.5);

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jump();
        }   

        //Set animator parameters
        anim.SetBool("walk", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //        grounded = true;
    //}

    private bool isGrounded()
    {
        RaycastHit2D raycaseHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycaseHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bomb")
        {
            anim.SetTrigger("hit");
        }
    }
}
