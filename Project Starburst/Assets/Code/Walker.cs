using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Walker : MonoBehaviour
{
   public Transform PlayerTransform, leftFootstepSpawner, rightFootstepSpawner;
   public NavMeshAgent agent;
   [SerializeField] GameObject footstep;
   public float footstepDisspearTime;
   public float speed;
   bool isRightStep;
   // Start is called before the first frame update
   void Start()
   {
      PlayerTransform = GameObject.Find("Player").transform;
      agent = this.gameObject.GetComponent<NavMeshAgent>();
      InvokeRepeating("CreateFootstep", 1.0f, 1f);
      InvokeRepeating("Retarget", 1.0f, .2f);
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
      isRightStep = !isRightStep;
      
      var tempSpawn = Instantiate(footstep);
      tempSpawn.transform.position = leftFootstepSpawner.position;
      if (isRightStep)
      {
         tempSpawn.transform.position = rightFootstepSpawner.position;
         tempSpawn.transform.localScale = new Vector3(tempSpawn.transform.localScale.x * -1, tempSpawn.transform.localScale.y, tempSpawn.transform.localScale.z);
      }
      tempSpawn.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
      Destroy(tempSpawn, footstepDisspearTime);
      var sound = this.GetComponent<AudioSource>();
      sound.pitch = RandomPitch();
      sound.Play();
   }
   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.tag == "Player")
      {
         print("Kill");

         // Start death sequence on the player
         collision.gameObject.GetComponent<PlayerMovement>().StartDeathSequence();
      }
   }

   float RandomPitch()
   {
      return Random.Range(0.6f, 0.8f);
   }
}
