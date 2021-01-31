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
    [HideInInspector] public bool instruction1Solved;
    [HideInInspector] public bool instruction2Solved;
    [HideInInspector] public bool instruction3Solved;

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
        else
        {
            if (correctAnswers >= 3)
            {
                levelFinished = true;
                playerWonLevel = true;
                Debug.Log("Level Won");
            }
            else if (incorrectAttempts >= 3)
            {
                levelFinished = true;
                playerWonLevel = false;
                Debug.Log("Level Lost");
            }
        }
    }

    public void StartLevel(LevelDefinition level)
    {
        levelEndPopUp.SetActive(false); // reset
        instruction1Solved = false;
        instruction2Solved = false;
        instruction3Solved = false;
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

    public bool IsLevelFinished()
    {
        return levelFinished;
    }

    public bool IsInstruction1Solved()
    {
        return instruction1Solved;
    }

    public bool IsInstruction2Solved()
    {
        return instruction2Solved;
    }

    public bool IsInstruction3Solved()
    {
        return instruction3Solved;
    }

    public void SetInstruction1Solved()
    {
        instruction1Solved = true;
    }

    public void SetInstruction2Solved()
    {
        instruction2Solved = true;
    }

    public void SetInstruction3Solved()
    {
        instruction3Solved = true;
    }
}