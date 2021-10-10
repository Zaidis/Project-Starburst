using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestHandler : MonoBehaviour
{
    public static ChestHandler instance; //singleton
    public Chest[] chests; //holds all chests in the room
    public Chest nextChest = null;
    
    public int[] newCode;
    public List<int> currentCode; //what chests have been opened so far
    private int nextNum = 0;
    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }

        newCode = new int[chests.Length];
        currentCode = new List<int>();
    }

    private void Start() {
        MakeCode();
        InitializeChests();
    }

    public void OpenDoor() {
        print("I opened the door!");
    }

    /// <summary>
    /// Adds number to the code, or will reset all chests if the number order was wrong. 
    /// </summary>
    /// <param name="num"></param>
    public void CheckChest(int num) {
        if(num == newCode[nextNum]) {
            currentCode.Add(num);
            nextNum++;
            print("Correct Chest!!!");
            return;
        } else {
            ResetChests();
        }
    }

    /// <summary>
    /// Called when attempting to open the door. 
    /// </summary>
    /// <returns></returns>
    public bool CheckCode() {
        if(currentCode.Count == 4) {
            for (int i = 0; i < 5; i++) {
                if (newCode[i] == currentCode[i]) {
                    continue;
                }
                else {
                    return false;
                }
            }
        } else {
            //fixes the chest bug. will return false if the rest of the chests have not been opened yet
            return false;
        }
        return true;
    }

    /// <summary>
    /// Resets all of the chests. Closes them all, and clears the current code. 
    /// </summary>
    public void ResetChests() {
        nextNum = 0;
        foreach(Chest chest in chests) {
            if(chest.open == true)
                chest.CloseChest();
        }
        currentCode.Clear();
    }

    /// <summary>
    /// Creates the code that the player needs to solve with the chests. 
    /// </summary>
    private void MakeCode() {
        int num = 1;
        for(int i = 0; i < chests.Length; i++) {
            int digit = num;
            /*
            do {
                digit = Random.Range(1, 6);
            } while (HasNumber(digit) == true);
            */
            newCode[i] = digit;
            num++;
        }
    }
    /*
    private bool HasNumber(int num) {
        for(int i = 0; i < newCode.Length; i++) {
            if(num == newCode[i]) {
                return true;
            }
        }
        return false;
    } */

    /// <summary>
    /// Sets up all of the ID's for each chest. 
    /// </summary>
    private void InitializeChests() {
        for(int i = 0; i < chests.Length; i++) {
            chests[i].id = newCode[i];
        }
    }
}
