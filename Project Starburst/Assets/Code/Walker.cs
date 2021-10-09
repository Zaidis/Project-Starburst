using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walker : MonoBehaviour
{
   public Transform PlayerTransform;
   public float speed;
   // Start is called before the first frame update
   void Start()
   {
      PlayerTransform = GameObject.Find("Player").transform;
      InvokeRepeating("LaunchProjectile", 2.0f, 1f);
      //speed = 5f;
   }

   // Update is called once per frame
   void Update()
   {
      Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
      var agent = this.gameObject.GetComponent<NavMeshAgent>();
      agent.SetDestination(PlayerTransform.position);
      agent.speed = speed;
   }

   void LaunchProjectile()
   {
      
   }
}
