using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public enum AttackDirection{
        LEFT,
        RIGHT
    }

    public AttackDirection attackDirection;

    Vector2 rightAttackOffset;

   // Start is called before the first frame update
    private void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        
        rightAttackOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(){
        switch(attackDirection)
        {
            case AttackDirection.LEFT:
            AttackLeft();
            break;
            case AttackDirection.RIGHT:
            AttackRight();
            break;
        }
    }

    Collider2D swordCollider;
    private void AttackRight(){
        swordCollider.enabled = true;
        transform.position = rightAttackOffset;
    }

    private void AttackLeft(){
        swordCollider.enabled = true;
        transform.position = new Vector2(rightAttackOffset.x * -1, rightAttackOffset.y);
    }
    
    public void StopAttack(){
        swordCollider.enabled = false;
    }
}
