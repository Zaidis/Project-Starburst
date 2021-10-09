using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Mirror_Ghost : MonoBehaviour
{

    [SerializeField] private float movementSpeed;

    private NavMeshAgent agent;
    [SerializeField]  public Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        agent.SetDestination(target.position);
    }
}
