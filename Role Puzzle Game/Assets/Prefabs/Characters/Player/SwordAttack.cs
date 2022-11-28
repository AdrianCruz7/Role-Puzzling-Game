using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float damage = 1f;
    public float knockbackForce = 500f;
    public Collider2D swordCollider;

    Vector2 rightAttackOffset;
    InventoryManager inv;


   // Start is called before the first frame update
    private void Start()
    {
        //swordCollider = GetComponent<Collider2D>();
        
        rightAttackOffset = transform.position;
    }

    public void AttackRight(){
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft(){
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(rightAttackOffset.x * -1, rightAttackOffset.y);
    }
    
    public void StopAttack(){
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        IDamagable damagableObject = other.GetComponent<IDamagable>();
        if (damagableObject != null)
        {
            //calculates direction between player and damagable
            Vector3 parentPosition = transform.parent.position;
        
            Vector2 direction = (other.gameObject.transform.position - parentPosition).normalized;
            Vector2 knockback = direction * knockbackForce;

            //damage enemy with knockback force applied
            damagableObject.OnHit(damage, knockback);
        }
    }

//Collision Enemies that can move the player
    void OnCollisionEnter2D(Collision2D other) {
        
    }
}
