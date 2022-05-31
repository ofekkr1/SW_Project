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
    public GameObject Laser;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
        collider2D = GetComponent<BoxCollider2D>();
        

    }

    void Update()
    {

        
       
            if (this.GetComponent<Rigidbody2D>().position.y < -5)
            {
                
                this.gameObject.SetActive(false);
            }
            else
            {
                Physics2D.IgnoreCollision(ground.GetComponent<BoxCollider2D>(), collider2D, true);

                if (checkPlayercoll() && !Player_col)
                {
                Laser.GetComponent<Rigidbody2D>().velocity = new Vector2(Laser.GetComponent<Rigidbody2D>().velocity.x, 3);
                GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
                foreach (GameObject platform in platforms)
                {
                        
                        platform.GetComponent<Rigidbody2D>().velocity = new Vector2(body.velocity.x, -5);
                }
                    Player_col = true;
                }
            }
        
        
    }

    public bool checkPlayercoll()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if ((player.GetComponent<BoxCollider2D>().IsTouching(this.GetComponent<BoxCollider2D>())) && player.transform.position.y>=15)
            {
                return true;
            }
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            Physics2D.IgnoreCollision(collision.collider, collider2D,true);
            print("something");
        }
       
    }
}

