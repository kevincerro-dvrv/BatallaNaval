using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public InputNameForm inputNameForm;

    
    private int playerHealth;
    private int totalScore;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        playerHealth = 100; 
        totalScore = 0;
    }



    public void PlayerDamage(int damage) {
        playerHealth -= damage;
        Debug.Log("GameManager health " + playerHealth );
        UserInterface.instance.SetPlayerHealth(playerHealth, 100);
    }

    public void AddScore(int points) {
        totalScore += points;
        UserInterface.instance.SetScore(totalScore);

        if(totalScore >= 150) {
            Time.timeScale = 0;
            UserInterface.instance.ShowScoreScreen();
            inputNameForm.SetScore(totalScore);
        }
    }
}
