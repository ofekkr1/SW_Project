using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(checkPlayercoll())
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag =="Platform" || collision.gameObject.tag =="Player" )
        {
            Physics2D.IgnoreCollision(collision.collider, this.GetComponent<BoxCollider2D>(), true);
            print("something");
        }
    }

    bool checkPlayercoll()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] Platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject player in players)
        {
            foreach(GameObject Platform in Platforms)
            if ((player.GetComponent<BoxCollider2D>().IsTouching(Platform.GetComponent<BoxCollider2D>())) && player.transform.position.y >= 15)
            {
                return true;
            }
        }
        return false;
    }
}
