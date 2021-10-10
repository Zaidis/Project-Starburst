using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    [SerializeField] Transform cam;
    private bool isDead;
    [SerializeField] AudioSource src;
    public bool canMove;
    private void Start()
    {
        isDead = false;
        canMove = true;
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (canMove)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 move = new Vector3(x, 0f, z);
            move.Normalize();

            if (move.magnitude > 0)
            {
                if (!src.isPlaying)
                {
                    src.pitch = RandomPitch();
                    src.Play();
                }
                move = cam.TransformDirection(move);
                controller.Move(move * Time.deltaTime * playerSpeed);
            }
            else
            {
                controller.Move(new Vector3(0, 0, 0));
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity);
        }
        else
        {
            controller.Move(new Vector3(0, 0, 0));
        }
        
        
    }

    public void StartDeathSequence()
    {
        // Lock input
        isDead = true;

        // Play scream

        // Fade screen
        LoadLevel.instance.ReloadCurrentLevel();
    }

    float RandomPitch()
    {
        return Random.Range(0.6f, 0.8f);
    }
}
