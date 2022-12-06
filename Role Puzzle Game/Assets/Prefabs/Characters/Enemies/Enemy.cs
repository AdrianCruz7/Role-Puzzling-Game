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
    public EnemyMelee enemyMelee;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;

    DamagableCharacter damagableCharacter;

    void Update() {
        // if (animator.GetBool("IsAlive") == false)
        // {
        //     GetUp();
        // }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        damagableCharacter = GetComponent<DamagableCharacter>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate(){
        if(damagableCharacter.Targetable && enemyRange.detectedObjects.Count > 0 && canMove)
        {
            //Calculate direction
            Vector2 direction = (enemyRange.detectedObjects[0].transform.position - transform.position).normalized;

            //Flip sprites
            if(direction.x > 0)
            {
                spriteRenderer.flipX = false;
            } else if (direction.x < 1) {
                spriteRenderer.flipX = true;
                }

            rb.AddForce(direction * moveSpeed * Time.deltaTime);
            animator.SetBool("IsMoving", true);
        } else {
            animator.SetBool("IsMoving", false);
        }
    }
    
    //damage on collision
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
            //if (transform.localPosition <= damagable || transform.localPosition >= damagable)
        }
    }

    //set in animator
    public void MeleeAttack(){
        LockMovement();
        if (spriteRenderer.flipX == true)
        {
            enemyMelee.AttackLeft();
        } else {
            enemyMelee.AttackRight();
        }
    }

    //called in animator
    public void EndMeleeAttack(){
        UnlockMovement();
        enemyMelee.StopAttack();
    }

    public void LockMovement(){
        canMove = false;
    }

    public void UnlockMovement(){
        canMove = true;
    }

    public float getUpTime = 10;
    // void GetUp()
    // {
    //     getUpTime -= Time.deltaTime;
    //     if (getUpTime <= 0 )
    //     {
    //         animator.SetTrigger("GetUp");
    //     }
    // }
}