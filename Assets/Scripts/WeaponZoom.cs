using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera _fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;

    [SerializeField] float _zoomedOut = 60f;
    [SerializeField] float _zoomedOutSensitivity = 2f;
    [SerializeField] float _zoomedIn = 30f;
    [SerializeField] float _zoomedInSensitivity = .5f;

    private void Update()
    {
        CameraZoom();
    }
    private void CameraZoom()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            fpsController.mouseLook.XSensitivity = _zoomedInSensitivity;
            fpsController.mouseLook.YSensitivity = _zoomedInSensitivity;
            _fpsCamera.fieldOfView = _zoomedIn;
            Debug.Log("Zooming in");
        }

        if (Input.GetButtonUp("Fire2"))
        {
            fpsController.mouseLook.XSensitivity = _zoomedOutSensitivity;
            fpsController.mouseLook.YSensitivity = _zoomedOutSensitivity;
            _fpsCamera.fieldOfView = _zoomedOut;
            Debug.Log("Zooming out");
        }
    }
}
