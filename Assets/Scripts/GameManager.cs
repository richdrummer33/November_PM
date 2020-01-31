using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // "Singleton pattern" 
    // static: There is only one instance of this variable _instance
    public static GameManager _instance; // _instance is an instance of GameManager 

    int numberCubesDestroyed; 

    public Text uiText; // Counting score 

    public Text timerText; 

    public int numCubesToDestroy = 10; // How many it takes to win

    public float gameTime = 5f; // How much time you'ce got to knock over  all the cubes 

    float currentTimer = 0f;

    public BasicButtonController resetButton;

    // Start is called before the first frame update
    void Start()
    {
        _instance = this; // "this" is the GameManager script

        resetButton.OnButtonPressed += ResetGame; // Subscribe my reset method to the button
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimer < gameTime)
        {
            if (numberCubesDestroyed < numCubesToDestroy) // We haven't yet won
            {
                uiText.text = "Num Destroyed: " + numberCubesDestroyed;
                currentTimer = currentTimer + Time.deltaTime; // Counts up in real time
            }
            else
            {
                uiText.text = "You win!!";
            }            
        }
        else
        {
            uiText.text = "YOU LOSE"; 
        }
        
        timerText.text = "Time Remaining: " + System.Math.Round((gameTime - currentTimer), 1);
    }

    public void CountCubeDestroyed()
    {
        numberCubesDestroyed = numberCubesDestroyed + 1; // Increment the count
    }

    void ResetGame()
    {
        numberCubesDestroyed = 0;

        currentTimer = 0f;
    }
}
