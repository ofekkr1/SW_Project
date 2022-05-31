using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsernameBehavior : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D body;
    void Start()
    {
        body = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(body.transform.position.x, body.transform.position.y - (float)0.2);

    }
}
