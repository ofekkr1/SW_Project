using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Behavior : MonoBehaviour
{
    [SerializeField] int MaxLeft;
    [SerializeField] int MaxRight;
    [SerializeField] int speed;
    private Rigidbody2D body;
    [SerializeField] GameObject ground;
    private GameObject platforms;
    private BoxCollider2D collider2D;
    private bool Player_col=false;
    PhotonView view;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
        collider2D = GetComponent<BoxCollider2D>();

    }

    void Update()
    {

        // if (body.transform.position.x > 6)
        //   body.velocity = new Vector2(-speed,body.velocity.y);
        //else if(body.transform.position.x < -6)
        //{
        //  body.velocity = new Vector2(speed, body.velocity.y);
        //}
        if (checkPlayercoll() && !Player_col)
        {
            GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
            ground.GetComponent<Rigidbody2D>().velocity = new Vector2(body.velocity.x, -5);
            foreach (GameObject platform in platforms)
            {
                platform.GetComponent<Rigidbody2D>().velocity = new Vector2(body.velocity.x, -5);
            }
            Player_col = true;

        }
    }

    bool checkPlayercoll()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if ((player.GetComponent<BoxCollider2D>().IsTouching(this.GetComponent<BoxCollider2D>())))
            {
                return true;
            }
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Physics2D.IgnoreCollision(collision.collider, collider2D,true);
            print("something");
        }
    }
}

