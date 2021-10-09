using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walker : MonoBehaviour
{
   public Transform PlayerTransform;
   public NavMeshAgent agent;
   public float speed;
   // Start is called before the first frame update
   void Start()
   {
      PlayerTransform = GameObject.Find("Player").transform;
      agent = this.gameObject.GetComponent<NavMeshAgent>();
      InvokeRepeating("CreateFootstep", 2.0f, 1f);
      InvokeRepeating("Retarget", 1.0f, .2f);
      //speed = 5f;
   }

   // Update is called once per frame
   void Update()
   {

   }

   void Retarget()
   {
      agent.SetDestination(PlayerTransform.position);
      agent.speed = speed;
   }
   void CreateFootstep()
   {
      
   }
}
