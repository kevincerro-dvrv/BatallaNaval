using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputNameForm : MonoBehaviour {
    public TextMeshProUGUI scoreValue;
    public TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveButtonOnClick() {
        Debug.Log($"[InputNameForm] SaveButtonOnClick {nameInput.text} consiguió {scoreValue.text} puntos");

    }

    public void SetScore(int score) {
        scoreValue.text = score.ToString();
    }
}
