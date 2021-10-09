using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLook : MonoBehaviour
{
   public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
   public RotationAxes axes = RotationAxes.MouseXAndY;
   public float sensitivityX = 15F;
   public float sensitivityY = 15F;
   public float minimumX = -360F;
   public float maximumX = 360F;
   public float minimumY = -60F;
   public float maximumY = 60F;
   float rotationY = 0F;
   [SerializeField] Transform transform;
   [SerializeField] public Image handImageComponent;

   string pickupTag = "Interactable";

   private void Start()
   {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
   }

   void Update()
   {
      if (axes == RotationAxes.MouseXAndY)
      {
         float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

         rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
         rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

         transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
      }
      else if (axes == RotationAxes.MouseX)
      {
         transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
      }
      else
      {
         rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
         rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

         transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
      }

      Transform cameraTransform = Camera.main.transform;
      RaycastHit hit;
      Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

      if (Physics.Raycast(ray, out hit, 2.5f))
      {
         if (hit.transform.CompareTag(pickupTag))
         {
            handImageComponent.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
               if (hit.transform.CompareTag(pickupTag))
               {
                  hit.collider.gameObject.GetComponent<IInteractable>().Interact();
               }
            }
         }
      }
      else
      {
         handImageComponent.enabled = false;
      }
   }

}
