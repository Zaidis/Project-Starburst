using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skull : IInteractable
{
   PlayerInventory inventory;
   Text message;
   // Start is called before the first frame update
   void Start()
   {
      inventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
      message = GameObject.Find("message").GetComponent<Text>();
   }

   // Update is called once per frame
   void Update()
   {

   }

   public override void Interact()
   {
      if(inventory.hasVial || inventory.keyPieceCount >= 4)
      {
         //Set next scene
      }
      else
      {
         message.text = "You need the vial";
         Invoke("DisableMessage", 2.0f);
      }
   }

   private void DisableMessage()
   {
      message.text = "";
   }
}
