using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInterface : MonoBehaviour {
    public static UserInterface instance;

    public TextMeshProUGUI powerValue;
    public TextMeshProUGUI directionValue;
    public TextMeshProUGUI speedValue;
    public TextMeshProUGUI rudderValue;
    public TextMeshProUGUI rudderDirectionValue;

    public Image readyToShotLight;

    void Awake() {
        instance = this;
    }

    void Start() {


    }

    public void SetRudder(int rudderValue) {
        this.rudderValue.text = rudderValue.ToString();
        if(rudderValue == 0) {
            rudderDirectionValue.text = "";
        } else if(rudderValue < 0) {
            rudderDirectionValue.text = "L";
            this.rudderValue.text = (-1*rudderValue).ToString();
        } else {
            rudderDirectionValue.text = "R";
        }
    }

    public void SetPower(int powerValue) {
        this.powerValue.text = powerValue.ToString();
        if(powerValue == 0) {
            directionValue.text = "";
        } else if(powerValue < 0) {
            directionValue.text = "BCK";
        } else {
            directionValue.text = "FWD";
        }

    }

    public void SetSpeed(float speedValue) {
        this.speedValue.text = speedValue.ToString("0.00");
    }

    public void SetCannonLoaded(bool cannonLoaded) {
        if(cannonLoaded) {
            readyToShotLight.color = Color.green;
        } else {
            readyToShotLight.color = Color.red;
        }
        
    }

}
