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
     
    PhotonView view;

    void Start()
    {
        body= GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
        body.velocity = new Vector2(speed, body.velocity.y);
    }

    void Update()
    {
        
        if (body.transform.position.x > 6)
            body.velocity = new Vector2(-speed,body.velocity.y);
        else if(body.transform.position.x < -6)
        {
            body.velocity = new Vector2(speed, body.velocity.y);
        }
    }
}
