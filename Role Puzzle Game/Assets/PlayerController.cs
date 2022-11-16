using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;
    
    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        //If movement input is > 0
        if (movementInput != Vector2.zero && canMove)
        {
            bool success = tryMove(movementInput);

            if(!success)
            {
                success = tryMove(new Vector2(movementInput.x, 0)); 
            }
            
            if(!success)
            {
                success = tryMove(new Vector2(movementInput.y, 0));
            }

            animator.SetBool("isMoving", success);
        } else {
            animator.SetBool("isMoving", false);
        }
        //Flip sprite based on direction
        if (movementInput.x < 0){
            spriteRenderer.flipX = true;
        } else if (movementInput.x > 0){
            spriteRenderer.flipX = false;
        }
    }

    private bool tryMove(Vector2 direction)
    {
        if (direction != Vector2.zero){
            int count = rb.Cast(
                    direction,
                    movementFilter,
                    castCollisions,
                    moveSpeed * Time.fixedDeltaTime + collisionOffset);

                    if (count == 0){
                        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                        return true;
                    }else
                    {
                        return false;
                    }
        } else {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnMelee_Attack()
    {
        animator.SetTrigger("Sword_Attack");
    }

    public void SwordAttack(){
        LockMovement();
        if (spriteRenderer.flipX == true)
        {
            swordAttack.AttackLeft();
        } else {
            swordAttack.AttackRight();
        }
    }

    public void EndSwordAttack(){
        UnlockMovement();
        swordAttack.StopAttack();
    }

    public void LockMovement(){
        canMove = false;
    }

    public void UnlockMovement(){
        canMove = true;
    }
}
