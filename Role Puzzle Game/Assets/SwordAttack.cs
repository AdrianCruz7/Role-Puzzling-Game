using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    Vector2 rightAttackOffset;

    Collider2D swordCollider;

   // Start is called before the first frame update
    private void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        
        rightAttackOffset = transform.position;
    }

    public void AttackRight(){
        print("Right");
        swordCollider.enabled = true;
        transform.position = rightAttackOffset;
    }

    public void AttackLeft(){
        print("Left");
        swordCollider.enabled = true;
        transform.position = new Vector2(rightAttackOffset.x * -1, rightAttackOffset.y);
    }
    
    public void StopAttack(){
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy")
        {
            
        }
    }
}
