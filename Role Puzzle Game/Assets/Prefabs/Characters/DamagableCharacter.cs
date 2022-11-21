using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableCharacter : MonoBehaviour, IDamagable
{
    public GameObject healthText;
    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;

    public bool canTurnInvincible = false;
    public bool _targetable = true;
    public bool _invincible = false;
    bool IsAlive = true;

    public float invinciblityTime = 0.5f;
    private float invincibleTimeElapsed = 0f;
    public float _health = 5;

    public float Health {
        set {
            
            if (value < _health)
            {
                animator.SetTrigger("Hit");

                RectTransform textTransform = Instantiate(healthText).GetComponent<RectTransform>();
                textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

                Canvas canvas = GameObject.FindObjectOfType<Canvas>();
                textTransform.SetParent(canvas.transform);
            }
            _health = value;
            
            if (_health <= 0)
            {
                Defeated();
                Targetable = false;
            }
        }
        get {
            return _health;
        }
    }

    public bool Targetable 
    {
        set {
                _targetable = value;

                physicsCollider.enabled = value;
            } 
        get {
                return _targetable;
            }
    }

    public bool Invincible {
        set {
                _invincible = value;

                if (_invincible)
                {
                    invincibleTimeElapsed = 0f;
                }
            } 
        get {
                return _invincible;
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
        if (!Invincible){
            Health -= damage;

            //apply force to enemy
            rb.AddForce(knockback, ForceMode2D.Impulse);
            if (canTurnInvincible){
                //Active invinicibility
                Invincible = true;
            }
        }

    }
    public void OnHit(float damage)
    {
        if (!Invincible){
            Health -= damage;
            if (canTurnInvincible){
                //Active invinicibility
                Invincible = true;
            }
        }
    }

    public void onObjectDestoyed()
    {
        Destroy(gameObject);
    }

    public void FixedUpdate() {
        if (Invincible){
            invincibleTimeElapsed += Time.deltaTime;

            if (invincibleTimeElapsed > invinciblityTime){
                Invincible = false;
            }
        }
    }
}