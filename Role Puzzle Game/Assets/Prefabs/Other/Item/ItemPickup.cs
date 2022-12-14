using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    PlayerController player;

    public void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
        InventoryManager.Instance.changeInventoryState();
        InventoryManager.Instance.itemNotifTime = 3;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Pickup();
        }
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            Pickup();
        }
    }
}