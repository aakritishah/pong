using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    public Text tomScoreText;
    public Text jerryScoreText;
    public int tomScore = 0;
    public int jerryScore = 0;
    private float winMessageDisplayTime = 3f; // time to display win messages (3 seconds)
    private float winMessageTimer = 3f; // timer to track win message display

    void Start() {
        updateScoreText();
    }

    void Update() {
        //Debug.LogError("should be less:");
        //Debug.LogError(winMessageTimer);
        //Debug.LogError("should be greater for entering the loop:");
        //Debug.LogError(winMessageDisplayTime);
        // Check if the win messages are displayed
        if (winMessageTimer < winMessageDisplayTime) {
            winMessageTimer += Time.deltaTime;

            // Check if it's time to display "GAME" and "OVER"
            if (winMessageTimer >= winMessageDisplayTime) {
                tomScoreText.text = "GAME";
                jerryScoreText.text = "OVER";
            }
        }
    }

    void updateScoreText() {
        //Debug.LogError("beginning of updateScoreText");
        tomScoreText.text = "Player 1: " + tomScore.ToString();
        jerryScoreText.text = "Player 2: " + jerryScore.ToString();
        //Debug.LogError("end of updateScoreText");
    }

    public void updateTom(int input) {
        //Debug.LogError("beginning of updateTom");
        tomScore += input;

        // check if Player 1 wins
        if (tomScore == 5){
            DisplayWinMessages("Player 1 Wins!", "Player 2 Loses!");
        } else {
            updateScoreText(); // update the scores if they didn't win yet
        }
    }
    
    private void DisplayWinMessages(string player1Message, string player2Message) {
    if (tomScore >= 5 || jerryScore >= 5) {
        // at least one player has won
        if (tomScore >= 5) {
            tomScoreText.text = player1Message;
            jerryScoreText.text = player2Message;
        } else {
            tomScoreText.text = player1Message;
            jerryScoreText.text = player2Message;
        }
    
        // start the timer
        winMessageTimer = 0f;
        FindObjectOfType<ball>().SetGameOverState(true);
        }
    }

    public void updateJerry(int input) {
    //Debug.LogError("beginning of updateJerry");
    jerryScore += input;

    // check if Player 2 wins
    if (jerryScore == 5) {
        DisplayWinMessages("Player 1 Loses!", "Player 2 Wins!");
    } else {
        updateScoreText();
        }
    }
}