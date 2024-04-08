using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {
    public static UserInterface instance;

    public TextMeshProUGUI powerValue;
    public TextMeshProUGUI directionValue;
    public TextMeshProUGUI speedValue;
    public TextMeshProUGUI rudderValue;
    public TextMeshProUGUI rudderDirectionValue;
    public Image readyToShotLight;

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
        this.rudderValue.text = Mathf.Abs(rudderValue).ToString();
        if(rudderValue == 0) {
            rudderDirectionValue.text = "";
        } else if(rudderValue < 0) {
            rudderDirectionValue.text = "L";
        } else {
            rudderDirectionValue.text = "R";
        }
    }

    public void SetPower(int powerValue) {

        this.powerValue.text = powerValue.ToString();
        if (powerValue == 0) {
            directionValue.text = "";
        } else if (powerValue < 0) {
            directionValue.text = "BKW";
        } else {
            directionValue.text = "FWD";
        }
    }

    public void SetSpeed(float speedValue) {
        this.speedValue.text= speedValue.ToString("0.00");
    }

    public void SetCannonLoaded(bool cannonLoaded) {
        if (cannonLoaded) {
            readyToShotLight.color = Color.green;
        } else {
            readyToShotLight.color = Color.red;
        }
    }
}
