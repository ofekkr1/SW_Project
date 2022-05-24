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
        
    }


}
