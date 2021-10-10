using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public void Finish()
    {
        GetComponentInChildren<LoadLevel>().LoadMenu();
    }
}
