using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondCamera;

    // Call this function to disable FPS camera,
    // and enable overhead camera.
    public void ShowMainCamera()
    {
        mainCamera.enabled = false;
        secondCamera.enabled = true;
    }

    // Call this function to enable FPS camera,
    // and disable overhead camera.
    public void ShowSecondCamera()
    {
        mainCamera.enabled = true;
        secondCamera.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            ShowMainCamera();
        }
        if (Input.GetKey(KeyCode.B))
        {
            ShowSecondCamera();
        }
    }
}
