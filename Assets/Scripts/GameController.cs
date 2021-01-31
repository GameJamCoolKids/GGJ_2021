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
    [HideInInspector] public bool playerWonLevel;
    [HideInInspector] public bool levelFinished;

    private void Start()
    {
        levelFinished = false;
        levelEndPopUp.SetActive(false);
        currentLevel = levels[0];
        StartLevel(currentLevel);
    }

    private void Update()
    {
        if (levelFinished)
        {
            incorrectAttempts = 0; // reset
            playerWonLevel = false; // reset
            levelFinished = false; // reset
            levelEndPopUp.SetActive(false); // reset
            if (playerWonLevel)
            {
                int nextLevel = currentLevel.levelOrder + 1;
                if (nextLevel < levels.Count)
                {
                    currentLevel = levels[nextLevel];
                    StartLevel(currentLevel);
                }
            }
            else
            {
                levelEndPopUp.SetActive(true);
            }
        }
    }

    // sets the win and loss conditions for the level
    public void StartLevel(LevelDefinition level)
    {

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
}
