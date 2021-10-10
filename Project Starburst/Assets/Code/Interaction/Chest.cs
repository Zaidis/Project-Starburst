using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Chest : IInteractable
{

    public bool open;
    private Animator anim;
    public int id;
    public TextMeshPro chestNumberText;
    public bool FinalChest;
   public Transform chestSpawner;

    private void Awake() {
        anim = transform.parent.GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (!open) {
            OpenChest();
        } 
    }

   public void SetChesttext()
   {
      chestNumberText.text = id.ToString();
   }

    private void OpenChest() {
      var shouldOpen= ChestHandler.instance.CheckChest(id);
      if(shouldOpen)
      {
         open = true;
         anim.Play("chestOpen");
         gameObject.tag = "Untagged";
      }
    }

    public void CloseChest() {
      open = false;
      anim.Play("chestClose");
      gameObject.tag = "Interactable";
    }

    public void SpawnSkull()
   {
      GameObject skull = Instantiate(ChestHandler.instance.skull, chestSpawner.transform.position,Quaternion.identity);
      skull.transform.localRotation = Quaternion.Euler(Vector3.zero);
      skull.gameObject.GetComponentInChildren<Skull>().textMessage = "The chest need to all be open";
   }
}
