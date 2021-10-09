using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : IInteractable
{
   public string itemType;
   PlayerInventory inventory;
   // Start is called before the first frame update
   void Start()
   {
      inventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
   }

   // Update is called once per frame
   void Update()
   {

   }

   public override void Interact()
   {
      inventory.PickUpItem(itemType);
      Destroy(gameObject);
   }
}
