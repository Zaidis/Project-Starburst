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
    bool rechargeFlashlight = false, canRecharge = false;
    AudioSource src;

    private void Awake()
    {
        light = GetComponent<Light>();
        src = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentCharge = maxCharge;
        lightIntensityMax = light.intensity;
        flickerSpeed = PickRandomFlickerSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (light.enabled)
        {
            if (currentCharge <= 0)
            {
                //Flashlight is out of charge.
                ToggleFlashlight(false);
            }
            else if (currentCharge <= flickerEvent)
            {
                Flicker();
                canRecharge = true;

            }
            currentCharge -= usageSpeed * Time.deltaTime;
           
            
        }
        if (canRecharge)
            Recharge();
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
    void ToggleFlashlight(bool val)
    {
        light.enabled = val;
    }
    void Recharge()
    {
        //Have to recharge flashlight!
        if (Input.GetKeyDown(rechargeButton))
        {
            rechargeFlashlight = true;
            if (!src.isPlaying)
                src.Play();
        }
        if (rechargeFlashlight)
        {
            playerMovement.canMove = false;
            ToggleFlashlight(false);
            currentCharge += rechargeRate * Time.deltaTime;
            if (currentCharge >= maxCharge)
            {
                //If the max charge has been met, enable the light
                currentCharge = maxCharge;
                ToggleFlashlight(true);
                light.intensity = lightIntensityMax;
                playerMovement.canMove = true;
                rechargeFlashlight = false;
                canRecharge = false;
                src.Stop();
            }
        }
    }
}
