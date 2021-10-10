using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Skull : IInteractable
{
   PlayerInventory inventory;
   TextMeshProUGUI message;
   [SerializeField] string textMessage;
   // Start is called before the first frame update
   void Start()
   {
      inventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
      message = GameObject.Find("message").GetComponent<TextMeshProUGUI>();
   }

   // Update is called once per frame
   void Update()
   {

   }

   public override void Interact()
   {
      if(inventory.hasVial || inventory.keyPieceCount >= 4)
      {
         LoadLevel.instance.LoadNextLevel();
      }
      else
      {
         message.text = textMessage;
         Invoke("DisableMessage", 2.0f);
      }
   }

   private void DisableMessage()
   {
      message.text = "";
   }
}
