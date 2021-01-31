using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int ATTEMPTS_UNTIL_GAME_OVER = 3;

    public List<LevelDefinition> levels;
    [HideInInspector] public LevelDefinition currentLevel;
    [HideInInspector] public int incorrectAttempts; // the number of incorrect ingredient use attempts before game over PER LEVEL
    [HideInInspector] public bool playerWonLevel;

    private void Start()
    {
        currentLevel = levels[0];
        StartLevel(currentLevel);
    }

    private void Update()
    {
        if (playerWonLevel)
        {
            int nextLevel = currentLevel.levelOrder + 1;
            if (nextLevel < levels.Count)
            {
                currentLevel = levels[nextLevel];
                incorrectAttempts = 0; // reset
                playerWonLevel = false; // reset
                StartLevel(currentLevel);
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
