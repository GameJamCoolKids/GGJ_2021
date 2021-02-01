using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int ATTEMPTS_UNTIL_GAME_OVER;

    public List<LevelDefinition> levels;
    public GameObject levelEndPopUp;
    public GameObject dimmer;
    public GameObject EndScreen;
    public GameObject IntroSequence;
    public Button gameStartButton;
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
        IntroSequence.SetActive(true);
        dimmer.SetActive(true);
        gameStartButton.onClick.AddListener(DeactivateIntroTimeline);
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

                if (nextLevel == levels.Count)
                {
                    EndScreen.SetActive(true);

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
            if (correctAnswers >= 2)
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

    private void DeactivateIntroTimeline()
    {
        dimmer.SetActive(false);
        IntroSequence.SetActive(false);
    }

    public void StartLevel(LevelDefinition level)
    {
        levelEndPopUp.SetActive(false); // reset
        instruction1Solved = false;
        instruction2Solved = false;
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

    public void SetInstruction1Solved()
    {
        instruction1Solved = true;
    }

    public void SetInstruction2Solved()
    {
        instruction2Solved = true;
    }
}