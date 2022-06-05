using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public Camera cam;
    private Rigidbody2D body;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask PlatformLayer;
    [SerializeField] private float speed;
    private Animator anim;
    private BoxCollider2D boxCollider;
    public GameObject ground;
    private bool grounded;
    public GameObject[] Platforms;
    [SerializeField] public Text username;
    PhotonView view;
    public Canvas canvas1;
    private float horizontalInput;
    int i = 0;
    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        GameObject[] Platforms = GameObject.FindGameObjectsWithTag("Ground");
        view = GetComponent<PhotonView>();

    }

    private void Update()
    {
        if (Timer_To_Join.GameStarted)
        {
            if (view.IsMine)
            {

                if (this.GetComponent<Rigidbody2D>().position.y < -50)
                {
                    if (GameObject.FindGameObjectsWithTag("Player").Length > i + 1)
                    {
                        body = GameObject.FindGameObjectsWithTag("Player")[++i].GetComponent<Rigidbody2D>();
                    }
                    this.gameObject.SetActive(false);


                }
                cam.transform.position = body.transform.position;
                horizontalInput = Input.GetAxis("Horizontal");
                body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

                //Flip player when moving left and right
                if (horizontalInput < 0.01f)
                    transform.localScale = Vector3.one;
                else if (horizontalInput > -0.01f)
                    transform.localScale = new Vector3(-1, 1, 1);

                if (Input.GetKey(KeyCode.Space) && isGrounded())
                {
                    Jump();
                }

                //Set animator parameters
                anim.SetBool("walk", horizontalInput != 0);
                anim.SetBool("grounded", grounded);
            }

        }
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed+5);
        anim.SetTrigger("jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag .Equals("Ground") || collision.gameObject.tag.Equals("Platform"))
        {
            grounded = true;
            
        }
        else
            grounded = false;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycaseHit1 = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycaseHit1.collider != null;
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
