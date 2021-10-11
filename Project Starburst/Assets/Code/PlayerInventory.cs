using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   public bool hasVial;
   public int keyPieceCount;
   TextMeshProUGUI message;
   // Start is called before the first frame update
   void Start()
   {
      hasVial = false;
      keyPieceCount = 0;
      message = GameObject.Find("message").GetComponent<TextMeshProUGUI>();
   }

   // Update is called once per frame
   void Update()
   {

   }

   public void PickUpItem(string item)
   {
      if(item == "key")
      {
         keyPieceCount++;
         message.text = $"{keyPieceCount} / 4 crystal fragments found";
         Invoke("DisableMessage", 2.0f);
      }
      if(item == "vial")
      {
         hasVial = true;
      }
      Debug.Log($"item: {item} picked up");
   }

   private void DisableMessage()
   {
      message.text = "";
   }
}
