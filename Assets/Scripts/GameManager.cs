using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static bool gameStarted = false;

    [SerializeField]
    private GameObject board;

    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private Text gameText;

    private BoardInput boardInput;
    private Vector3 ballStartPosition;
    private Rigidbody ballRigidbody;
    private float restartDelay = 3f;
    private float restartTimer;
    private float resetDelay = 0.4f;
    private float resetTimer;

    // Use this for initialization
    void Start() {

        // Uncomment the next two lines to hide and lock the cursor
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;

        // Get the board input script
        boardInput = board.GetComponent<BoardInput>();

        // Get the ball start position
        ballStartPosition = ball.transform.localPosition;

        // Get the ball rigidbody
        ballRigidbody = ball.GetComponent<Rigidbody>();

        // Prevent the player from moving at the start of the game
        boardInput.enabled = false;

    }

    // Update is called once per frame
    void Update() {

        // If the game is not started and the player presses the space bar...
        if (gameStarted == false && Input.GetKeyUp(KeyCode.Space)) {

            // ...start the game.
            StartGame();

        }

        // If the player is no longer alive...
        if (ScoreDetection.scored == true) {

            // ...end the game...
            EndGame();

        }

    }

    // Start the game and allow player control
    private void StartGame() {

        // Hide the game text
        gameText.color = Color.clear;

        // Set the game state
        gameStarted = true;

        // Allow the player to move
        boardInput.enabled = true;

    }

    // End the game and reset the board
    private void EndGame() {

        // Stop the player from moving the board
        boardInput.enabled = false;

        // Show the game text
        gameText.color = Color.white;
        gameText.text = "YOU WON!";

        // ...increment a timer to count up to restarting...
        restartTimer = restartTimer + Time.deltaTime;

        // ...and if it reaches the restart delay...
        if (restartTimer >= restartDelay) {

            // Set the game state
            gameStarted = false;

            // Reset the timer
            restartTimer = 0f;

        }

        // ...increment a timer to count up to restarting...
        resetTimer = resetTimer + Time.deltaTime;

        // ...and if it reaches the restart delay...
        if (resetTimer >= resetDelay + restartDelay) {

            // Reset the timer
            resetTimer = 0f;

            // Reset the game
            ResetGame();

        }

    }

    // Reset the game board
    private void ResetGame() {

        // Set the score state
        ScoreDetection.scored = false;

        // Reset the game board
        board.transform.localRotation = Quaternion.identity;

        // Reset the ball position
        ball.transform.localPosition = ballStartPosition;
        ball.transform.localRotation = Quaternion.identity;

        // Reset the game text
        gameText.text = "Press Space to Start";

        // Reset the ball velocity
        ballRigidbody.velocity = Vector3.zero;

    }

}
