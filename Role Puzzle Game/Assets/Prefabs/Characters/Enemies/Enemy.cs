using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage = 1f;
    public float knockbackForce = 5f;
    public float moveSpeed = 100f;
    public bool canMove = true;

    public EnemyRange enemyRange;
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate(){
        if(enemyRange.detectedObjects.Count > 0 && canMove)
        {
            //Calculate direction
            Vector2 direction = (enemyRange.detectedObjects[0].transform.position - transform.position).normalized;


            rb.AddForce(direction * moveSpeed * Time.deltaTime); 
            animator.SetBool("IsMoving", true);
        } else {
            animator.SetBool("IsMoving", false);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D collider = col.collider;
        IDamagable damagable = col.collider.GetComponent<IDamagable>();

        if (damagable != null)
        {
            Vector2 direction = (col.gameObject.transform.position - transform.position).normalized;
            Vector2 knockback = direction * knockbackForce;

            //damage enemy with knockback force applied
            damagable.OnHit(damage, knockback);
        }
    }

    void OnAttack()
    {
        animator.SetTrigger("Attack");
    }

    public void LockMovement(){
        canMove = false;
    }

    public void UnlockMovement(){
        canMove = true;
    }
}