using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingKinematic : MonoBehaviour
{
    float angularSpeed;
    float restorationTorqueRate = 1f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //float leanAngle = transform.localRotation.z;
        //angularSpeed += restorationTorqueRate * leanAngle  *Time.deltaTime;
        //transform.Rotate(0, angularSpeed * Time.deltaTime);
    }
}
