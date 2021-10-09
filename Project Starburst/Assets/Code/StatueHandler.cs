using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueHandler : MonoBehaviour
{
    /*
     * Pick random Statue in the array as the starting Statue
     * Set that statue as active, store it as "active statue"
     * After X seconds, set that statue as inactive, repick statue to set as active
     */

    [SerializeField]
    private GameObject[] m_statueArray;

    private Statue m_currentAliveStatue;

    // Start is called before the first frame update
    void Start()
    {
        // Grab random statue to start as alive
        int randIndex = Random.Range(0, m_statueArray.Length);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PickNewStatue()
    {

    }
}
