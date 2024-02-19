using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRecoil : MonoBehaviour {
    [Tooltip("Starting recoil speed")]
    public float recoilSpeed;
    [Tooltip("Acceleration to get the cannon back to the starting position")]
    public float restorationAcceleration;
    [Tooltip("Max speed archievable when returning to the original position")]
    public float maxRestorationSpeed;
    private float speed;

    private bool recoilActive;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        recoilActive = false;
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if( ! recoilActive) {
            return;
        }
        
        transform.position += speed * Time.deltaTime * transform.forward;
        speed += restorationAcceleration * Time.deltaTime;
        speed = Mathf.Clamp(speed, -recoilSpeed, maxRestorationSpeed);

        if (transform.localPosition.z > startPosition.z) {
            speed = 0;
            recoilActive = false;
            transform.localPosition = startPosition;
        }
    }

    public void StartRecoil() {
        recoilActive = true;
        speed = -recoilSpeed;
    }
}
