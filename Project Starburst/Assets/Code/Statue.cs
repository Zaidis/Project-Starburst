using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Statue : MonoBehaviour
{
    private GameObject m_playerObj;

    // This is on the object itself
    private Renderer m_renderer;

    // Grab navmesh
    private NavMeshAgent m_navAgent;

    // Where we move to
    private Vector3 m_targetLocation;

    // Are we alive?
    private bool m_bAlive;

    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
        m_navAgent = GetComponent<NavMeshAgent>();
        m_navAgent.speed = 6f;
        m_bAlive = false;               
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bAlive)
        {
            m_targetLocation = (m_renderer.isVisible ? transform.position : m_playerObj.transform.position);            
        }
        else
        {
            m_targetLocation = transform.position;
        }

        m_navAgent.SetDestination(m_targetLocation);
    }

    public void SetAlive(bool isAlive)
    {
        m_bAlive = isAlive;        
    }

    public void SetPlayerObject(GameObject player)
    {
        m_playerObj = player;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (m_bAlive)
        {
            if (collision.gameObject.tag == "Player")
            {

            }
        }
    }
}