using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float _increaseIntensity = 2f;
    [SerializeField] float _restoreAngle = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(_restoreAngle);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightIntensity(_increaseIntensity);
            Destroy(gameObject);
        }
    }
}
