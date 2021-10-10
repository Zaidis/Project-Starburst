using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class Door : IInteractable
{
   bool isOpen;
    // Start is called before the first frame update
    void Start()
   {
      isOpen = false;
   }

   public override void Interact()
   {
      if(!isOpen)
      {
            transform.parent.parent.gameObject.GetComponent<PlayableDirector>().Play();
         //transform.parent.transform.Rotate(new Vector3(0, 90, 0));
         gameObject.tag = "Untagged";
            isOpen = true;
      }
   }
}
