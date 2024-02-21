using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform cameraPosition;
    public Camera mainCamera;
    public Camera panCamera;
    

    void Update() {
        if(Input.GetKeyDown(KeyCode.C)) {
            ToggleCameraViewPorts();
        } 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = cameraPosition.position;
        transform.rotation = cameraPosition.rotation;
    }

    private void ToggleCameraViewPorts() {
        Debug.Log("Si, pulsaste la C");
        Rect auxViewPort = mainCamera.rect;
        float auxDepth = mainCamera.depth;

        mainCamera.rect = panCamera.rect;
        mainCamera.depth = panCamera.depth;

        panCamera.rect = auxViewPort;
        panCamera.depth = auxDepth;
    }
}
