using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour {
    public Transform cabinPivot;
    public Transform cannonPivot;

    private float towerRotationSpeed = 16f;
    private float cannonRotationSpeed = 8f;
    private float speedingFactor = 5f;

    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        
        if(Input.GetKey(KeyCode.LeftArrow) && horizontalInput <= 0) {
            horizontalInput = -1;
        } else if(Input.GetKey(KeyCode.RightArrow) && horizontalInput >= 0) {
            horizontalInput = 1;
        } else {
            horizontalInput = 0;
        }

        if(Input.GetKey(KeyCode.LeftControl)) {
            horizontalInput *= speedingFactor;
        }

        if(Input.GetKey(KeyCode.UpArrow) && verticalInput <= 0) {
            verticalInput = -1;
        } else if(Input.GetKey(KeyCode.DownArrow) && horizontalInput >= 0) {
            verticalInput = 1;
        } else {
            verticalInput = 0;
        }

        if(Input.GetKey(KeyCode.LeftControl)) {
            verticalInput *= speedingFactor;
        }


        cabinPivot.Rotate(Vector3.up * horizontalInput * towerRotationSpeed * Time.deltaTime);
        cannonPivot.Rotate(Vector3.right * verticalInput * cannonRotationSpeed * Time.deltaTime);



    }
}
