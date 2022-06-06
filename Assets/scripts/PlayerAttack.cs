using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float coolDownTimer = Mathf.Infinity;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        bool isBombActive = SpawnPlayers.Bombs[0].GetComponent<Projectile>().isActiveAndEnabled;
        if (Input.GetKey(KeyCode.C) && !isBombActive)
        {
            Attack();
            
        }

        //coolDownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        //coolDownTimer = 0;

        SpawnPlayers.Bombs[0].transform.position = GetComponentInChildren<Transform>().position;
        SpawnPlayers.Bombs[0].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        //print("did it");
    }
}
