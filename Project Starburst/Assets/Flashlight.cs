using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    Light light;
    [SerializeField] float maxCharge, currentCharge, rechargeRate, usageSpeed, flickerEvent, lightIntensityTarget;
    [SerializeField] Vector2 flickerSpeedBounds;
    float flickerSpeed, lightIntensityMax;
    [SerializeField] KeyCode rechargeButton;
    [SerializeField] PlayerMovement playerMovement;
    private void Awake()
    {
        light = GetComponent<Light>();
    }
    // Start is called before the first frame update
    void Start()
    {
        flickerSpeed = PickRandomFlickerSpeed();
        currentCharge = maxCharge;
        lightIntensityMax = light.intensity;
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
        }else if(light.enabled && currentCharge <= flickerEvent)
        {
            Flicker();
        }
        else
        {
            Recharge();
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
                light.intensity = lightIntensityMax;
                ToggleFlashlight(true);
            }
        }
    }

    void Flicker()
    {
        light.intensity += flickerSpeed * Time.deltaTime;
        if (light.intensity > lightIntensityMax)
        {
            flickerSpeed = PickRandomFlickerSpeed();
            light.intensity = lightIntensityMax;
        }  
        else if (light.intensity < lightIntensityTarget)
        {
            flickerSpeed = PickRandomFlickerSpeed();
            light.intensity = lightIntensityTarget;
        }
    }

    float PickRandomFlickerSpeed()
    {
        float temp = Random.Range(flickerSpeedBounds.x, flickerSpeedBounds.y);
        if (flickerSpeed > 0)
            temp = -temp;
        else
            return temp;
        return temp;
    }
}
