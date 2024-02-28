using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyancyKinematic : MonoBehaviour {
    float balanceHeight;
    float startImbalance = 1f;
    float verticalSpeed;
    float acceleration = -5f;

    int numeroDivisionesPorFrame = 100;
    // Start is called before the first frame update
    void Start() {
        balanceHeight = transform.position.y;

        transform.position += transform.up*startImbalance;

        if(numeroDivisionesPorFrame == 0) {
            numeroDivisionesPorFrame = 1;
        }
    }

    // Update is called once per frame
    void Update() {

        float timePerDivision = Time.deltaTime / numeroDivisionesPorFrame;

        for(int i=0; i<numeroDivisionesPorFrame; i++) {
            verticalSpeed += acceleration * (transform.position.y - balanceHeight) * timePerDivision;
            transform.position += verticalSpeed * Vector3.up * timePerDivision;
        }
        
    }
}
