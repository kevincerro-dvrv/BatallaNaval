using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {
    private const int MAX_POWER = 6;
    private const int MIN_POWER = -2;
    private const int MAX_RUDDER = 3;

    private float baseSpeed = 0.8f;
    private int powerLevel = 0;


    private float baseRudderSpeed = 1.2f;
    private float baseRudderDrag = 0.2f;
    private int rudderLevel = 0;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.W)) {
            powerLevel = Mathf.Clamp(powerLevel+1, MIN_POWER, MAX_POWER);
            UserInterface.instance.SetPower(powerLevel);
        }

        if(Input.GetKeyDown(KeyCode.S)) {
            powerLevel = Mathf.Clamp(powerLevel-1, MIN_POWER, MAX_POWER);
            UserInterface.instance.SetPower(powerLevel);
        }

        if(Input.GetKeyDown(KeyCode.A)) {
            rudderLevel = Mathf.Clamp(rudderLevel - 1, -MAX_RUDDER, MAX_RUDDER);
            UserInterface.instance.SetRudder(rudderLevel);
        }
        if(Input.GetKeyDown(KeyCode.D)) {
            rudderLevel = Mathf.Clamp(rudderLevel + 1, -MAX_RUDDER, MAX_RUDDER);
            UserInterface.instance.SetRudder(rudderLevel);
        }
        

        float effectiveSpeed = powerLevel * baseSpeed;
        if(powerLevel != 0) {
            transform.Rotate(transform.up * baseRudderSpeed * rudderLevel * Mathf.Sign(effectiveSpeed) * Time.deltaTime, Space.World);
            effectiveSpeed -= Mathf.Sign(effectiveSpeed) * Mathf.Abs(rudderLevel) * baseRudderDrag;
        }

        transform.position += transform.forward * effectiveSpeed * Time.deltaTime;

        UserInterface.instance.SetSpeed(effectiveSpeed * 1.944f);
    }
}
