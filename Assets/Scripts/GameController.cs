using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<LevelDefinition> levels;
    public LevelDefinition currentLevel;
    public int attempts; // the number of incorrect ingredient use attempts before game over

    private void Start()
    {
        foreach (LevelDefinition level in levels)
        {
            currentLevel = level;
            StartLevel(currentLevel);
        }
    }

    private void Update()
    {
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


    // PLACEHOLDERS UNTIL WE GET THEM IMPLEMENTED IN OTHER SCRIPTS

    // the script that deals with dropping ingredients into the pot will tell us whether the choice was correct
    // this uses a method from that script
    public bool IngredientChoiceIsIncorrect()
    {
        return false;
    }
}
