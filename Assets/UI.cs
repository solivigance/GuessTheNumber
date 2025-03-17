using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuessTheNumber : MonoBehaviour
{
    public TMP_Text headerText;
    public TMP_InputField guessInputField;
    public Button submitButton;
    public Button resetButton;

    private int randomNumber;
    private int attemptsRemaining = 3;

    void Start()
    {
        GameSetup();
    }

    public void GameSetup()
    {
        randomNumber = Random.Range(1, 10); // Generate a random number between 1 and 10
        attemptsRemaining = 3;
        headerText.text = "Guess the number between 1 and 10 I'm thinking of. You have 3 attempts.";
        guessInputField.text = "";
        guessInputField.interactable = true;
        submitButton.interactable = true;
    }

    public void SubmitGuess()
    {
        if (int.TryParse(guessInputField.text, out int playerGuess))
        {
            if (playerGuess == randomNumber)
            {
                headerText.text = "You guessed the correct number!";
                EndGame();
            }
            else
            {
                attemptsRemaining--;
                if (attemptsRemaining > 0)
                {
                    headerText.text = "Wrong guess! You have " + attemptsRemaining + " attempts left.";
                }
                else
                {
                    headerText.text = "Game Over! The correct number was " + randomNumber + ".";
                    EndGame();
                }
            }
        }
        else
        {
            headerText.text = "Please enter a valid number.";
        }
    }

    private void EndGame()
    {
        guessInputField.interactable = false;
        submitButton.interactable = false;
    }

    public void ResetGame()
    {
        GameSetup();
    }
}