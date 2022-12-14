using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;

    public GameObject InventoryItem;

    public Animator animator;
    public float itemNotifTime = 0;

    private void Awake()
    {
        Instance = this;
        animator.SetBool("IsInventoryOpen", false);
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }


    // public void ListItems()
    // {
    //     Debug.Log("Peanuts");

    //     foreach(Transform item in ItemContent)
    //     {
    //         Destroy(item.gameObject);
    //     }
    //     foreach(var item in Items)
    //     {
            
    //         GameObject obj = Instantiate(InventoryItem,ItemContent);
    //         var itemName = obj.transform.Find("Item/ItemName").GetComponent<Text>();
    //         var itemIcon = obj.transform.Find("Item/ItemIcon").GetComponent<Image>();


    //         itemName.text = item.itemName;
    //         itemIcon.sprite = item.icon;

            
    //     }
    // }
    

    public void changeInventoryState()
    {
        
        Debug.Log("Entered");
        if(animator.GetBool("IsInventoryOpen") == false)
        {
            animator.SetBool("IsInventoryOpen", true);
            Debug.Log("If");
        }else
        {
            animator.SetBool("IsInventoryOpen", false);
        }
    }

}