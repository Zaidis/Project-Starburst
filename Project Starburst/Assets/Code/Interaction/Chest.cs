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
    private void Awake() {
        anim = transform.parent.GetComponent<Animator>();
    }

    private void Start() {
        chestNumberText.text = id.ToString();
    }
    public override void Interact()
    {
        if (!open) {
            OpenChest();
        } 
    }

    private void OpenChest() {
        print("Opening Chest");
        open = true;
        anim.Play("chestOpen");
        ChestHandler.instance.CheckChest(id);
        if (FinalChest) {
            if (ChestHandler.instance.CheckCode()) {
                ChestHandler.instance.OpenDoor();
            }
        }
    }
    public void CloseChest() {
        anim.Play("chestClose");
        open = false;
    }
}
