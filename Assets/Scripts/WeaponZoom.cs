using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera _fpsCamera;

    [SerializeField] float _zoomedOut = 60f;
    [SerializeField] float _zoomedIn = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraZoom();
    }
    private void CameraZoom()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            _fpsCamera.fieldOfView = _zoomedIn;
            Debug.Log("Zooming in");
        }

        if (Input.GetButtonUp("Fire2"))
        {
            _fpsCamera.fieldOfView = _zoomedOut;
            Debug.Log("Zooming out");
        }
    }
}
