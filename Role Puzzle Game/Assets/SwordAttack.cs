using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float damage = 2;
    Vector2 rightAttackOffset;

    public Collider2D swordCollider;

   // Start is called before the first frame update
    private void Start()
    {
        //swordCollider = GetComponent<Collider2D>();
        
        rightAttackOffset = transform.position;
    }

    public void AttackRight(){
        print("Right");
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft(){
        print("Left");
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(rightAttackOffset.x * -1, rightAttackOffset.y);
    }
    
    public void StopAttack(){
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy")
        {
            //Deals damage to enemy
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Health -= damage;
            }
        }
    }
}
