using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : IInteractable
{
   bool isOpen;
    // Start is called before the first frame update
    void Start()
   {
      isOpen = false;
   }

   // Update is called once per frame
   void Update()
   {

   }

   public override void Interact()
   {
      if(!isOpen)
      {
         transform.parent.transform.Rotate(new Vector3(0, 90, 0));
         gameObject.tag = "Untagged";
      }
   }
}
