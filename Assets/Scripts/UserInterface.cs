using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour {
    public static UserInterface instance;

    private int rudderValue;
    private int powerValue;
    private float speedValue;

    void Awake() {
        instance = this;
    }

    public void SetRudder(int rudderValue) {
        this.rudderValue = rudderValue;
    }

    public void SetPower(int powerValue) {
        this.powerValue = powerValue;
    }

    public void SetSpeed(float speedValue) {
        this.speedValue = speedValue;
    }

    public void OnGUI() {
        int screenHeight = Screen.height;
        if(rudderValue != 0) {
            if(rudderValue < 0) {
                GUI.Label(new Rect(10, screenHeight - 40, 50, 30), "LEFT");
            } else {
                GUI.Label(new Rect(10, screenHeight - 40, 50, 30), "RIGHT");
            }
        }

        GUI.Label(new Rect(70, screenHeight - 40, 50, 30), Mathf.Abs(rudderValue) + "");

        GUI.Label(new Rect(130, screenHeight - 40, 50, 30), powerValue + "");

        GUI.Label(new Rect(190, screenHeight - 40, 50, 30), speedValue.ToString("0.00"));
    }
}
