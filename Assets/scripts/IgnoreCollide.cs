using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollide : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
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
