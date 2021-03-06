using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chains : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] int threshold = 10;
    public int counter = 0;
    int currentTarget = -2;
    AudioSource src;
    private void Awake()
    {
        src = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerMovement.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       float input = Input.GetAxisRaw("Horizontal");
        if (input > 0 && currentTarget == 1)
        {
            counter++;
            src.Play();
            currentTarget = -currentTarget;
        }
        else if (input < 0 && currentTarget == -1)
        {
            counter++;
            src.Play();
            currentTarget = -currentTarget;
        } 
        else if(currentTarget == -2 && input != 0)
        {
            counter++;
            src.Play();
            currentTarget = -(int)input;
        }
        if (counter >= threshold)
        {
            playerMovement.enabled = true;
            Destroy(this);
        }
    }
}
