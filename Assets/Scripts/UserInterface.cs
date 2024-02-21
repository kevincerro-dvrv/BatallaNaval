using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    public static UserInterface instance;

    private int rudderValue;

    void Awake()
    {
        instance = this;
    }

    public void SetRudder(int rudderValue)
    {
        this.rudderValue = rudderValue;
    }

    void OnGUI()
    {
        Debug.Log("Funciona");

        int screenHeight = Screen.height;

        if (rudderValue != 0) {
            if (rudderValue < 0) {
                GUI.Label(new Rect(10, screenHeight - 40, 50, 30), "LEFT");
            } else {
                GUI.Label(new Rect(10, screenHeight - 40, 50, 30), "RIGHT");
            }
        }

        GUI.Label(new Rect(70, screenHeight - 40, 50, 30), Mathf.Abs(rudderValue) + "");
    }
}
