using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int ATTEMPTS_UNTIL_GAME_OVER = 3;

    public List<LevelDefinition> levels;
    public GameObject levelEndPopUp;
    [HideInInspector] public LevelDefinition currentLevel;
    [HideInInspector] public int incorrectAttempts; // the number of incorrect ingredient use attempts before game over PER LEVEL
    [HideInInspector] public int correctAnswers; // number of correct answers per level
    [HideInInspector] public bool playerWonLevel;
    [HideInInspector] public bool levelFinished;

    private void Start()
    {
        correctAnswers = 0;
        incorrectAttempts = 0;
        levelFinished = false;
        levelEndPopUp.SetActive(false);
        currentLevel = levels[0];
        StartLevel(currentLevel);
    }

    private void Update()
    {
        if (correctAnswers >= 3)
        {
            levelFinished = true;
            playerWonLevel = true;
        }
        else if (incorrectAttempts >= 3)
        {
            levelFinished = true;
            playerWonLevel = false;
        }

        if (levelFinished)
        {
            if (playerWonLevel)
            {
                int nextLevel = currentLevel.levelOrder + 1;
                if (nextLevel < levels.Count)
                {
                    currentLevel = levels[nextLevel];
                    StartLevel(currentLevel);
                }
            }
            else // defeat
            {
                levelEndPopUp.SetActive(true);
                // start level is called by pressing the TryAagain button in the UI after defeat
            }
        }
    }
    
    public void StartLevel(LevelDefinition level)
    {
        levelEndPopUp.SetActive(false); // reset
        correctAnswers = 0; // reset
        incorrectAttempts = 0; // reset
        playerWonLevel = false; // reset
        levelFinished = false; // reset
    }

    // current level that is active in the scene, can get currentLevel properties such as instructions, etc
    public LevelDefinition GetCurrentLevel()
    {
        return currentLevel;
    }

    public void IncrementIncorrectAttempts()
    {
        incorrectAttempts += 1;
    }

    public int GetIncorrectAttempts()
    {
        return incorrectAttempts;
    }

    public void IncrementCorrectAnswers()
    {
        correctAnswers += 1;
    }

    public int GetNumberOfCorrectAnswers()
    {
        return correctAnswers;
    }
}
