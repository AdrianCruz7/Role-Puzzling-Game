using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableCharacter : MonoBehaviour, IDamagable
{
    public GameObject healthText;
    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;
    bool IsAlive = true;
    float health = 1;
    bool targetable = true;
    public float Health {
        set {
            
            if (value < health)
            {
                animator.SetTrigger("Hit");

                RectTransform textTransform = Instantiate(healthText).GetComponent<RectTransform>();
                textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

                Canvas canvas = GameObject.FindObjectOfType<Canvas>();
                textTransform.SetParent(canvas.transform);
            }
            health = value;
            
            if (health <= 0)
            {
                Defeated();
                Targetable = false;
            }
        }
        get {
            return health;
        }
    }

    public bool Targetable 
    {
        set {
                targetable = value;

                physicsCollider.enabled = value;
            } 
        get {
                return targetable;
            }
    }

    private void Start() {
        animator = GetComponent<Animator>();
        animator.SetBool("IsAlive", IsAlive);
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }

    public void Defeated()
    {
        animator.SetBool("IsAlive", false);
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;

        //apply force to enemy
        rb.AddForce(knockback, ForceMode2D.Impulse);

    }
    public void OnHit(float damage)
    {
        Health -= damage;
    }

    public void onObjectDestoyed()
    {
        Destroy(gameObject);
    }

}