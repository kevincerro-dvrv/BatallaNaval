using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRecoil : MonoBehaviour {
    [Tooltip("Starting recoil speed")]
    public float recoilSpeed;
    [Tooltip("Acceleration to get the cannon back to the starting position")]
    public float restorationAcceleration;

    private bool recoilActive;

    // Start is called before the first frame update
    void Start()
    {
        recoilActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if( ! recoilActive) {
            return;
        }
        
    }

    public void StartRecoil() {
        recoilActive = true;
    }
}
