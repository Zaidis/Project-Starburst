using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   public bool hasVial;
   public int keyPieceCount;
   // Start is called before the first frame update
   void Start()
   {
      hasVial = false;
      keyPieceCount = 0;
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
      }
      if(item == "vial")
      {
         hasVial = true;
      }
      Debug.Log($"item: {item} picked up");
   }
}
