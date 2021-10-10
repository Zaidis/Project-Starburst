using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StatueHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject statueAliveObj, statueDeadObj, playerObj;

    [SerializeField]
    private int statueAliveCount, statueDeadCount;

    [SerializeField]
    private float rangeX, rangeZ;

    [SerializeField]
    private List<Statue> m_statueArray;

    private Statue m_currentAliveStatue;

    private float m_baseStatueLifetime = 30, m_baseStatueCooldown = 10;
    private float m_counter;

    private bool m_bSpawnedAlive = false, m_bSpawnedDead = false;

    enum StatueState
    {
        ALIVE = 0,
        COOLDOWN = 1
    };

    private StatueState m_currentState;

    // Start is called before the first frame update
    void Start()
    {
        //m_statueArray = new List<Statue>();

        //SpawnLivingStatues();
        //SpawnDeadStatues();

        m_currentState = StatueState.COOLDOWN;
        m_counter = m_baseStatueCooldown;

        foreach (Statue statue in m_statueArray)
        {
            statue.SetPlayerObject(playerObj);
        }
    }

    // Update is called once per frame
    void Update()
    {       
        // Do not do anything until we are done spawning the statues
        //if (!m_bSpawnedDead || !m_bSpawnedAlive)
        //{
        //    return;
        //}

        // If we are ready for an action, change the state
        if (m_counter > 0)
        {
            m_counter -= Time.deltaTime;
        }
        else
        {
            if (m_currentState == StatueState.COOLDOWN)
            {
                PickNewStatue();
            }
            else if (m_currentState == StatueState.ALIVE)
            {
                PauseAllStatues();
            }
        }        
    }

    private void PickNewStatue()
    {
        print("Picking new statue");

        // Set counter to count lifetime
        m_counter = m_baseStatueLifetime;

        // Change state to alive
        m_currentState = StatueState.ALIVE;        

        // Grab random statue to come alive
        int randIndex = Random.Range(0, m_statueArray.Count);
        m_currentAliveStatue = m_statueArray[randIndex];

        // Set this statue to alive, allowing it to move
        m_currentAliveStatue.SetAlive(true);        
        
    }

    private void PauseAllStatues()
    {
        print("Pausing all statues");

        // Set counter to count cooldown
        m_counter = m_baseStatueCooldown;

        // Change state to cooldown
        m_currentState = StatueState.COOLDOWN;

        // Set current active statue to pause
        m_currentAliveStatue.SetAlive(false);
    }

    private void SpawnLivingStatues()
    {
        // Spawn Living statues
        for (int i = 0; i < statueAliveCount; i++)
        {
            // Spawn a new statue at random point
            float randX = Random.Range(rangeX * -1, rangeX);
            float randZ = Random.Range(rangeZ * -1, rangeZ);

            Vector3 spawnLocation = new Vector3(randX, 0, randZ);

            // Spawn the new statue
            GameObject clone = Instantiate(statueAliveObj, spawnLocation, Quaternion.identity);

            // Get the script
            Statue statueScript = clone.GetComponent<Statue>();

            // Set the statue to follow the player
            statueScript.SetPlayerObject(playerObj);            

            // Add this script to the list of candidates for moving statue
            m_statueArray.Add(statueScript);
        }
        m_bSpawnedAlive = true;
    }

    private void SpawnDeadStatues()
    {
        // Spawn Living statues
        for (int i = 0; i < statueDeadCount; i++)
        {
            // Spawn a new statue at random point
            float randX = Random.Range(rangeX * -1, rangeX);
            float randZ = Random.Range(rangeZ * -1, rangeZ);

            Vector3 spawnLocation = new Vector3(randX, 0, randZ);

            Instantiate(statueDeadObj, spawnLocation, Quaternion.identity);
        }
        m_bSpawnedDead = true;
    }
}
