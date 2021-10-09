using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPiece : IInteractable
{
    [SerializeField]
    private PlayerInventory playerInventory;

    public override void Interact()
    {
        print("Grabbed");
        playerInventory.PickUpItem("key");
        Destroy(gameObject);
    }
}