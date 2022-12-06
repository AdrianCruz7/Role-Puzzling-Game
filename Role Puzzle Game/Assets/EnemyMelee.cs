using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public float damage = 1f;
    public float knockbackForce = 500f;
    public Collider2D meleeCollider;

    Vector2 rightAttackOffset;


   // Start is called before the first frame update
    private void Start()
    {
        //rightAttackOffset = transform.parent.position;
    }

    public void AttackRight(){
        Debug.Log("Right");
        meleeCollider.enabled = true;
        //transform.position = rightAttackOffset;
        
        transform.position = new Vector2(transform.parent.position.x * -1, transform.parent.position.y);

        Debug.Log(transform.localPosition.ToString());
        Debug.Log(transform.position.ToString());
    }

    public void AttackLeft(){
        meleeCollider.enabled = true;
        transform.position = new Vector2(transform.parent.position.x, transform.parent.position.y);
        Debug.Log(transform.localPosition.ToString());
        Debug.Log(transform.position.ToString());
    }
    
    public void StopAttack(){
        meleeCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        IDamagable damagableObject = other.GetComponent<IDamagable>();
        if (damagableObject != null)
        {
            //calculates direction between enemy and damagable
            Vector3 parentPosition = transform.position;
        
            Vector2 direction = (other.gameObject.transform.position - parentPosition).normalized;
            Vector2 knockback = direction * knockbackForce;

            //damage enemy with knockback force applied
            damagableObject.OnHit(damage, knockback);
        }
    }

}
