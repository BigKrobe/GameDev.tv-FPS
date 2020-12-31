using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float _lightDecay = .1f;
    [SerializeField] float _angleDecay = 1f;
    [SerializeField] float _minAngle = 40f;

    Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= _minAngle)
        {
            return;
        }
        else
        {
            myLight.spotAngle -= _angleDecay * Time.deltaTime;
        }
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= _lightDecay * Time.deltaTime;
    }
}
