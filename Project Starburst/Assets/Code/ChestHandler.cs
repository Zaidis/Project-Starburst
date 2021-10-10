using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestHandler : MonoBehaviour
{
   public static ChestHandler instance; //singleton
   public Chest[] chests; //holds all chests in the room
   public List<int> possibleNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
   public int nextChestIndex;
   public PlayerInventory playerInventory;

   public GameObject skull;
   public int[] newCode;
   private int nextNum = 0;
   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
      else
      {
         Destroy(this.gameObject);
      }

      newCode = new int[chests.Length];
   }

   private void Start()
   {
      MakeCode();
      InitializeChests();

      playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
   }

   public void OpenDoor()
   {
      playerInventory.hasVial = true;
   }

   /// <summary>
   /// Adds number to the code, or will reset all chests if the number order was wrong. 
   /// </summary>
   /// <param name="num"></param>
   public bool CheckChest(int id)
   {
      if (id == chests[nextChestIndex].id)
      {
         nextChestIndex++;
         if (nextChestIndex >= 5)
         {
            DisableClickingChests();
            playerInventory.hasVial = true;
         }
         return true;
      }
      else
      {
         ResetChests();
         return false;
      }
   }

   /// <summary>
   /// Resets all of the chests. Closes them all, and clears the current code. 
   /// </summary>
   public void ResetChests()
   {
      foreach (Chest chest in chests)
      {
         if (chest.open == true)
            chest.CloseChest();
      }
      nextChestIndex = 0;
   }

   public void DisableClickingChests()
   {
      foreach (Chest chest in chests)
      {
         if (chest.open == true)
            chest.gameObject.tag = "Untagged";
      }
   }

   /// <summary>
   /// Creates the code that the player needs to solve with the chests. 
   /// </summary>
   private void MakeCode()
   {
      for (int i = 0; i < chests.Length; i++)
      {
         int num = Random.Range(0, possibleNumbers.Count);
         int code = possibleNumbers[num];
         possibleNumbers.RemoveAt(num);
         newCode[i] = code;
      }
   }

   /// <summary>
   /// Sets up all of the ID's for each chest. 
   /// </summary>
   private void InitializeChests()
   {
      for (int i = 0; i < chests.Length; i++)
      {
         chests[i].id = newCode[i];
         chests[i].SetChesttext();
      }
      for (int i = 0; i < chests.Length; i++)
      {
         for (int j = i; j < chests.Length; j++)
         {
            if (chests[i].id > chests[j].id)
            {
               var temp = chests[i];
               chests[i] = chests[j];
               chests[j] = temp;
            }
         }
      };
      nextChestIndex = 0;
      chests[4].SpawnSkull();
   }
}
