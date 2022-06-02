using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 3;
    private bool hit;
    private Animator anim;
    //private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider;
    private float direction;
    //public Vector3 launchOffset;
    public float fieldOfImpact;
    public float force;
    public LayerMask layerToHit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        //boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (hit) return;
        
        //float movementSpeed = speed * Time.deltaTime * direction;
        //transform.Translate(movementSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        //boxCollider.enabled = false;
        circleCollider.enabled = false;
        anim.SetTrigger("explode");
        Explode();
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        //boxCollider.enabled = true;
        circleCollider.enabled = true;
        Rigidbody2D bombRigidbody = GetComponent<Rigidbody2D>();
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) > _direction)
        {
            bombRigidbody.AddForce((transform.right + Vector3.up) * speed, ForceMode2D.Impulse);
            transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            bombRigidbody.AddForce((-transform.right + Vector3.up) * speed, ForceMode2D.Impulse);
            transform.localScale = new Vector3(-localScaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    private void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layerToHit);
        foreach(Collider2D obj in objects)
        {
            Vector2 dir = -obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
