using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : IInteractable
{

    private bool open;
    private Animator anim;

    private void Awake() {
        anim = transform.parent.GetComponent<Animator>();
    }
    public override void Interact()
    {
        if (!open) {

            OpenChest();

        } else {
            CloseChest();
        }

    }

    private void OpenChest() {
        anim.Play("chestOpen");
        open = true;
    }
    private void CloseChest() {
        anim.Play("chestClose");
        open = false;
    }
}
