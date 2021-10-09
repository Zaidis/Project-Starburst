using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    Light light;
    [SerializeField] float maxCharge, currentCharge, rechargeRate, usageSpeed;
    [SerializeField] KeyCode rechargeButton;
    [SerializeField] PlayerMovement playerMovement;
    private void Awake()
    {
        light = GetComponent<Light>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentCharge = maxCharge;
    }

    // Update is called once per frame
    void Update()
    {
        if(light.enabled)
            currentCharge -= usageSpeed * Time.deltaTime;

        if(light.enabled && currentCharge <= 0)
        {
            //Flashlight is out of charge.
            ToggleFlashlight(false);
        }
        else
        {
            light.enabled = false;
        }
    }

    void ToggleFlashlight(bool val)
    {
        light.enabled = val;
    }
    void Recharge()
    {
        //Have to recharge flashlight!
        if (!light.enabled && Input.GetKey(rechargeButton))
        {
            currentCharge += rechargeRate * Time.deltaTime;
            if (currentCharge >= maxCharge)
            {
                //If the max charge has been met, enable the light
                currentCharge = maxCharge;
                ToggleFlashlight(true);
            }
        }
    }
}
