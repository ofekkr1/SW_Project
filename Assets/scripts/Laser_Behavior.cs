using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Behavior : MonoBehaviour
{
    private BoxCollider2D collision;
    private GameObject[] platforms;
    public GameObject Ground;
    public GameObject Player;


    void Start()
    {
        collision = Ground.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(collision, this.GetComponent<BoxCollider2D>(), true);
        platforms= GameObject.FindGameObjectsWithTag("Platform");
        foreach(GameObject platform in platforms)
        {
            Physics2D.IgnoreCollision(platform.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>(), true);

        }
    }

    // Update is called once per frame
    void Update()
    {
            

       
           if(Timer_To_Join.GameStarted) this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, (float)0.4);

        




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(collision.collider, this.GetComponent<BoxCollider2D>(), true);
        
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
        }
    }

    bool checkPlayercoll()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            foreach (GameObject Platform in platforms)

                if ((player.GetComponent<BoxCollider2D>().IsTouching(Platform.GetComponent<BoxCollider2D>())) && player.transform.position.y >= 15)
                {
                    return true;
                }
        }
        return false;
    }

}
