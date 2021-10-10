using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Mirror_Ghost : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    [SerializeField] public Transform target;
    [SerializeField] private bool isAlive;
    [SerializeField] private bool isSeen;
    [SerializeField] private bool isInArea;
    private NavMeshAgent agent;
    private Renderer m_renderer;
    [SerializeField] private float stunTimer;
    [SerializeField] private bool stunned;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        m_renderer = GetComponent<Renderer>();
        isAlive = true;
    }
    private void Start()
    {
        stunTimer = 3f;
        agent.speed = movementSpeed;
    }
    private void Update()
    {
        if (m_renderer.isVisible == true)
        {
            isSeen = true;
        } else
        {
            isSeen = false;
        }
    }
    private void FixedUpdate()
    {
        if (isAlive)
        {
            if (isSeen)
            {
                if(!stunned)
                    Stunned();
            } else
            {
                //ghost is not seen by the mirror
                agent.SetDestination(target.position);
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Mirror Area"))
        {
            isInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Mirror Area"))
        {
            isInArea = false;
        }
    }

    /// <summary>
    /// Stuns the ghost for a certain amount of time
    /// </summary>

    private void Stunned()
    {
        stunned = true;
        agent.isStopped = true;
        Invoke("GhostResume", stunTimer);
    }

    /// <summary>
    /// The ghost begins to walk again after being stunned.
    /// </summary>
    private void GhostResume()
    {
        stunned = false;
        agent.isStopped = false;
    }

   /// <summary>
   /// Kills the player if the ghost collides with it
   /// </summary>
   /// <param name="collision"></param>
   private void OnCollisionEnter(Collision collision)
   {
         if (collision.gameObject.tag == "Player")
         {
            print("Kill");

            // Start death sequence on the player
            collision.gameObject.GetComponent<PlayerMovement>().StartDeathSequence();
         }
   }
}
