using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcedDialogue : MonoBehaviour
{
    public DialogueTrigger dialogue;
    Rigidbody2D rb;
    BoxCollider2D bx;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        bx = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        dialogue.TriggerDialogue();
        //rb.simulated = false;
        bx.isTrigger = true;
    }
}
