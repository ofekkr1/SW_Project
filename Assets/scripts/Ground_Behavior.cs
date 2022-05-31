using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Behavior : MonoBehaviour
{
    BoxCollider2D collider2D;

    void start()
    {
        collider2D = GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {
        if (checkPlayercoll())
        {
           
                this.gameObject.SetActive(false);
        
        }
    }
    


    bool checkPlayercoll()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] Platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject player in players)
        {
            foreach (GameObject Platform in Platforms)
                
                if ((player.GetComponent<BoxCollider2D>().IsTouching(Platform.GetComponent<BoxCollider2D>())) && player.transform.position.y >= 15)
                {
                    return true;
                }
        }
        return false;
    }

}
