using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour {
    public static UserInterface instance;

    private int rudderValue;
    private int powerValue;
    private float speedValue;


    private bool cannonLoaded;
    private Texture2D greenSquare;
    private Texture2D redSquare;

    void Awake() {
        instance = this;
    }

    void Start() {
        greenSquare = new Texture2D(80, 80);
        redSquare = new Texture2D(80, 80);

        for(int i=0; i<80; i++) {
            for(int j=0; j<80; j++) {
                redSquare.SetPixel(i, j, Color.red);
                greenSquare.SetPixel(i, j, Color.green);
            }
        }

        redSquare.Apply();
        greenSquare.Apply();
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

    public void SetCannonLoaded(bool cannonLoaded) {
        this.cannonLoaded = cannonLoaded;
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

        
        
        if(cannonLoaded) {
            GUI.Label(new Rect(Screen.width - 100, Screen.height -100, 80, 80), greenSquare);
        } else {
            GUI.Label(new Rect(Screen.width - 100, Screen.height -100, 80, 80), redSquare);
        }
    }
}
